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

## Android Software Developers's Kit / Java Development Kit

### Software Developers's Kit

In order to build and run GhostAR on your Android device you need the specific Android SDK of your device. You can download the SDK with [Android Studio](https://developer.android.com/studio/). After installation open Android Studio and navigate to _Configure_ -> _SDK Manager_. Download the SDK of the Android device you want to use GhostAR on. (Currently the Android Version of your phone has to be at least 4.1 (Jelly Bean))

![SDK Manager](https://md.coredump.ch/uploads/upload_29363a555588b9aa4e2882dff1d68be8.png)

_Figure 1_

After Android Studio finished downloading the SDK, open GhostAR in your Unity Editor and navigate to _Edit_ -> _Preferences..._ -> _External Tools_ and add the path to the SDK you just downloaded. Unity should detect the SDK automatically after you press _Browse_. If not the default Path to your SDK is: `C:/Users/[Username]/AppData/Local/Android/Sdk`. Replace [Username] with your Username without the brackets.

### Java Development Kit

If you haven't already installed the Java Development Kit download it from the [Oracle Website](https://www.oracle.com/technetwork/java/javase/downloads/index.html). Add the path to the JDK the same way you did with the SDK in the Unity Editor. The default path to your JDK is `C:\Program Files\Java\jdk[version]`. [Version] referring to your currently installed JDK Version.


## Vuforia

This app uses the image recognition feature from Vuforia. For Vuforia to recognise these images, you have to upload the images on the Vuforia Target Manager: https://developer.vuforia.com/.

In order to do that you have to first create an account and receive a license key which you have to paste into your Unity Vuforia Configurations (Ctrl+Shift+V in Unity).

Now you can create a new database in Vuforia's Target Manager and upload your images. After you have uploaded your images, you see a rating on every image. You should try to achieve at least a rating of 4/5 stars. Everything below is problematic for Vuforia to recognise especially from distance.

When you've filled your database with the images you want Vuforia to recognise, you can click on the "Download Database (All)" button on the top right and select Unity as your development platform. Opening the downloaded file will import the images into your Unity Project.

If you only want certain pictures from the database, you can also just check the box on the left of these pictures and click on the "Download Database" button.

## Create an Image Target in Unity

To create a new image target in Unity, you have to go to "GameObject -> Vuforia -> Image". You should now a see a new Object in your Unity scene. On your right you should see that the Inspector openend the ImageTarget.

![Unity Inspector](https://md.coredump.ch/uploads/upload_5b0de54cc647b21de263c3489962a0db.png)

_Figure 2_

Under the section "Image Target Behaviour" you can select your imported database and image you want to display on this object. Now you have to drag a ghost object onto the image target. You can find pre-created ghosts under "Assets/Ghost/Objects". For each new ghost you have to add the components "Mesh Collider" and "Ghost Catcher (Script)". You also have to resize and reposition the ghost so it's in front of the image target. Otherwise you won't see the ghost appear in the app.

![](https://md.coredump.ch/uploads/upload_b261dbdb2cc5c6c588e507520e7d0ee2.png)

_Figure 3_

## Testing the app

If you want to test the app with Unity, you need a functional camera. Then you just have to click on the Start Button on the top. Print your image targets you added in  Unity and hold them in front of the camera. If you did everything right, you should see a Ghost appearing in front of the image target.

## Building the APK

The last step is to build the APK onto your phone. First connect your phone with a USB to your PC. Then you have open the build settings (Ctrl + Shift + B) and select "Android" as your platform and also select all scenes in the build.

![](https://md.coredump.ch/uploads/upload_b14e80f74558ab1856433d657a903111.png)

_Figure 4_

Now open the "Player Settings..." (on the bottom left in figure 3) and make sure that under "Other Settings -> Identifaction" the prerequistes aren't higher than your phone specifications. Also verify if under "XR Settings" the box "Vuforia Augmented Reality Support" is checked.

On your phone you have to activate the developer options and enable "USB debugging". Otherwise your phone is not able to build the app.

If you made sure everything is in order, you can press the button "Build and Run".

**Software made with love by Geometa Lab HSR for HSR Informatik (Computer Science).**