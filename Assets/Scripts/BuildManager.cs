using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public bool hasDraged = false;
    public int buildHerosNumber = 0;
    public List<GameObject> InstruList;
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    void Start() {
        StartCoroutine(closeInstruction());
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    IEnumerator closeInstruction() {
        while (buildHerosNumber == 0) {
            yield return new WaitForSeconds(0.1f);
        }
        foreach(GameObject gameObject in InstruList) {
            gameObject.SetActive(false);
        }

        yield return null;
    }

}
