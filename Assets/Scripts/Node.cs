using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject hero;  //the hero on this node
    [HideInInspector]
    public HeroBlueprint heroBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Debug.Log("hero: " + hero);

        //TODO: bind skill bar with hero instead of node
        if (hero != null) {
            //buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(HeroBlueprint blueprint) {
        if (PlayerStats.Energy < blueprint.cost) {
            Debug.Log("Not enough energy to summon that!");
            return;
        }

        PlayerStats.Energy -= blueprint.cost;

        hero = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        heroBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        string heroName = blueprint.prefab.name;
        Image heroImage = GameObject.Find(heroName + "Item").GetComponent<Image>();
        heroImage.color = new Color(0.5f, 0.5f, 0.5f);

        Debug.Log("Hero " + heroName + " Summoned!");
    }

    public void UseHeroSkill() {
        BaseHero h = hero.GetComponent<BaseHero>();
        h.UseSkill();
    }


    public void SellTurret() {
        PlayerStats.Energy += heroBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(hero);
        heroBlueprint = null;
    }

    void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Debug.Log(transform.name + " OnMouseEnter");
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasEnergy) {
            rend.material.color = hoverColor;
        } else {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

}
