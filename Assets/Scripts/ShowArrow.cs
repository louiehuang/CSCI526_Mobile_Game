using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShowArrow : MonoBehaviour {
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    private Sprite[] imgs;
    Image curImg;
    public int FlashCount;
    public bool IsHead;

    BuildManager buildManager;
    void Start() {
        imgs = new Sprite[3];
        imgs[0] = img1;
        imgs[1] = img2;
        imgs[2] = img3;
        buildManager = BuildManager.instance;
        curImg = gameObject.GetComponent<Image>();
        StartCoroutine(ImageFlash(FlashCount, IsHead));
    }


    IEnumerator ImageFlash(int flashCount, bool isHide) {
        while(buildManager.buildHerosNumber == 0) {
            foreach(Sprite img in imgs) {

                curImg.sprite = img;
                //Debug.Log(curImg.name);
                yield return new WaitForSeconds(0.5f);
            }


        }

        gameObject.SetActive(!isHide);
    }
}