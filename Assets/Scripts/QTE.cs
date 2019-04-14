using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour {

    public GameObject qteObject;
    public static int timesDone;


    private void OnTriggerEnter() {
        qteObject.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
    }


    void Update() {
        if (timesDone == 3) {
            qteObject.SetActive(false);



        }
    }
}
