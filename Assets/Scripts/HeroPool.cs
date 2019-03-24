using UnityEngine;

public class HeroPool : MonoBehaviour {

    public HeroBlueprint knight;
    public HeroBlueprint archer;
    public HeroBlueprint fireMage;
    public HeroBlueprint iceMage;
    public HeroBlueprint priest;

    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectKnight() {
        Debug.Log("Knight Selected");
        buildManager.SelectTurretToBuild(knight);
    }

    public void SelectArcher() {
        Debug.Log("Archer Selected");
        buildManager.SelectTurretToBuild(archer);
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
