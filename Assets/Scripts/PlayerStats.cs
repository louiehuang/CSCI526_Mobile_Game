using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    //As time goes by, player gains energy used to summon heroes
    public static int Energy;
    public int startEnergy = 50;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start() {
        Energy = startEnergy;
        Lives = startLives;

        Rounds = 0;
    }

}
