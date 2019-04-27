using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameContoller : MonoBehaviour {

	public Image darkness;

	void Start () {
		darkness.enabled = true;
		darkness.CrossFadeAlpha(1, 0, false);
		darkness.CrossFadeAlpha(0, 0.5f, false);	
	}

	public void resetLevel()
	{
		darkness.CrossFadeAlpha(1, 0.5f, false);
		StartCoroutine(reload());		
	}

	public IEnumerator reload()
	{
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel(Application.loadedLevelName);
	}
	

}
