using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;

    public void Play() {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit() {
        Logger.Log("Exciting...");
        Application.Quit();
    }

}
