using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPool : MonoBehaviour {

    public HeroBlueprint knight;
    public HeroBlueprint archer;
    public HeroBlueprint fireMage;
    public HeroBlueprint iceMage;
    public HeroBlueprint priest;

    Hashtable hashTable = new Hashtable();  // <Item name, HeroBlueprint>


    void Start() {
        hashTable.Add("KnightItem", knight);
        hashTable.Add("ArcherItem", archer);
        hashTable.Add("FireMageItem", fireMage);
        hashTable.Add("IceMageItem", iceMage);
        hashTable.Add("PriestItem", priest);
        InvokeRepeating("UpdateImageStatus", 0f, 0.3f);
    }


    void UpdateImageStatus() {
        //Debug.Log("UpdateImageStatus");
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

}
