using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCreat : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    GameObject go;
    public HeroPool heroPool;
    Vector3 selfScenePosition;
    HeroBlueprint bluePrint;
    public LayerMask mask = 1 << 8;
    BuildManager buildManager;
    //地形所在平面
    public SceneFader sceneFader;

    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("OnBeginDrag " + gameObject.name);
        bluePrint  = heroPool.GetBlueprintByName(gameObject.name);
        go = BuildTurret(bluePrint);
        //Debug.Log("OnDrag");
        buildManager.hasDraged = true;
        if (go != null) {
            //Debug.Log("go != null start drag");
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
        if (go == null) {
            return;
        }

        if (go != null) {
            //Debug.Log("go != null start drag");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, mask)) {
                Debug.DrawLine(ray.origin, hit.point);
                go.transform.position = hit.point;
                //Vector3 currentScenePosition = Camera.main.WorldToScreenPoint(go.transform.position);
                //Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
                //go.transform.position = crrrentWorldPosition;
            } else {

            }
        }
    }


    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("OnEndDrag");
        buildManager.hasDraged = false;
        if (go == null) {
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
        buildManager = BuildManager.instance;
    }


    GameObject BuildTurret(HeroBlueprint blueprint) {
        if (blueprint == null || PlayerStats.Energy < blueprint.cost || bluePrint.hasBuilt) {
            Debug.Log("Not enough energy to summon that!");
            return null;
        }

        GameObject hero = (GameObject)Instantiate(blueprint.prefab);
        Debug.Log("Hero " + blueprint.prefab.name + " Summoned!");

        BaseHero baseHero = hero.GetComponent<BaseHero>();
        baseHero.hero = hero;
        baseHero.heroBlueprint = blueprint;

        return hero;
    }

}
