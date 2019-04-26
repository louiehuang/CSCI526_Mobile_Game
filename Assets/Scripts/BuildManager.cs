using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public bool hasDraged = false;
    public int buildHerosNumber = 0;
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

}
