using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ShowHide : MonoBehaviour {
    public List<Image> imgs;
    public int Flashcount = 100;
    public bool IsHide;
    BuildManager buildManager;
    private void Start() {
        buildManager = BuildManager.instance;
        foreach (Image img in imgs) {
            StartCoroutine(Flash(img));
        }

    }

    IEnumerator Flash(Image img) {
        while (buildManager.buildHerosNumber == 0) {

            yield return new WaitForSeconds(0.7f);
            if (buildManager.buildHerosNumber > 0) {
                break;
            }
            img.color = new Color(0.5f, 0.5f, 0.5f);

            yield return new WaitForSeconds(0.7f);
            if (buildManager.buildHerosNumber > 0) {
                break;
            }
            img.color = new Color(1f, 1f, 1f);


        }
    }

}