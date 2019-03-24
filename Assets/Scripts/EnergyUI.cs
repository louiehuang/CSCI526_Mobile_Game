using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour {

    public Text energyText;

    // Update is called once per frame
    void Update() {
        energyText.text = "E " + PlayerStats.Energy.ToString();
    }
}
