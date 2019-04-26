using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowHide : MonoBehaviour {
    public List<Image> imgs;
    public int Flashcount;
    public bool IsHide;

    private void Start() {
        foreach (Image img in imgs) {
            StartCoroutine(Flash(img, Flashcount, IsHide));
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


}