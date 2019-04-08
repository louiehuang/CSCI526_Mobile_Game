using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {
    Transform myTransform;
    Vector3 selfScenePosition;

    void Start() {
        myTransform = transform;
        //将自身坐标转换为屏幕坐标
        selfScenePosition = Camera.main.WorldToScreenPoint(myTransform.position);
        print("scenePosition   :  " + selfScenePosition);
    }

    void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
    {
        //获取拖拽点鼠标坐标
        print(Input.mousePosition.x + "     y  " + Input.mousePosition.y + "     z  " + Input.mousePosition.z);
        //新的屏幕点坐标
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
        //将屏幕坐标转换为世界坐标
        Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
        crrrentWorldPosition.y = transform.localPosition.y;
        //设置对象位置为鼠标的世界位置
        myTransform.position = crrrentWorldPosition;
    }

    //void OnMouseDrag() {
    //    print("鼠标拖动该模型区域时");
    //}

    void OnMouseDown() {
        print("鼠标按下时");
    }

    void OnMouseUp() {
        print("鼠标抬起时");
    }

    void OnMouseEnter() {
        print("鼠标进入该对象区域时");
    }

    void OnMouseExit() {
        print("鼠标离开该模型区域时");


    }
}