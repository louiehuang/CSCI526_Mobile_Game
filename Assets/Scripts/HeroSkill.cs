using UnityEngine;
using UnityEngine.UI;

public class HeroSkill : MonoBehaviour {
    private BaseHero target;

    public void SetTarget(BaseHero _target) {
        target = _target;
    }

    public void UseSkill() {
        target.UseSkill();
    }

    void OnMouseDown() {
        Debug.Log("target: " + target);
    }
}
