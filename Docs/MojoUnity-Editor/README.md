## MojoUnity-Editor v1.0

**MojoUnity-Editor** is an extension of the **UnityEditor**. With **MojoUnity-Editor**, you can **easily** and **quickly** extend the Unity's **Inspector** and **Window**.

## Features

**MojoUnity-Editor** uses a new way to code Inspector and window, it skips many details to control the format and interaction of properties on GUI.

Sure, using **MojoUnity-Editor**, you can easily build your complex Inspectors or Windows.

The core design is:
* First, build built-in formatting and visibility control, which is **BaseEditor**.
* Second, by inheriting **BaseEditor** to controlling properties implement the logical display and interaction.

The main ways of use are: 

* Use **Switch** to catch the properties that need to be set.
* Use **DrawType** to control properties on Inspector or Window.
* Use **EditorTool** to handle properties in Array or Object.

## How to use

![Common Test](/Images/MojoUnity-Editor/CommonTest.png "Common Test")
![Group Test](/Images/MojoUnity-Editor/GroupTest.png "Group Test")
![Array Test](/Images/MojoUnity-Editor/ArrayTest.png "Array Test")
![Object Test](/Images/MojoUnity-Editor/ObjectTest.png "Object Test")
![Logic Test](/Images/MojoUnity-Editor/LogicTest.png "Logic Test")
![Window Test](/Images/MojoUnity-Editor/WindowTest.png "Window Test")

## Support

* Any bugs can go to [[MojoUnity-Editor Issues]](https://github.com/scottcgi/MojoUnity-Packages/labels/MojoUnity-Editor) for feedback.
* Any questions or comments can go to [[MojoUnity-Editor Discussions]](https://github.com/scottcgi/MojoUnity-Packages/discussions/categories/mojounity-editor) for exchange.