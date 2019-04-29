using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPool : MonoBehaviour {
    public static HeroPool instance;

    public HeroBlueprint knight;
    public HeroBlueprint archer;
    public HeroBlueprint fireMage;
    public HeroBlueprint iceMage;
    public HeroBlueprint priest;

    Hashtable hashTable = new Hashtable();  // <Item name, HeroBlueprint>

    private BaseHero knightObj;
    private BaseHero archerObj;
    private BaseHero fireMageObj;
    private BaseHero iceMageObj;
    private BaseHero priestObj;


    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one HeroPool in scene!");
            return;
        }
        instance = this;
    }


    public static HeroPool GetInstance() {
        return instance;
    }


    void Start() {
        hashTable.Add("KnightItem", knight);
        hashTable.Add("ArcherItem", archer);
        hashTable.Add("FireMageItem", fireMage);
        hashTable.Add("IceMageItem", iceMage);
        hashTable.Add("PriestItem", priest);

        InvokeRepeating("UpdateImageStatus", 0f, 0.3f);
    }


    void UpdateImageStatus() {
        //Logger.Log("UpdateImageStatus");
        foreach (HeroBlueprint blueprint in hashTable.Values) {
            string heroName = blueprint.prefab.name;
            Image heroImage = GameObject.Find(heroName + "Item").GetComponent<Image>();
            if (PlayerStats.Energy < blueprint.cost || blueprint.hasBuilt) {
                heroImage.color = new Color(0.5f, 0.5f, 0.5f);
            } else {
                heroImage.color = new Color(1f, 1f, 1f);
            }
        }
    }


    public HeroBlueprint GetBlueprintByName(String itemName) {
        return (HeroBlueprint)hashTable[itemName];
    }


    public void SetHero(BaseHero _target, String heroName) {
        //Logger.Log("SetHero: " + heroName.ToUpper() + ", " + _target);
        switch (heroName) {
            case CommonConfig.Knight:
                knightObj = _target; break;
            case CommonConfig.Archer:
                archerObj = _target; break;
            case CommonConfig.FireMage:
                fireMageObj = _target; break;
            case CommonConfig.IceMage:
                iceMageObj = _target; break;
            case CommonConfig.Priest:
                priestObj = _target; break;
            default:
                Logger.Log("In SetHero, no heroName"); break;
        }
    }


    public void UseKnightSkill() {
        if (knightObj == null) {
            Logger.Log("knightObj is null, cannot use skill");
            return;
        }
        knightObj.UseSkill();
    }


    public void UseArcherSkill() {
        if (archerObj == null) {
            Logger.Log("archerObj is null, cannot use skill");
            return;
        }
        archerObj.UseSkill();
    }


    public void UseFireMageSkill() {
        if (fireMageObj == null) {
            Logger.Log("fireMageObj is null, cannot use skill");
            return;
        }
        fireMageObj.UseSkill();
    }


    public void UseIceMageSkill() {
        if (iceMageObj == null) {
            Logger.Log("iceMageObj is null, cannot use skill");
            return;
        }
        iceMageObj.UseSkill();
    }


    public void UsePriestSkill() {
        if (priestObj == null) {
            Logger.Log("priestObj is null, cannot use skill");
            return;
        }
        priestObj.UseSkill();
    }
}
