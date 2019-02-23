namespace ImgGestureViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.imgName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraImage = new Emgu.CV.UI.ImageBox();
            this.gestureLabel = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.cameraListLabel = new System.Windows.Forms.Label();
            this.gestureRecognize = new System.Windows.Forms.TextBox();
            this.actionBox = new System.Windows.Forms.TextBox();
            this.previousBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.loadImg = new System.Windows.Forms.Button();
            this.cameraStartBtn = new System.Windows.Forms.Button();
            this.cameraList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Location = new System.Drawing.Point(12, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(587, 395);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // imgName
            // 
            this.imgName.AutoSize = true;
            this.imgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.imgName.Location = new System.Drawing.Point(12, 6);
            this.imgName.Name = "imgName";
            this.imgName.Size = new System.Drawing.Size(52, 16);
            this.imgName.TabIndex = 1;
            this.imgName.Text = "Nazwa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(616, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Obraz z kamery:";
            // 
            // cameraImage
            // 
            this.cameraImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cameraImage.BackgroundImage")));
            this.cameraImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("cameraImage.InitialImage")));
            this.cameraImage.Location = new System.Drawing.Point(619, 25);
            this.cameraImage.Name = "cameraImage";
            this.cameraImage.Size = new System.Drawing.Size(255, 204);
            this.cameraImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraImage.TabIndex = 2;
            this.cameraImage.TabStop = false;
            // 
            // gestureLabel
            // 
            this.gestureLabel.AutoSize = true;
            this.gestureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gestureLabel.Location = new System.Drawing.Point(616, 232);
            this.gestureLabel.Name = "gestureLabel";
            this.gestureLabel.Size = new System.Drawing.Size(115, 16);
            this.gestureLabel.TabIndex = 3;
            this.gestureLabel.Text = "Rozpoznany gest:";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actionLabel.Location = new System.Drawing.Point(616, 285);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(45, 16);
            this.actionLabel.TabIndex = 4;
            this.actionLabel.Text = "Akcja:";
            // 
            // cameraListLabel
            // 
            this.cameraListLabel.AutoSize = true;
            this.cameraListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cameraListLabel.Location = new System.Drawing.Point(616, 367);
            this.cameraListLabel.Name = "cameraListLabel";
            this.cameraListLabel.Size = new System.Drawing.Size(144, 16);
            this.cameraListLabel.TabIndex = 5;
            this.cameraListLabel.Text = "Wybierz kamerę z listy:";
            // 
            // gestureRecognize
            // 
            this.gestureRecognize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gestureRecognize.Location = new System.Drawing.Point(619, 251);
            this.gestureRecognize.Multiline = true;
            this.gestureRecognize.Name = "gestureRecognize";
            this.gestureRecognize.ReadOnly = true;
            this.gestureRecognize.Size = new System.Drawing.Size(255, 34);
            this.gestureRecognize.TabIndex = 6;
            // 
            // actionBox
            // 
            this.actionBox.Location = new System.Drawing.Point(619, 304);
            this.actionBox.Multiline = true;
            this.actionBox.Name = "actionBox";
            this.actionBox.ReadOnly = true;
            this.actionBox.Size = new System.Drawing.Size(255, 34);
            this.actionBox.TabIndex = 7;
            // 
            // previousBtn
            // 
            this.previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.previousBtn.Location = new System.Drawing.Point(12, 426);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(121, 59);
            this.previousBtn.TabIndex = 9;
            this.previousBtn.Text = "Poprzednie zdjęcie";
            this.previousBtn.UseVisualStyleBackColor = true;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextBtn.Location = new System.Drawing.Point(478, 426);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(121, 59);
            this.nextBtn.TabIndex = 10;
            this.nextBtn.Text = "Następne zdjęcie";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // loadImg
            // 
            this.loadImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadImg.Location = new System.Drawing.Point(253, 426);
            this.loadImg.Name = "loadImg";
            this.loadImg.Size = new System.Drawing.Size(121, 59);
            this.loadImg.TabIndex = 11;
            this.loadImg.Text = "Wczytaj zdjęcia";
            this.loadImg.UseVisualStyleBackColor = true;
            this.loadImg.Click += new System.EventHandler(this.loadImg_Click);
            // 
            // cameraStartBtn
            // 
            this.cameraStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cameraStartBtn.Location = new System.Drawing.Point(696, 426);
            this.cameraStartBtn.Name = "cameraStartBtn";
            this.cameraStartBtn.Size = new System.Drawing.Size(121, 59);
            this.cameraStartBtn.TabIndex = 12;
            this.cameraStartBtn.Text = "Włącz kamerę";
            this.cameraStartBtn.UseVisualStyleBackColor = true;
            this.cameraStartBtn.Click += new System.EventHandler(this.cameraStartBtn_Click);
            // 
            // cameraList
            // 
            this.cameraList.FormattingEnabled = true;
            this.cameraList.Location = new System.Drawing.Point(619, 386);
            this.cameraList.Name = "cameraList";
            this.cameraList.Size = new System.Drawing.Size(255, 21);
            this.cameraList.TabIndex = 13;
            this.cameraList.SelectedIndexChanged += new System.EventHandler(this.cameraStartBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 497);
            this.Controls.Add(this.cameraList);
            this.Controls.Add(this.cameraStartBtn);
            this.Controls.Add(this.loadImg);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.previousBtn);
            this.Controls.Add(this.actionBox);
            this.Controls.Add(this.gestureRecognize);
            this.Controls.Add(this.cameraListLabel);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.gestureLabel);
            this.Controls.Add(this.cameraImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgName);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label imgName;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox cameraImage;
        private System.Windows.Forms.Label gestureLabel;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label cameraListLabel;
        private System.Windows.Forms.TextBox gestureRecognize;
        private System.Windows.Forms.TextBox actionBox;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button loadImg;
        private System.Windows.Forms.Button cameraStartBtn;
        private System.Windows.Forms.ComboBox cameraList;
    }
}

