# ImgGestureViewer

## General info
ImgGestureViewer is an application designed to view photos without using peripherals such as a mouse or keyboard. The program for changing photos uses the user's gestures read from the camera.

![main](./img/main.png)

# About Emgu CV
Emgu CV is a cross platform .Net wrapper to the OpenCV image processing library. Allowing OpenCV functions to be called from .NET compatible languages such as C#, VB, VC++, IronPython etc. The wrapper can be compiled in Mono and run on Windows, Linux, Mac OS X, iPhone, iPad and Android devices.
More info about EmguCV: http://www.emgu.com
## Technologies
* .NET 
* C#
* EmguCV
* Microsoft Visual Studio 2017

## Setup
### NuGet
Using nuget package manager is probably the easiest way to include Emgu CV library in your project. 
* From your project, right click on "References" and select "Manager Nuget Packages..." option. It will open up nuget package manager. 
* Under "Browse", enter the search text "emgu cv" and you should be able to find the Emgu.CV nuget pacakge. 
* *Package "myEmguCV.Net by Tony" includes all necessary EmguCV dlls.

![nuget](./img/emgucv_nuget.png)

## Usage
### Important
My project includes almost all EmguCV dll, except opencv_gpufilters290.dll and nppi32_55.dll. You can download them from here: [EmguCV_dll](https://wseii-my.sharepoint.com/personal/damian_suchy_microsoft_wsei_edu_pl/Documents/Forms/All.aspx?RootFolder=%2Fpersonal%2Fdamian%5Fsuchy%5Fmicrosoft%5Fwsei%5Fedu%5Fpl%2FDocuments%2FEmguCV%5Fdll&FolderCTID=0x01200020DBE7655526ED46BDE0D40918330C2F) and paste them to the following directory: "C:\...\ImgGestureViewer-master\ImgGestureViewer"

Next you have to Build the Solution and that's all. 

##### Running program
* Connect your webcam
* Run ImgGestureViewer.exe
* Load images
* Turn on the camera
* Follow the gesture

## Default gestures
* Next photo - show one finger

![nextPhoto](./img/emgucv_working1.png)


* Previous photo - show two fingers

![previousPhoto](./img/emgucv_working2.png)

 
## Contact
Created by [Damian Suchy](https://github.com/4lkon) 
Mail: damian.suchy@microsoft.wsei.edu.pl