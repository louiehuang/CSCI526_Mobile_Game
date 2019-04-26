using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHideText : MonoBehaviour {
    public Text text;
    Color color;
    public int Flashcount;
    public bool IsHide;
    private void Start() {
        text = gameObject.GetComponent<Text>();
         color = text.color;
        StartCoroutine(Flash(Flashcount, IsHide));
    }

    IEnumerator Flash(int flashCount, bool isHide) {
        for (int i = 0; i < flashCount; i++) {
            text.color = new Color(1f, 1f, 1f);
            yield return new WaitForSeconds(0.3f);
            text.color = color;
            yield return new WaitForSeconds(0.3f);

        }
        gameObject.active = !isHide;
    }
}