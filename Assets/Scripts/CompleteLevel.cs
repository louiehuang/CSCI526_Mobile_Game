using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    public string menuSceneName = "MainMenu";

    public string nextLevel = "LevelSelect";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Continue() {
        Logger.Log(nextLevel);
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo("AcquireEquipment");
    }

    public void Menu() {
        sceneFader.FadeTo(menuSceneName);
    }

}
