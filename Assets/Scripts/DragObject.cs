using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour{
    Transform myTransform;
    Vector3 selfScenePosition;
    Vector3 previousScenePosition;

    Vector3 offSetWorldPosition;
    public LayerMask mask = 1 << 8;

    void Start() {
        myTransform = transform;
        //将自身坐标转换为屏幕坐标
        selfScenePosition = Camera.main.WorldToScreenPoint(myTransform.position);
        //print("scenePosition   :  " + selfScenePosition);
    }
    //void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
    //{
    //    //获取拖拽点鼠标坐标
    //    //print(Input.mousePosition.x + "     y  " + Input.mousePosition.y + "     z  " + Input.mousePosition.z);

    //    //新的屏幕点坐标
    //    Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);

    //    //将屏幕坐标转换为世界坐标

    //    Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
    //    Vector3 previousWorldPosition = Camera.main.ScreenToWorldPoint(previousScenePosition);

    //    crrrentWorldPosition.y = transform.localPosition.y;
    //    crrrentWorldPosition.x = crrrentWorldPosition.x - previousWorldPosition.x + transform.localPosition.x;
    //    crrrentWorldPosition.z = crrrentWorldPosition.z - previousWorldPosition.z + transform.localPosition.z;
    //    //设置对象位置为鼠标的世界位置
    //    myTransform.position = crrrentWorldPosition;

    //    previousScenePosition = currentScenePosition;
    //}


    void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
{
        if (myTransform == null) {
            return;
        }


        if (myTransform != null) {
            Debug.Log("go != null start drag");
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


    //void OnMouseDown() {
    //    print("鼠标按下时");
    //    previousScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);

    //}

    void OnMouseDown() {
        print("鼠标按下时");
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


}