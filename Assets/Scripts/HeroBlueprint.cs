using UnityEngine;
using System.Collections;

[System.Serializable]
public class HeroBlueprint {

    public GameObject prefab;
    public int cost;

    public int GetSellAmount() {
        return (int) (0.4 * cost);
    }
}
