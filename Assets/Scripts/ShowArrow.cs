using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowArrow : MonoBehaviour {
    public List<Sprite> imgs;
    Image curImg;
    public int FlashCount;
    public bool IsHead;

    BuildManager buildManager;
    void Start() {

        buildManager = BuildManager.instance;
        curImg = gameObject.GetComponent<Image>();
        StartCoroutine(ImageFlash(FlashCount, IsHead));
    }


    IEnumerator ImageFlash(int flashCount, bool isHide) {
        while(buildManager.buildHerosNumber == 0) {
            foreach(Sprite img in imgs) {

                curImg.sprite = img;
                //Logger.Log(curImg.name);
                yield return new WaitForSeconds(0.5f);
            }


        }

        gameObject.SetActive(!isHide);
    }
}