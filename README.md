## GhostAR

Fange die Geister / Catch the ghosts: Experimental augmented reality (AR) game for Android mobiles based on Vuforia.

**GhostAR - fange Geister in Augmented Reality! Mit einem Scanner ausgerüstet bewegst du dich durch einen Raum auf der Jagd nach Geistern, die sich überall verstecken. Sei schnell - die Zeit eilt!**

**GhostAR - catch ghosts in Augmented Reality! Equipped with a scanner, you move through a room, hunting for ghosts hiding just about everywhere. Be fast - there's not much time!**

## Software and Library

GhostAR was programmed in C# with Unity version 2018.1.4f Personal (64bit) and Vuforia Version 7.1.35 for Unity.

## Unity

As mentioned above, you need Unity version 2018.1.4f for this app. Unity has a hard time with projects implemented in other versions so I suggest downloading the same version as we used for this app.

[Unity Archive](https://unity3d.com/de/get-unity/download/archive?_ga=2.57292968.369518449.1531921044-274948365.1528718882)

A Vuforia SDK is included in the Unity installation.


## Vuforia

This app uses the image recognition feature from Vuforia. For Vuforia to recognise these images, you have to upload the images on the Vuforia Target Manager: https://developer.vuforia.com/.

In order to do that you have to first create an account and receive a license key which you have to paste into your Unity Vuforia Configurations (Ctrl+Shift+V in Unity).

Now you can create a new database in Vuforia's Target Manager and upload your images. After you have uploaded your images, you see a rating on every image. You should try to achieve at least a rating of 4/5 stars. Everything below is problematic for Vuforia to recognise especially from distance.

When you've filled your database with the images you want Vuforia to recognise, you can click on the "Download Database (All)" button on the top right and select Unity as your development platform. Opening the downloaded file will import the images into your Unity Project.

If you only want certain pictures from the database, you can also just check the box on the left of these pictures and click on the "Download Database" button.


Software made with love by Geometa Lab HSR for HSR Informatik (Computer Science).
