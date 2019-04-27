using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;


    void Start() {
        GameIsOver = false;

        StartCoroutine("IncreaseEnergyOverTime");
    }


    IEnumerator IncreaseEnergyOverTime() {
        float delay = 1f;
        while (PlayerStats.Energy <= 99) {
            yield return new WaitForSeconds(delay);
            PlayerStats.Energy += 1;
        }
    }


    // Update is called once per frame
    void Update() {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0 || PlayerStats.deadHeroNumber >= 5) {
            EndGame();
        }
    }


    void EndGame() {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }


    public void WinLevel() {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

}
