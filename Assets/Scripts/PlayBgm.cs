using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgm : MonoBehaviour
{
    public GameObject bgmPrefab;
    public GameObject bgmInstance = null;
    // Use this for initialization
    void Start() {
        bgmInstance = GameObject.FindGameObjectWithTag("Sound");
        if (bgmInstance == null) {
            bgmInstance = (GameObject)Instantiate(bgmPrefab);
        }

    }

    // Update is called once per frame
    void Update() {

    }

}
