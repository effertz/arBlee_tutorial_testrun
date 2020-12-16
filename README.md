# How to create an AR mobile application with Unity
This is a collection of tutorials to demonstrate how to create an Augmented Reality app for your mobile phone using Unity. The app will [spawn a character](https://youtu.be/eL_8jF1a4lk) into the environment around you. 

This collection of tutorials assumes that you are familiar with programming, [IDEs](https://en.wikipedia.org/wiki/Integrated_development_environment) and GitHub. You know the basics and can apply them to new programming languages like C#, Unity development environment and projects in GitHub. No worries, really only basics are needed and for anything you don’t know yet, you can find a tutorial on [YouTube](https://www.youtube.com) or [Unity learn](https://unity.com/learn). 

This tutorial was created using a MacBook and iPhone, but you can also use your Android mobile phone and / or a Windows Desktop or Laptop. However, to create an app for iPhone, you need to install [Xcode](https://developer.apple.com/xcode/) on Apple hardware. Doing it on a Windows machine is possible, but complicated and not part of this tutorial. The set of software verions used to compile the application can be found [here](Docs/Versions.md).

So let’s start:

## Environment Setup - Install required software

To setup your computer for this project follow the steps from [this page](Docs/EnvironmentSetup.md) or ensure that you have the latest versions of Unity, Xcode and Visual Studio for Mac.

## Project Setup - Create your first Unity project

In this tutorial, we will create a mobile application, but if you are new to Unity, you might consider creating a **simple desktop project**. This will help you to get familiar with Unity Editor navigation and functionality. [Get started with Unity - Creator Kit: Beginner Code](https://learn.unity.com/tutorial/get-started-with-creator-kit-beginner-code) and [Create with code](https://learn.unity.com/course/create-with-code) are 2 tutorials, which cover creating basic desktop applications.

To setup a mobile project follow the steps from [this page](Docs/ProjectSetup.md).

## Build your first Unity project

To build a mobile application follow the steps from [this page](Docs/Build.md).

Now you can build and run your app on a mobile device, but your application is a bit boring. Let’s start changing that.

## Get to know XR and setup your project for it

Next step is to get to know **XR**. XR is an umbrella term encompassing **augmented**, **virtual**, and **mixed reality**. An extensive tutorial on XR can be found [here](https://learn.unity.com/tutorial/what-is-xr).

**Augmented Reality AR** is reality augmented (or enhanced) with virtual items. Unity Editor provides a special module to support AR: AR Foundation. [What is Unity AR Foundation?](Docs/WhatIsUnityARFoundationYouTubeVideo.md) is a very good tutorial about AR in Unity. It also shows how to **setup AR in Unity** and how to **create markers in AR**, which is the first step to be able to place a character of your choice into the environment around you.

I'm strongly relaying on the AR Tutorial, but not following it completely. Therefore, feel free to watch it, it is very helpful, but for the app we are creating, follow the steps described below.

First, we will **setup AR components** in your project (Note: for **Android** setup follow the instructions on [YouTube](https://www.youtube.com/watch?v=FGh7f-PaGQc) staring around minute 7:40):

1. In Unity Editor go to *Edit* → *Project Settings* → *Player* and:
    1. add a *Camera Usage Description*, something like: “Enable to use AR Foundation”.
    2. Select *XR Plug-in Management* from the left bar and press *Install XR Plug-in Management*. After the installation is completed check the *ARKit* checkbox to install the iOS AR support. Then select *ARKit* from the left bar and set *Requirement* to *Optional*.
2. In Unity Editor go to *Window* → *Package Manager*. In *Package Manager* window open *Packages: In Project* dropdown and select *Unity Registry*. Search for *AR Foundation*, select it and press *Install*. Close the *Package Manager* window.
3. Now you can add AR Foundation components to your project: Right click in [*Hierarchy* window](https://docs.unity3d.com/2020.2/Documentation/Manual/UsingTheEditor.html) and select *XR* → *AR Session Origin*. You can find more details about this component on [Unity docs](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@1.0-preview.8/api/UnityEngine.XR.ARFoundation.ARSessionOrigin.html) web pages. This component has its own camera, therefore go ahead and delete the existing *Main Camera* from the *Hierarchy* window. Select the *AR Camera* under the *AR Session Origin*, go to the *Inspector* window and change its *Tag* from *Untagged* to *MainCamera*. Next, right click in *Hierarchy* window and select *XR* → *AR Session*.

Now, we will add **plane detection**:

1. First add a plane manager to your session origin: Select *AR Session Origin* in *Hierarchy* window, go to the *Inspector* window, press *Add Component*, search for *AR Plane Manager* and add it to the *AR Session Origin*.
2. Create a plane prefab: Right click in *Hierarchy* window and select *XR* → *AR Default Plane*. Create a *Prefab* folder in your project: Select *Assets* folder in *Project* window, right click, select *Create* → *Folder* and rename it to *Prefab*. Move the *AR Default Plane* from the *Hierarchy* window to the newly created *Prefab* folder. Delete the *AR Default Plane* in the *Hierarchy* window.
3. Assign the plane prefab to the plane manager: Select the *AR Session Origin* in *Hierarchy* window, go to the *Inspector* window, open the *Plane Prefab* dropdown in the *AR Plane Manager*, select the *Assets* tab and select the *AR Default Plane* prefab.

[Build](Docs/Build.md) your application again, in the same way as explained above, and test if you can see the planes around you. You should be able to see planes being detected on the ground, walls, tables etc.

After making sure that this part is working, remove the *AR Default Plane* prefab from the *AR Plane Manager*: You can do that in the *Inspector* window. Click on the *Plane Prefab* dropdown and select *None*.

Next, let’s **add a marker** to your app. It will mark the spot on which you will later place objects. An asset for the marker is in this project. 

1. Add the marker asset to your Unity project: create a new folder in the *Project* window and name it *Textures*. Now drag and drop the indicator asset into this folder. Select the newly added asset, enable *Alpha is Transparency* in the *Inspector* window and press *Apply*. 
2. Create a material for the new asset: Create a new folder in the *Project* window and name it *Materials*. Select it, right click and select *Create* → *Material* and rename it to *Indicator_mat*. While the new material is still selected, go to the *Inspector* window, change the *Shader* to *Unlit* → *Transparent* and set the *Texture* to marker texture previously added.
3. Create an object for the marker: 
    1. Right click in *Hierarchy* window, select *Create Empty* to create an empty game object and rename it to *PlacementIndicator*. Go to the *Inspector* window and set the *Position* to (0,0,0). 
    2. Go back to the *Project* window and create a plane object under *PlacementIndicator*: Right click and select *3D Object* → *Plane*. While the *Plane* is selected, go to the *Inspector* window and
        1. set the *Scale* to (0.02, 0.02, 0.02), 
        2. set *Cast Shadows* to *off* and 
        3. disable *Receive Shadows*. 
        4. Also remove the *Mesh Collider* component. The plane doesn’t need it. Do delete a component press the 3 dots icon in the upper right corner of the component you wish to remove and select *Remove Component*. 
    4. Now, drag the *PlacementIndicator* material on the *Plane* object in the *Scene* view in the center of the Unity Editor.

At this point you can [build](Docs/Build.md) your application again and check if you can see the indicator. It will be always at the same position, therefore next, we will add logic, so the indicator can follow your movement and be used it as a **placement indicator**. For this you will need to add some **C# code**.

1. Create a new C# script: First create a *Scripts* folder under *Assets* in the *Hierarchy* window. Then right click on the folder, select *Create* → *C# Script* and rename it directly to *PlacementIndicator*.
2. Attach the C# script to the *PlacementIndicator* game object: To do that, select the *PlacementIndicator* game object in the *Hierarchy* window, go to the *Inspector* window, press *Add Component*, search for the *Placement Indicator* C# script and select it.
3. Add logic to the *PlacementIndicator* C# script: Double click on the *PlacementIndicator* script in the *Hierarchy* window to open it in *Visual Studio*. Replace the existing code with:
``` C#
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour {
    public GameObject IndicatorIcon;

    private Pose placementPose;
    private bool placementPoseIsValid = false;

    // Manager & Controller
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    // Start is called before the first frame update
    void Start() {
        // get components
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        aRPlaneManager = FindObjectOfType<ARPlaneManager>();
        CheckAllObjects();

        // hide indicator
        IndicatorIcon.SetActive(false);
    }

    void CheckAllObjects() {
        if (aRRaycastManager == null) Debug.LogError("aRRaycastManager is NULL");
        if (aRPlaneManager == null) Debug.LogError("aRPlaneManager is NULL");
        if (IndicatorIcon == null) Debug.LogError("Indicator is NULL");
    }

    // Update is called once per frame
    void Update() {
        UpdateGamePlacementPose();
        UpdateGamePlacementIndicator();
    }

    void UpdateGamePlacementPose() {
        if (aRRaycastManager != null && Camera.current != null) {
            // shoot a raycast from the center of the screen
            Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

            placementPoseIsValid = false;

            // if we hit a AR plane, update the position and rotation 
            foreach (ARRaycastHit hit in hits) {
                ARPlane plane = aRPlaneManager.GetPlane(hit.trackableId);
                if (plane != null) {
                    placementPoseIsValid = true;
                    placementPose = hit.pose;
                    break;
                }
            }
        }
    }

    void UpdateGamePlacementIndicator()
    {
        if (placementPoseIsValid) {
            IndicatorIcon.SetActive(true);
            transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else {
            IndicatorIcon.SetActive(false);
        }
    }
}
```
4. Don’t forget to save your changes to the C# script file.
5. Connect the *Plane* game object to the script: select the *PlacementIndicator* game object in the *Project* window, go to *Inspector* window, open the *Indicator Icon* dropdown and select *Plane*.
6. Add *AR Raycast Manager* to the *AR Session Origin*: Select *AR Session Origin* in the *Project* window, go to the *Inspector* window, click *Add Component*, search for *AR Raycast Manager* and select it.

[Build](Docs/Build.md) again and see how your placement indicator behaves now. It should indicate plane places around you and disappear when no plane can be detected. You will notice that when you move around, the indicator is **rotating** in an unexpected way. Let’s **fix** that.

1. Add logic to the *PlacementIndicator* C# script: double click on the *PlacementIndicator* script in the *Hierarchy* window to open it in *Visual Studio*. Replace the *UpdateGamePlacementPose* method with the following code:
``` C#
void UpdateGamePlacementPose() {
    if (aRRaycastManager != null && Camera.current != null) {
        // shoot a raycast from the center of the screen
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = false;

        // if we hit a AR plane, update the position and rotation 
        foreach (ARRaycastHit hit in hits) {
            ARPlane plane = aRPlaneManager.GetPlane(hit.trackableId);
            if (plane != null) {
                placementPoseIsValid = true;
                placementPose = hit.pose;

                // rotate in view direction
                Vector3 cameraForward = Camera.current.transform.forward * -1.0f;
                Vector3 cameraBearing = new Vector3(cameraForward.x, 0.0f, cameraForward.z).normalized;
                placementPose.rotation = Quaternion.LookRotation(cameraBearing);

                break;
            }
        }
    }
}
```
2. Don’t forget to save your changes to the C# script file.

Now [build](Docs/Build.md) again and check how the placement indicator is behaving. It should smoothly rotate with you while you are moving around.

Next we will add logic to **spawn an object at the location of the indicator** when you touch the screen.

1. Create a new game object to be placed at the indicator location: Right click on the *Hierarchy* window, press *Create Empty*, rename the object to *CubeObject* and set its *Position* to (0,0,0). Now, select the newly created object, right click, press *3D Object* → *Cube*. Set the cube's *Position* to (0,0.05,0) and *Scale* to (0.1, 0.1, 0.1). Delete it’s *Box Collider*, it’s not needed. 
2. Add logic to spawn the *Cube* to the C# script: double click on the *PlacementIndicator* script in the *Hierarchy* window to open it in *Visual Studio*. Replace the existing code with: 
``` C#
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour {
    public GameObject IndicatorIcon;
    public GameObject ObjectToPlace;
    
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    // Manager & Controller
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    // Start is called before the first frame update
    void Start() {
        // get components
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        aRPlaneManager = FindObjectOfType<ARPlaneManager>();
        CheckAllObjects();

        // hide indicator and object to place
        IndicatorIcon.SetActive(false);
        ObjectToPlace.SetActive(false);
    }

    void CheckAllObjects() {
        if (aRRaycastManager == null) Debug.LogError("aRRaycastManager is NULL");
        if (aRPlaneManager == null) Debug.LogError("aRPlaneManager is NULL");
        if (IndicatorIcon == null) Debug.LogError("Indicator is NULL");
        if (ObjectToPlace == null) Debug.LogError("ObjectToPlace is NULL");
    }

    // Update is called once per frame
    void Update() {
        UpdateGamePlacementPose();
        UpdateGamePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            PlaceObject();
        }
    }

    void UpdateGamePlacementPose() {
        if (aRRaycastManager != null && Camera.current != null) {
            // shoot a raycast from the center of the screen
            Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

            placementPoseIsValid = false;

            // if we hit a AR plane, update the position and rotation 
            foreach (ARRaycastHit hit in hits) {
                ARPlane plane = aRPlaneManager.GetPlane(hit.trackableId);
                if (plane != null) {
                    placementPoseIsValid = true;
                    placementPose = hit.pose;

                    // rotate in view direction
                    Vector3 cameraForward = Camera.current.transform.forward * -1.0f;
                    Vector3 cameraBearing = new Vector3(cameraForward.x, 0.0f, cameraForward.z).normalized;
                    placementPose.rotation = Quaternion.LookRotation(cameraBearing);

                    break;
                }
            }
        }
    }

    void UpdateGamePlacementIndicator() {
        if (placementPoseIsValid) {
            IndicatorIcon.SetActive(true);
            transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else 
            IndicatorIcon.SetActive(false);
        }
    }

    void PlaceObject() {
        ObjectToPlace.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        ObjectToPlace.SetActive(true);
    }
}
```
3. Don’t forget to save your changes to the C# script file.
4. Connect the CubeObject object with the script: select the *PlacementIndicator* game object in the *Project* window, go to *Inspector* window, open the *Object To Place* dropdown and select *CubeObject*.

[Build](Docs/Build.md) again and test your changes. Once the placement indicator is visible, touch the screen. Every time you touch the screen the cube will appear at the position of the indicator.

### Unity Documentation
To learn more about the Unity scripting framework and the provided components check the following:
- Unity [Manual](https://docs.unity3d.com/Manual/index.html) and [Scripting API](https://docs.unity3d.com/ScriptReference/index.html).
- [AR Unity Samples](https://github.com/Unity-Technologies/arfoundation-samples) on GitHub. They are the best way to learn more about the current Unity AR possibilities. These samples are updated with each Unity version, therefore are always up-to-date.

## Create your character with Mixamo

In this step, we will replace the cube with a character. Creating a character by yourself and ensuring the it moves according to the physical system is quite complicated. We will therefore use a ready made character from [Mixamo](https://www.mixamo.com/). Mixamo provides animated 3D characters for games and films. You only need to create an account, login and then you can choose from around 120 characters and more than 2000 animations.

To import a character from Mixamo to Unity follow the steps below:

1. Go to the [Mixamo](https://www.mixamo.com/) web page and login.
2. Download a character from Mixamo: Select the *Character* tab, choose one of the characters and press *Download*. In the *Download Settings* dialog open the *Format* dropdown, select *FBX for Unity* and press the *Download* button. You can download the character to the default download folder.
3. Import the character to Unity: Go to *Unity Editor* and create a *Characters* folder under *Assets* in the *Project* window. Drag and drop the downloaded character to the newly created folder. Now drag and drop the character from the *Characters* folder in the *Project* window to the *Hierarchy* window. The character will appear in the *Scene* view. If you zoom in on the character in the *Scene* view, you will notice that the textures are not displayed. Let’s fix that: Select your character in the *Project* window, go to the *Inspector* window, select *Materials*, click on *Extract Textures…* and select the *Textures* folder. While extracting Unity will warn you about normal map and ask you, if it should fix it: press *Fix now*. If you check your character in the *Scene* view again, you will notice that the textures are displayed correctly.
4. Your character might be a bit dark, the *Directional Light* (the sun) might be pointing in the wrong direction. To change this: Select *Directional Light* in the *Hierarchy* window, go to the *Inspector* window and change the *Y*-value of the *Rotation* to adapt the light direction.

You can [build](Docs/Build.md) your application again, to double check that you can see the character you just added. Once you start the app on your mobile, the character will be added at Position (0,0,0), so basically at your position. You will have to move and point your mobile towards the position your were standing, to actually see your character.

The character is standing at an odd place, has an odd pose and is also quite big. In the next steps we will fix all that. Let’s start by replacing the cube and instead **spawn** the **character at** the **indicator position**:

1. Attach the character to the *PlacementIndicator* script: select the *PlacementIndicator* game object in the *Project* window, go to *Inspector* window, open the *Object To Place* dropdown and select your character. You can also delete the *CubeObject* now. We will not need it anymore.
2. Change the size of the character: Select your character in the *Characters* folder in the *Project* window, go to the *Inspector* window, select *Model*, change the value for *Scale Factor* to 0.4 and press *Apply*.

You can [build](Docs/Build.md) your application again, to check your changes. Instead of the cube, your character should now appear at the position of the indicator every time you touch the screen.

Next we will **add** an idle **animation to** the **character** to make it stand more natural.

1. Download an animation from Mixamo: Go back to the [Mixamo](https://www.mixamo.com/) web page. While your character is still selected, select the *Animations* tab, enter *Idle* in the search text field, select one of the idle animations and press *Download*. In the *Download Settings* dialog make sure that:
    1. *Format* is set to *FBX for Unity* and 
    2. *Skin* to *Without Skin*.
2. Import the animation to Unity:
    1. Drag and drop the downloaded animation to the *Characters* folder in *Project* window in the *Unity Editor*. 
    2. Select *Assets*, right click and select *Create* → *Animation Controller*. Rename the animation controller to *CharacterAnimationController*. 
    3. Select your character in the *Hierarchy* window, go to the *Inspector* window and add an *Animator* component. Open the *Controller* dropdown in the *Animator* component and select the *CharacterAnimationController*. 
    4. Next, double click on the *CharacterAnimationController* in the *Project* window. It will open the *Animator* window for this controller. Right click on the [gridded *Base Layer* area](https://docs.unity3d.com/2020.2/Documentation/Manual/AnimatorWindow.html), create a new state, using the *Empty* state. Rename this state to *Idle*. Open the dropdown for the *Motion* field in the *Inspector* window and select *Idle*. 
    5. To repeat this animation endlessly, select the animation in the *Project* window, go to *Inspector* window, enable *Loop Time* and press *Apply*.
    6. Select the animation for your character in the *Characters* folder in the *Project* window, then go to the *Inspector* window, select *Model*, change the value for *Scale Factor* to 0.4 and press *Apply*.

[Build](Docs/Build.md) your application again and check how your character behaves.

Now, we will add a **second animation**. This time, it will be an animation for walking. We will adapt the *PlacementIndicator* script so, that after the character is visible, the marker will disappear and a touch on the screen will make the character walk.

1. Download a walk animation from Mixamo: 
    1. Go back to the [Mixamo](https://www.mixamo.com/) web page. 
    2. While your character is still selected, select the *Animations* tab, search for *walk*, select one of the walk animations. 
    3. Before pressing *Download* make sure the animation is *In Place*. There is a *In Place* checkbox under the *Download* button. Set it. 
    4. Then press *Download*. In the *Download Settings* dialog set:
        1. *Format* to *FBX for Unity* and 
        2. *Skin* to *Without Skin*.
2. Import the walk animation to Unity:
    1. Drag and drop the downloaded animation to the *Characters* folder in *Project* window in the *Unity Editor*. 
    2. Next, double click on the *CharacterAnimationController* in the *Project* window to open the *Animator* window. Right click on the squared *Base Layer* area, create a new state, using the *Empty* state. Rename this state to *Walk*. Open the dropdown for the *Motion* field in the *Inspector* window and select the downloaded walk animation.
3. Create a transition between animations: 
    1. Go to the *Animator* window, right click on the *Idle* animation in the squared *Base Layer* area, select *Make Transition* and connect the transition (visible as an arrow) to the *Walk* animation in the squared *Base Layer* area. Now create another transition in the opposite direction, right click on the *Walk* animation in the squared *Base Layer* area, select *Make Transition* and connect the transition to the *Idle* animation in the squared *Base Layer* area. You should end up with a animation diagram similar to this: ![Transition Between Idle And Walk](Docs/Screenshots/Animation.Diagram.TransitionBetweenIdleAndWalk.png)
    2. Select one of the newly created transitions and disable the *Has Exit Time* option in the *Inspector* window. Do this for both transitions.
    3. In the *Animator* window, on the left are 2 tabs: *Layers* and *Parameters*. Select the *Parameters* tab, click on the *+* icon next to the text box and select *Bool*. Rename it to *IsWalking*. This is an boolean Animator parameter which we will use to enable and disble the *Walk* animation. ![Transition Between Idle And Walk - Bool](Docs/Screenshots/Animation.Diagram.TransitionBetweenIdleAndWalk-Bool.png)
    4. Select the transition from *Idle* to *Walk* in the in the squared *Base Layer* area, go to the Inspector window, scroll down to the *Conditions* section and select the + icon. It should automatically add the *IsWalking* parameter with value *true* to the *Conditions*: ![Transition Between Idle And Walk - Bool2](Docs/Screenshots/Animation.Diagram.TransitionBetweenIdleAndWalk-Bool2.png) Now, do the same for the transition between *Walk* and *Idle*, but set the condition to *false*.
4. Create a new C# script to control the switch between the *Idle* and *Walk* animation.
    1. First go to the *Scripts* folder under *Assets* in the *Hierarchy* window. Then right click on the folder, select *Create* → *C# Script* and rename it directly to *Movement*.
    2. Double click on the *Movement* script in the *Hierarchy* window to open it in *Visual Studio*. Replace the existing code with and save it: 
    ``` C#
    using UnityEngine;

    public class Movement : MonoBehaviour {
        Animator _animator;

        void Start() {
            _animator = GetComponent<Animator>();

            if (_animator == null) Debug.LogError("_animator is NULL");
        }

        void Update() {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                _animator.SetBool("IsWalking", !_animator.GetBool("IsWalking"));
            }
        }
    }
    ```

5. Add the *Movement* script to the character game object: Select your character in the *Hierarchy* window, go to the *Inspector* window, press *Add Component*, search for the *Movement* script and select it. Open the *Animator* dropdown and select your character. Now, your script is connected with the *Animator* and can access the Animation parameter we specified above.
6. There is still one thing we need to do: Change the behaviour in the *PlacementIndicator* script. You remember, it was placing the marker whenever you touch the screen. But now, we want that once the character is visible, the marker disappears, and the touch to control the character animation instead. The last part is already handled by the *Movement* script. Let's take care of the *PlacementIndicator* script. 
    1.  Double click on the *PlacementIndicator* script in the *Hierarchy* window to open it in *Visual Studio*.
    2. Add the following line at the end of the *PlaceObject* method to make the marker invisible after the object was placed:

    ``` C#
    IndicatorIcon.SetActive(false);
    ```
    3. Add an *if-statement* to the *Update* method to prevent from running when not needed:
    ```C#
    void Update() {
        if (!ObjectToPlace.activeInHierarchy) {
            UpdateGamePlacementPose();
            UpdateGamePlacementIndicator();

            if (placementPoseIsValid && Input.touchCount > 0 &&
                Input.GetTouch(0).phase == TouchPhase.Began) {
                PlaceObject();
            }
        }
    }
    ```
    4. Save the script.

Try your application again. You will notice that your character is walking, but walking in place. No wonder, this is how we downloaded it. As a next step, we will adapt the *Movement* script to **make the character move when the *Walk* animation** is running.

1. One way to controll the character movement is by using the *CharacterController* component. Therefore add *CharacterController* component to your character in the *hierarchy* window.
2. Now update the *Movement* script to use the *CharacterController* to make move your character forward:
```C#
using UnityEngine;

public class Movement : MonoBehaviour {
    float _speed = 0.5f;

    Animator _animator;
    CharacterController _controller;

    void Start() {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

        if (_animator == null) Debug.LogError("_animator is NULL");
        if (_controller == null) Debug.LogError("_controller is NULL");
    }

    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            _animator.SetBool("IsWalking", !_animator.GetBool("IsWalking"));
        }

        if (_animator.GetBool("IsWalking")) MoveForward();
    }

    void MoveForward() {
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * _speed;

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);
    }
}
```
3. Save the script.
4. Run your application and test the speed of your character. Adjust the speed value in the *Movement* script to align forward movement of your character with the *Walk* animation and make it feel natural.

[![Movement Forward Video](http://img.youtube.com/vi/eL_8jF1a4lk/0.jpg)](http://www.youtube.com/watch?v=eL_8jF1a4lk)

## Upcoming tutorials
- Mobile UI elements
- Sound
- Speech recongnition