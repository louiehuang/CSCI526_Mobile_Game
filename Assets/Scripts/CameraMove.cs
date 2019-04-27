using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float distance = 10f;
    public float scaleFactor = 1f;

    private float maxDistance = 10f;
    private float minDistance = float.MinValue;

    //record the last postion of user
    private Vector2 oldPosition1; 
    private Vector2 oldPosition2;

    private Vector2 lastSingleTouchPosition;

    private Vector3 mCameraOffset;
    private BuildManager buildManager;
    private Camera mCamera;

    //the range that the camera works within
    public float xMin = -100;
    public float xMax = 100;
    public float zMin = -100;
    public float zMax = 100;

    //ONE or TWO fingers?
    private bool isSingleFinger;

    void Start() {
        mCamera = this.GetComponent<Camera>();
        mCameraOffset = mCamera.transform.position;
        buildManager = BuildManager.instance;
    }

    void Update() {
        if (Input.touchCount == 1) {
            if (buildManager.hasDraged) {
                return;
            }
            Touch touch = Input.GetTouch(0);
            //from 0 fingers to 1 finger || from 2 fingers to 1 finger
            if (touch.phase == TouchPhase.Began || !isSingleFinger) {
                lastSingleTouchPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Moved) {
                Vector3 lastTouchPosition = mCamera.ScreenToWorldPoint(new Vector3(lastSingleTouchPosition.x, lastSingleTouchPosition.y, -1));
                Vector3 currentTouchPosition = mCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -1));

                Vector3 v = currentTouchPosition - lastTouchPosition;
                mCameraOffset += new Vector3(v.x, 0, v.z) * mCamera.transform.position.y;
                //restrict the range of camera
                mCameraOffset = new Vector3(Mathf.Clamp(mCameraOffset.x, xMin, xMax), mCameraOffset.y, Mathf.Clamp(mCameraOffset.z, zMin, zMax));
                lastSingleTouchPosition = touch.position;
            }

            isSingleFinger = true;
        } else if (Input.touchCount > 1) {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            oldPosition1 = touch1.position - touch1.deltaPosition;
            oldPosition2 = touch2.position - touch2.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (oldPosition1 - oldPosition2).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Otherwise change the field of view based on the change in distance between the touches.
            distance += deltaMagnitudeDiff * scaleFactor * Time.deltaTime;

            // Clamp the field of view to make sure it's between minDistance & maxDistance.
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            isSingleFinger = false;
        }
    }

    //update the position of the camera after Update()
    void LateUpdate() {
        var position = mCameraOffset + mCamera.transform.forward * (-distance);
        mCamera.transform.position = position;
    }
}
