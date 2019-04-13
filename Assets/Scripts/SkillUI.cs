using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private BaseHero target;


    public void SetTarget(BaseHero _target) {
        target = _target;
        transform.position = target.GetBuildPosition();

        //sellAmount.text = "E " + target.heroBlueprint.GetSellAmount();
    }

    public void Show() {
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }


    public bool IsActive { get { return ui.activeSelf; } }


    public void UseSkill() {
        target.UseSkill();
    }

    //public void Sell() {
    //    target.SellTurret();
    //    BuildManager.instance.DeselectNode();
    //}
}
