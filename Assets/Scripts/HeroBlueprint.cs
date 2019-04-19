using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class HeroBlueprint {

    public GameObject prefab;
    public int cost;
    public bool hasBuilt = false;


    public int GetSellAmount() {
        return (int) (0.4 * cost);
    }

}
