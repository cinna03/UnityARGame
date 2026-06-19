using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARPlacement : MonoBehaviour
{
    public GameObject gameWorldRoot;

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;

    private bool isPlaced = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = FindAnyObjectByType<ARRaycastManager>();
        planeManager = FindAnyObjectByType<ARPlaneManager>();
    }

    void Update()
    {
        if (isPlaced) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    PlaceGame(hitPose);
                }
            }
        }
    }

    void PlaceGame(Pose pose)
    {
        gameWorldRoot.transform.position = pose.position;

        isPlaced = true;

        // ✅ Disable plane detection visuals
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        planeManager.enabled = false;

        Debug.Log("Game Placed ✅");

        // ✅ Start game AFTER placement
        GameManager.Instance.StartGame();
    }
}
