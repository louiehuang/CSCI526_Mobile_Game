using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour{
    Transform myTransform;
    Vector3 selfScenePosition;
    Vector3 previousScenePosition;


    void Start() {
        myTransform = transform;
        //将自身坐标转换为屏幕坐标
        selfScenePosition = Camera.main.WorldToScreenPoint(myTransform.position);
        //print("scenePosition   :  " + selfScenePosition);
    }
    void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
    {
        //获取拖拽点鼠标坐标
        //print(Input.mousePosition.x + "     y  " + Input.mousePosition.y + "     z  " + Input.mousePosition.z);

        //新的屏幕点坐标
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);

        //将屏幕坐标转换为世界坐标
           
        Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
        Vector3 previousWorldPosition = Camera.main.ScreenToWorldPoint(previousScenePosition);

        crrrentWorldPosition.y = transform.localPosition.y;
        crrrentWorldPosition.x = crrrentWorldPosition.x - previousWorldPosition.x + transform.localPosition.x;
        crrrentWorldPosition.z = crrrentWorldPosition.z - previousWorldPosition.z + transform.localPosition.z;
        //设置对象位置为鼠标的世界位置
        myTransform.position = crrrentWorldPosition;

        previousScenePosition = currentScenePosition;
    }

    void OnMouseDown() {
        print("鼠标按下时");
        previousScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
    }


}