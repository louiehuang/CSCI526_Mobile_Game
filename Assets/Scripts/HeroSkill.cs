using UnityEngine;
using UnityEngine.UI;

public class HeroSkill : MonoBehaviour {
    private BaseHero target;
    public Image image;
    private float timer;
    private float cooldownTime = 3f;

    public void SetTarget(BaseHero _target) {
        target = _target;
    }

    public void UseSkill() {
        target.UseSkill();
    }

    void Update() {
        timer += Time.deltaTime;
        image.fillAmount = (cooldownTime - timer) / cooldownTime;

    }

}
