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

    IEnumerator Flash(Image img, int flashCount, bool isHide) {
        for (int i = 0; i < flashCount; i++) {
            img.color = new Color(0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.3f);
            img.color = new Color(1f, 1f, 1f);
            yield return new WaitForSeconds(0.3f);

        }
        gameObject.active = !isHide;
    }
    IEnumerator Flash(Image img) {
        while (buildManager.buildHerosNumber == 0) {

            yield return new WaitForSeconds(0.7f);
            img.color = new Color(0.5f, 0.5f, 0.5f);

            yield return new WaitForSeconds(0.7f);
            img.color = new Color(1f, 1f, 1f);
            if (buildManager.buildHerosNumber > 0) {
                break;
            }

        }
        //img.color = new Color(1f, 1f, 1f);
    }
    //IEnumerator Flash(Image img, bool isHide) {
    //    while (buildManager.buildHerosNumber == 0) {
    //        yield return new WaitForSeconds(0.7f);
    //        img.color = new Color(0.5f, 0.5f, 0.5f);

    //        yield return new WaitForSeconds(0.7f);
    //        img.color = new Color(1f, 1f, 1f);

    //        if (buildManager.buildHerosNumber > 0) {
    //            break;
    //        }

    //    }
    //    img.color = new Color(1f, 1f, 1f);
    //    gameObject.active = !isHide;
    //}
}