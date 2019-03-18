using UnityEngine;

public class HeroPool : MonoBehaviour {

    public TurretBlueprint knight;
    public TurretBlueprint archor;
    public TurretBlueprint fireMage;
    public TurretBlueprint iceMage;
    public TurretBlueprint priest;

    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectKnight() {
        Debug.Log("Knight Selected");
        buildManager.SelectTurretToBuild(knight);
    }

    public void SelectArchor() {
        Debug.Log("Archor Selected");
        buildManager.SelectTurretToBuild(archor);
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
