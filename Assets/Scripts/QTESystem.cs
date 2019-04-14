using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QTESystem : MonoBehaviour {

    public Button QTEPrefab;
    //public Canvas Canvas;
    public Transform QTEPannel;

    //public GameObject DisplayBox;
    //public GameObject PassBox;
    //public int QTEGen;
    //public int WaitingForKey;
    //public int CorrectKey;
    //public int CountingDown;

    private void Start() {
        CreateQTEButton();

    }


    public Button CreateQTEButton() {
        Debug.Log("CreateQTEButton");
        var button = Instantiate(QTEPrefab, Vector3.zero, Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);



        //rectTransform.anchorMax = new Vector2(0.5f, 0.5f); // cornerTopRight;
        //rectTransform.anchorMin = new Vector2(0.5f, 0.5f); // cornerBottomLeft;
        //rectTransform.offsetMax = Vector2.zero;
        //rectTransform.offsetMin = Vector2.zero;

        return button;
    }


    //void Update() {
    //    if (WaitingForKey == 0) {
    //        QTEGen = Random.Range(1, 2);
    //        CountingDown = 1;

    //        //TODO create button
    //        CreateQTEButton();

    //        StartCoroutine(CountDown());

    //        if (QTEGen == 1) {
    //            WaitingForKey = 1;
    //            DisplayBox.GetComponent<Text>().text = "E";
    //        }
    //    }

    //    if (QTEGen == 1) {
    //        if (Input.anyKeyDown) { 
    //            if (Input.GetButtonDown("EKey")) {
    //                CorrectKey = 1;
    //            } else {
    //                CorrectKey = 2;
    //            }
    //            StartCoroutine(KeyPressing());
    //        }
    //    }
    //}


    //IEnumerator KeyPressing() {
    //    QTEGen = 4;
    //    if (CorrectKey == 1) {
    //        CountingDown = 2;
    //        PassBox.GetComponent<Text>().text = "Pass";
    //        yield return new WaitForSeconds(1.5f);

    //        CorrectKey = 0;
    //        PassBox.GetComponent<Text>().text = "";
    //        DisplayBox.GetComponent<Text>().text = "";
    //        yield return new WaitForSeconds(1.5f);
    //        WaitingForKey = 0;
    //        CountingDown = 1;
    //    }

    //    if (CorrectKey == 2) {
    //        CountingDown = 2;
    //        PassBox.GetComponent<Text>().text = "Fail";
    //        yield return new WaitForSeconds(1.5f);

    //        CorrectKey = 0;
    //        PassBox.GetComponent<Text>().text = "";
    //        DisplayBox.GetComponent<Text>().text = "";
    //        yield return new WaitForSeconds(1.5f);
    //        WaitingForKey = 0;
    //        CountingDown = 1;
    //    }
    //}


    //IEnumerator CountDown() {
    //    yield return new WaitForSeconds(3.5f);
    //    if (CountingDown == 1) {
    //        QTEGen = 4;

    //        CountingDown = 2;

    //        PassBox.GetComponent<Text>().text = "Fail";
    //        yield return new WaitForSeconds(1.5f);

    //        CorrectKey = 0;
    //        PassBox.GetComponent<Text>().text = "";
    //        DisplayBox.GetComponent<Text>().text = "";
    //        yield return new WaitForSeconds(1.5f);
    //        WaitingForKey = 0;
    //        CountingDown = 1;
    //    }
    //}

}
