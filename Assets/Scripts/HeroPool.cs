using UnityEngine;

public class HeroPool : MonoBehaviour {

    public TurretBlueprint priest;
    public TurretBlueprint fireMage;
    public TurretBlueprint iceMage;

    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectFireMage() {
        Debug.Log("Fire Mage Selected");
        buildManager.SelectTurretToBuild(fireMage);
    }

    public void SelectIceMage() {
        Debug.Log("Ice Mage Selected");
        buildManager.SelectTurretToBuild(iceMage);
    }

    public void SelectPriest() {
        Debug.Log("Priest Selected");
        buildManager.SelectTurretToBuild(priest);
    }
}
