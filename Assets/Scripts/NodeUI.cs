using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target) {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded) {
            //upgradeCost.text = "E " + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        } else {
            //upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "E " + target.heroBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void UseSkill() {
        target.UseHeroSkill();
    }

    public void Sell() {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
