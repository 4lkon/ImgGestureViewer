# ImgGestureViewer

## General info
ImgGestureViewer is an application designed to view photos without using peripherals such as a mouse or keyboard. The program for changing photos uses the user's gestures read from the camera.

![main](./img/main.png)

## About Emgu CV
Emgu CV is a cross platform .Net wrapper to the OpenCV image processing library. Allowing OpenCV functions to be called from .NET compatible languages such as C#, VB, VC++, IronPython etc. The wrapper can be compiled in Mono and run on Windows, Linux, Mac OS X, iPhone, iPad and Android devices.
More info about EmguCV: http://www.emgu.com
## Technologies
* .NET 
* C#
* EmguCV
* Microsoft Visual Studio 2017

## Usage
### Important
My project includes almost all EmguCV dll, except opencv_gpufilters290.dll and nppi32_55.dll. You can download them from here: [EmguCV_dll](https://www.dropbox.com/sh/xt0vl1bdzxa8klr/AABr3o49c_8u4BpOtEZ-MqNOa?dl=0) and paste them to the following directory: "C:\...\ImgGestureViewer-master\ImgGestureViewer"

Next you have to Build the Solution and that's all. 

##### Running program
* Connect your webcam
* Run ImgGestureViewer.exe
* Load images
* Turn on the camera
* Make a gesture

## Default gestures
* Next photo - show one finger

![nextPhoto](./img/emgucv_working1.png)


* Previous photo - show two fingers

![previousPhoto](./img/emgucv_working2.png)

 
## Contact
Created by [Damian Suchy](https://github.com/4lkon) 
Mail: alkon612@gmail.com
