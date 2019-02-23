using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//wybieranie zdjec
using System.IO;
//emgu
using Emgu.CV;
using Emgu.CV.Structure;
//wykrycie skory - biblioteka
using ImgGestureViewer.SkinDetector;
//DiresctShow
using DirectShowLib;

namespace ImgGestureViewer
{
    public partial class Form1 : Form
    {
        //lista zdjec
        List<string> Imagefiles = new List<string>();
        int imageCount = 0;
        //kamera
        Capture capwebcam = null;
        private bool capwebcamInProgress;
        //zmienne poszczegolnych obrazow, gestow itd
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcessed;
        Image<Bgr, Byte> currentFrame;
        Seq<Point> hull;
        Seq<Point> filteredHull;
        Seq<MCvConvexityDefect> defects;
        MCvConvexityDefect[] defectArray;
        String gesture;
        MCvBox2D box;
        double fingLen;
        Hsv hsv_min;
        Hsv hsv_max;
        Ycc YCrCb_min;
        Ycc YCrCb_max;
        IColorSkinDetector skinDetector;
        PointF cogPt;
        private int contourAxisAngle;
        MCvMoments mv;
        //lista dostepnych kamer
        Video_Device[] WebCams;

        public Form1()
        {
            InitializeComponent();
            //minimalne ustawienia hsv, YCrCb
            hsv_min = new Hsv(0, 45, 0);
            hsv_max = new Hsv(20, 255, 255);
            YCrCb_min = new Ycc(0, 131, 80);
            YCrCb_max = new Ycc(255, 185, 135);
            mv = new MCvMoments();

            //szukanie podlaczonych kamer
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID);
                cameraList.Items.Add(WebCams[i].ToString());
            }
            if (cameraList.Items.Count > 0)
            {
                cameraList.SelectedIndex = 0;
            }
        }
        void processFrameAndUpdateGUI(object sender, EventArgs e)
        {
            //przechwycenie obrazu z kamery
            imgOriginal = capwebcam.RetrieveBgrFrame();
            currentFrame = capwebcam.QueryFrame();

            //wykrycie skory, przeksztalcanie obrazu, wykrycie kontur, liczba palcow
            skinDetector = new YCrCbSkinDetector();
            Image<Gray, Byte> skin = skinDetector.DetectSkin(currentFrame, YCrCb_min, YCrCb_max);
            imgProcessed = skin.SmoothGaussian(9);
            ExtractContourAndHull(imgProcessed);
            if (defects != null)
                DrawAndComputeFingersNum();
            cameraImage.Image = currentFrame;
        }
        //wykrycie kontur oraz punktow poczatku oraz konca palcow
        private void ExtractContourAndHull(Image<Gray, byte> skin)
        {
            using (MemStorage storage = new MemStorage())
            {

                Contour<Point> contours = skin.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage);
                Contour<Point> biggestContour = null;

                Double Result1 = 0;
                Double Result2 = 0;
                while (contours != null)
                {
                    Result1 = contours.Area;
                    if (Result1 > Result2)
                    {
                        Result2 = Result1;
                        biggestContour = contours;
                    }
                    contours = contours.HNext;
                }

                if (biggestContour != null)
                {
                    Contour<Point> currentContour = biggestContour.ApproxPoly(biggestContour.Perimeter * 0.0025, storage);
                    currentFrame.Draw(currentContour, new Bgr(Color.LimeGreen), 2);
                    biggestContour = currentContour;
                    hull = biggestContour.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                    box = biggestContour.GetMinAreaRect();
                    PointF[] points = box.GetVertices();
                    mv = biggestContour.GetMoments();
                    CvInvoke.cvMoments(biggestContour, ref mv, 1);
                    double m00 = CvInvoke.cvGetSpatialMoment(ref mv, 0, 0);
                    double m10 = CvInvoke.cvGetSpatialMoment(ref mv, 1, 0);
                    double m01 = CvInvoke.cvGetSpatialMoment(ref mv, 0, 1);
                    if (m00 != 0)
                    {
                        int xCenter = (int)Math.Round(m10 / m00) * 2;
                        int yCenter = (int)Math.Round(m01 / m00) * 2;
                        cogPt.X = xCenter;
                        cogPt.Y = yCenter;
                    }

                    double m11 = CvInvoke.cvGetCentralMoment(ref mv, 1, 1);
                    double m20 = CvInvoke.cvGetCentralMoment(ref mv, 2, 0);
                    double m02 = CvInvoke.cvGetCentralMoment(ref mv, 0, 2);
                    contourAxisAngle = calculateTilt(m11, m20, m02);
                    Point[] ps = new Point[points.Length];
                    for (int i = 0; i < points.Length; i++)
                        ps[i] = new Point((int)points[i].X, (int)points[i].Y);

                    currentFrame.DrawPolyline(hull.ToArray(), true, new Bgr(200, 125, 75), 2);
                    currentFrame.Draw(new CircleF(new PointF(box.center.X, box.center.Y), 3), new Bgr(200, 125, 75), 2);

                    filteredHull = new Seq<Point>(storage);
                    for (int i = 0; i < hull.Total; i++)
                    {
                        if (Math.Sqrt(Math.Pow(hull[i].X - hull[i + 1].X, 2) + Math.Pow(hull[i].Y - hull[i + 1].Y, 2)) > box.size.Width / 10)
                        {
                            filteredHull.Push(hull[i]);
                        }
                    }

                    defects = biggestContour.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                    defectArray = defects.ToArray();
                }
            }
        }
        //obliczanie ruchu obiektu
        private int calculateTilt(double m11, double m20, double m02)
        {
            double diff = m20 - m02;
            if (diff == 0)
            {
                if (m11 == 0)
                    return 0;
                else if (m11 > 0)
                    return 45;
                else
                    return -45;
            }
            double theta = 0.5 * Math.Atan2(2 * m11, diff);
            int tilt = (int)Math.Round(57.2957795 * theta);

            //obliczanie katow pochylenia obiektu
            if ((diff > 0) && (m11 == 0))
                return 0;
            else if ((diff < 0) && (m11 == 0))
                return -90;
            else if ((diff > 0) && (m11 > 0)) //od 0 stopni do 45
                return tilt;
            else if ((diff > 0) && (m11 < 0)) //od -45 stopni do 0
                return (180 + tilt); //zmana kata przeciwnie do wskazowek zegara
            else if ((diff < 0) && (m11 > 0)) //od 45 stopni do 90
                return tilt;
            else if ((diff < 0) && (m11 < 0)) //od -90 stopni do -45
                return (180 + tilt); //zmana kata przeciwnie do wskazowek zegara
            return 0;
        }
        //rysowanie linii palcow
        private void DrawAndComputeFingersNum()
        {
            int fingerNum = 0;
            fingLen = 0;

            for (int i = 0; i < defects.Total; i++)
            {
                PointF startPoint = new PointF((float)defectArray[i].StartPoint.X,
                                                (float)defectArray[i].StartPoint.Y);

                PointF depthPoint = new PointF((float)defectArray[i].DepthPoint.X,
                                                (float)defectArray[i].DepthPoint.Y);

                PointF endPoint = new PointF((float)defectArray[i].EndPoint.X,
                                                (float)defectArray[i].EndPoint.Y);

                LineSegment2D startDepthLine = new LineSegment2D(defectArray[i].StartPoint, defectArray[i].DepthPoint);

                LineSegment2D depthEndLine = new LineSegment2D(defectArray[i].DepthPoint, defectArray[i].EndPoint);

                CircleF startCircle = new CircleF(startPoint, 5f);

                CircleF depthCircle = new CircleF(depthPoint, 5f);

                CircleF endCircle = new CircleF(endPoint, 5f);

                if ((startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > box.size.Height / 6.5))
                {
                    fingerNum++;
                    currentFrame.Draw(startDepthLine, new Bgr(Color.Green), 2);
                    if (fingLen < Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)))
                        fingLen = Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2));
                }

                currentFrame.Draw(startCircle, new Bgr(Color.Red), 2);
                currentFrame.Draw(depthCircle, new Bgr(Color.Yellow), 5);
            }

            if (fingLen < 120)
            {
                fingerNum = 0;
            }

            gestureRecog(fingerNum);
        }
        //wykrycie gestow zaleznie od ilosci palcow
        private void gestureRecog(int fingerNum)
        {
            if (fingerNum == 0)
            {
                gesture = gestureRecognize.Text = "Zaciśnięta pięść";
                actionBox.Clear();
            }

            else if (fingerNum == 5)
            {
                gesture = gestureRecognize.Text = "5 palców";
                actionBox.Clear();
            }

            else if (fingerNum == 4)
            {
                gesture = gestureRecognize.Text = "4 palce";
                actionBox.Clear();
            }

            else if (fingerNum == 3)
            {
                gesture = gestureRecognize.Text = "3 palce";
                actionBox.Clear();
            }

            else if (fingerNum == 2)
            {
                gesture = gestureRecognize.Text = "2 palce";
                //poprzednie zdjecie
                actionBox.Text = "Poprzednie zdjęcie";
                previousBtn.PerformClick();
            }

            else if (fingerNum == 1)
            {
                gesture = gestureRecognize.Text = "1 palec";
                //nastepne zdjecie
                actionBox.Text = "Następne zdjęcie";
                nextBtn.PerformClick();
            }

            else
            {
                gesture = gestureRecognize.Text = "Nie rozpoznano gestu. Wykonaj gest ponownie.";
                actionBox.Clear();
            }
        }

        //wyswietlenie nazwy obrazka
        private void imgageName()
        {
            string address = pictureBox.ImageLocation;
            string result;
            //usuniecie koncowek '.jpg oraz .png'
            char[] znaki = { '.', 'j', 'p', 'g', 'p', 'n', 'g' };
            result = (Path.GetFileName(address)).TrimEnd(znaki);
            imgName.Text = result;
        }
        //wybieranie obrazow z katalogu
        private void findImagesInDirectory(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string s in files)
            {
                //format obrazkow
                if (s.EndsWith(".jpg") || s.EndsWith(".png"))
                {
                    Imagefiles.Add(s);
                }
            }
            try
            {
                //po zaladowaniu zdjec, wyswietl pierwszy obraz
                pictureBox.ImageLocation = Imagefiles.First();
                imgageName();
            }
            catch { MessageBox.Show("Nie znaleziono zdjęć!"); }

        }
        //poprzednie zdjecie
        private void previousBtn_Click(object sender, EventArgs e)
        {
            if (pictureBox.ImageLocation != null)
            {
                --imageCount;
                //sprawdzam czy pierwsze zdjecie na liscie, jesli tak, wyswietlam ostatnie
                if (imageCount < 0)
                    imageCount = Imagefiles.Count == 0 ? -1 : Imagefiles.Count - 1;
                string prevImage = Imagefiles[imageCount];
                pictureBox.ImageLocation = prevImage;
                imgageName();
            }
            else MessageBox.Show("Nie załadowano zdjęć", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //nastepne zdjecie
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (pictureBox.ImageLocation != null)
            {
                ++imageCount;
                //sprawdzam czy ostatnie zdjecie na liscie, jestli tak, wyswietlam pierwsze
                if (imageCount >= Imagefiles.Count)
                    imageCount = Imagefiles.Count == 0 ? -1 : 0;
                string prevImage = Imagefiles[imageCount];
                pictureBox.ImageLocation = prevImage;
                imgageName();
            }
            else MessageBox.Show("Nie załadowano zdjęć", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //ladowanie zdjec z katalogu
        private void loadImg_Click(object sender, EventArgs e)
        {
            if (pictureBox.ImageLocation != null)
            {
                MessageBox.Show("Zdjęcia już wczytane", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        findImagesInDirectory(fbd.SelectedPath);
                    }
                }
            }
        }
        //start/stop kamery
        private void cameraStartBtn_Click(object sender, EventArgs e)
        {
            if (capwebcam == null)
            {
                capwebcam = new Capture();
            }

            if (capwebcam != null)
            {
                if (capwebcamInProgress)
                {
                    //stop kamery
                    cameraStartBtn.Text = "Włącz kamerę";
                    Application.Idle -= processFrameAndUpdateGUI;
                }
                else
                {
                    //start kamery
                    cameraStartBtn.Text = "Zatrzymaj kamerę";
                    Application.Idle += processFrameAndUpdateGUI;
                }
                capwebcamInProgress = !capwebcamInProgress;
                gestureRecognize.Text = null;

            }
        }
    }
}
