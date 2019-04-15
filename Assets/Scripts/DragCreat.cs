using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCreat : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    GameObject go;
    public HeroPool heroPool;
    Vector3 selfScenePosition;
    HeroBlueprint bluePrint;

    //地形所在平面
    public SceneFader sceneFader;

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag " + gameObject.name);
        bluePrint  = heroPool.GetBlueprintByName(gameObject.name);
        go = BuildTurret(bluePrint);
        Debug.Log("OnDrag");
        if (go != null) {
            Debug.Log("go != null start drag");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                go.transform.position = hit.point;
                selfScenePosition = Camera.main.WorldToScreenPoint(go.transform.position);
            } else {
                go = null;
            }

        }

    }

    public void OnDrag(PointerEventData eventData) {

        if(go == null) {
            return;
        }

        //新的屏幕点坐标
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);

        //将屏幕坐标转换为世界坐标

        Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);

        crrrentWorldPosition.y = transform.localPosition.y;

        //设置对象位置为鼠标的世界位置
        go.transform.position = crrrentWorldPosition;


    }
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        if(go == null) {
            return;
        }

        float x = go.transform.position.x;
        float z = go.transform.position.z;

        if(x < sceneFader.MinX || x > sceneFader.MaxX || z < sceneFader.MinZ || z > sceneFader.MaxZ) {
            Destroy(go);
            return;
        }

        PlayerStats.Energy -= bluePrint.cost;
        bluePrint.hasBuilt = true;
    }
    // Use this for initialization
    void Start() {
        //Name = transform.FindChild("Text").GetComponent<Text>();
    }

    GameObject BuildTurret(HeroBlueprint blueprint) {
        if (blueprint == null || PlayerStats.Energy < blueprint.cost || bluePrint.hasBuilt) {
            Debug.Log("Not enough energy to summon that!");
            return null;
        }



        GameObject hero = (GameObject)Instantiate(blueprint.prefab);



        Debug.Log("Hero " + blueprint.prefab.name + " Summoned!");

        return hero;
    }

}
