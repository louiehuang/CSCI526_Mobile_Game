using UnityEngine;
using UnityEngine.UI;

public class HeroItemUI : MonoBehaviour {
    public Image itemImage;

    public void GrayOut() {
        itemImage.color = new Color(0.3f, 0.4f, 0.6f);
    }
}
