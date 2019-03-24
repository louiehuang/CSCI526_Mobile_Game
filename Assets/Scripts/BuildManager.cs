using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private HeroBlueprint heroToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return heroToBuild != null; } }
    public bool HasEnergy { get { return PlayerStats.Energy >= heroToBuild.cost; } }

    public void SelectNode(Node node) {
        if (selectedNode == node) {
            DeselectNode();
            return;
        }

        selectedNode = node;
        heroToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }


    public void SelectTurretToBuild(HeroBlueprint hero) {
        heroToBuild = hero;
        DeselectNode();
    }

    public HeroBlueprint GetTurretToBuild() {
        return heroToBuild;
    }

}
