using UnityEngine;

public class DragObject : MonoBehaviour {
    Transform myTransform;
    Vector3 selfScenePosition;
    Vector3 previousScenePosition;


    void Start() {
        myTransform = transform;
        // Change self pos to screen pos
        selfScenePosition = Camera.main.WorldToScreenPoint(myTransform.position);
        //print("scenePosition   :  " + selfScenePosition);
    }

    void OnMouseDrag() {
        //print(Input.mousePosition.x + "     y  " + Input.mousePosition.y + "     z  " + Input.mousePosition.z);

        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);

        // Change screen pos to world pos
        Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
        Vector3 previousWorldPosition = Camera.main.ScreenToWorldPoint(previousScenePosition);

        crrrentWorldPosition.y = transform.localPosition.y;
        crrrentWorldPosition.x = crrrentWorldPosition.x - previousWorldPosition.x + transform.localPosition.x;
        crrrentWorldPosition.z = crrrentWorldPosition.z - previousWorldPosition.z + transform.localPosition.z;

        // Set obj pos to mouse' world pos
        myTransform.position = crrrentWorldPosition;

        previousScenePosition = currentScenePosition;
    }

    void OnMouseDown() {
        previousScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
    }

    void OnMouseUp() {
    }

    void OnMouseEnter() {
    }

    void OnMouseExit() {
    }
}