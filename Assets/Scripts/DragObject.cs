using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour{
    Transform myTransform;
    Vector3 selfScenePosition;
    private BuildManager buildManager;
    Vector3 previousScenePosition;

    Vector3 offSetWorldPosition;
    public LayerMask mask = 1 << 8;

    void Start() {
        myTransform = transform;
        //将自身坐标转换为屏幕坐标
        selfScenePosition = Camera.main.WorldToScreenPoint(myTransform.position);
        buildManager = BuildManager.instance;
    }


    void OnMouseDrag() {  //鼠标拖拽时系统自动调用该方法
        if (myTransform == null) {
            return;
        }

        if (myTransform != null) {
            //Logger.Log("go != null start drag");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, mask)) {
                Debug.DrawLine(ray.origin, hit.point);
                //myTransform.transform.position = hit.point;
                Vector3 currentScenePosition = Camera.main.WorldToScreenPoint(hit.point);
                //Vector3 previousWorldPosition = Camera.main.ScreenToWorldPoint(previousScenePosition);

                Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
                //crrrentWorldPosition.y = transform.localPosition.y;
                    //crrrentWorldPosition.x = crrrentWorldPosition.x - previousWorldPosition.x + transform.localPosition.x;
                    //crrrentWorldPosition.z = crrrentWorldPosition.z - previousWorldPosition.z + transform.localPosition.z;

                myTransform.position = crrrentWorldPosition + offSetWorldPosition;
                //previousScenePosition = currentScenePosition;

                //go.transform.position = crrrentWorldPosition;
            } else {

            }
        }
    }


    void OnMouseDown() {
        //print("OnMouseDown");
        buildManager.hasDraged = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 500, mask)) {
            Debug.DrawLine(ray.origin, hit.point);
            //myTransform.transform.position = hit.point;
            Vector3 currentScenePosition = Camera.main.WorldToScreenPoint(hit.point);
            //Vector3 previousWorldPosition = Camera.main.ScreenToWorldPoint(previousScenePosition);

            Vector3 crrrentWorldPosition = transform.localPosition;

            offSetWorldPosition = crrrentWorldPosition - hit.point;
        } else {

        }
    }

    void OnMouseUp() {
        buildManager.hasDraged = false;
    }

}