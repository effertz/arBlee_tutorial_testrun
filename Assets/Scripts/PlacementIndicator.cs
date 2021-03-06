﻿using System.Collections.Generic;
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
        if (ObjectToPlace == null) Debug.LogError("objectToPlace is NULL");
    }

    // Update is called once per frame
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

    void UpdateGamePlacementIndicator()
    {
        if (placementPoseIsValid) {
            IndicatorIcon.SetActive(true);
            transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else {
            IndicatorIcon.SetActive(false);
        }
    }

    void PlaceObject() {
        ObjectToPlace.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        ObjectToPlace.SetActive(true);
        IndicatorIcon.SetActive(false);
    }
}