using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QTESystem : MonoBehaviour {

    float times = 5f;
    private bool hasButton1 = false;
    private bool hasButton2 = false;
    private bool hasButton3 = false; 
    private bool hasButton4 = false;

    private int intervalTime = 50;

    private bool clickButton1 = false;
    private bool clickButton2 = false;
    private bool clickButton3 = false;
    private bool clickButton4 = false;


    public Button QTEPrefab1;
    public Button QTEPrefab2;
    public Button QTEPrefab3;
    public Button QTEPrefab4;
    //public Canvas Canvas;
    public Transform QTEPannel;
    public Transform LosePannel;

    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;

    private void Start() {
        QTEPannel.gameObject.SetActive(false);
        LosePannel.gameObject.SetActive(false);
    }


    private Button CreateQTEButton1() {
        //Debug.Log("CreateQTEButton");
        //int ni = 200;
        //int nj = 200;
        int ni = Random.Range(50, 300);
        int nj = Random.Range(100, 230);
        var button = Instantiate(QTEPrefab1, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick1);

        hasButton1 = true;

        return button;
    }

    private Button CreateQTEButton2() {
        //Debug.Log("CreateQTEButton");
        //int ni = 600;
        //int nj = 200;
        int ni = Random.Range(350, 600);
        int nj = Random.Range(100, 230);
        var button = Instantiate(QTEPrefab2, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick2);

        hasButton2 = true;

        return button;
    }

    private Button CreateQTEButton3() {
        //Debug.Log("CreateQTEButton");
        //int ni = 600;
        //int nj = 400;
        int ni = Random.Range(350, 600);
        int nj = Random.Range(270, 400);
        var button = Instantiate(QTEPrefab3, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick3);

        hasButton3 = true;

        return button;
    }

    private Button CreateQTEButton4() {
        //Debug.Log("CreateQTEButton");
        //int ni = 200;
        //int nj = 400;
        int ni = Random.Range(50, 300);
        int nj = Random.Range(270, 400);
        var button = Instantiate(QTEPrefab4, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick4);

        hasButton4 = true;

        return button;
    }

    private void TriggerFail() {
        LosePannel.gameObject.SetActive(true);
        Debug.Log("Cai Start!");
        StartCoroutine(Wait(2f));
    }

    IEnumerator Wait(float t) {
        yield return new WaitForSeconds(t);
        LosePannel.gameObject.SetActive(false);
        Debug.Log("Cai End!");
        hasButton1 = false;
        hasButton2 = false;
        hasButton3 = false;
        hasButton4 = false;

        QTEPannel.DetachChildren();

        clickButton1 = false;
        clickButton2 = false;
        clickButton3 = false;
        clickButton4 = false;

        button1 = null;
        button2 = null;
        button3 = null;
        button4 = null;

        QTEPannel.gameObject.SetActive(false);
        times = Random.Range(0, intervalTime);
    }


    void Update() {
        times -= Time.deltaTime;
        if (times < 0) {
            QTEPannel.gameObject.SetActive(true);
            if (!hasButton1) {
                button1 = CreateQTEButton1();
            }
            if (!hasButton2) {
                button2 = CreateQTEButton2();
            }
            if (!hasButton3) {
                button3 = CreateQTEButton3();
            }
            if (!hasButton4) {
                button4 = CreateQTEButton4();
            }
            //times = Random.Range(0, intervalTime);
        }
    }

    private void OnClick1() {
        if (hasButton1 && hasButton2 && hasButton3 && hasButton4
            && !clickButton2 && !clickButton3 && !clickButton4) {
            clickButton1 = true;
        } else {
            clickButton1 = false;
            clickButton2 = false;
            clickButton3 = false;
            clickButton4 = false;
            Debug.Log("fail!");
            TriggerFail();
        }
    }

    private void OnClick2() {
        if (hasButton1 && hasButton2 && hasButton3 && hasButton4
            && clickButton1 && !clickButton3 && !clickButton4) {
            clickButton2 = true;
        } else {
            clickButton1 = false;
            clickButton2 = false;
            clickButton3 = false;
            clickButton4 = false;
            Debug.Log("fail!");
            TriggerFail();
        }
    }

    private void OnClick3() {
        if (hasButton1 && hasButton2 && hasButton3 && hasButton4
            && clickButton1 && clickButton2 && !clickButton4) {
            clickButton3 = true;
        } else {
            clickButton1 = false;
            clickButton2 = false;
            clickButton3 = false;
            clickButton4 = false;
            Debug.Log("fail!");
            TriggerFail();
        }
    }

    private void OnClick4() {
        if (hasButton1 && hasButton2 && hasButton3 && hasButton4
            && clickButton1 && clickButton2 && clickButton3) {
            clickButton4 = true;
            Debug.Log("success!");
            hasButton1 = false;
            hasButton2 = false;
            hasButton3 = false;
            hasButton4 = false;

            QTEPannel.DetachChildren();

            clickButton1 = false;
            clickButton2 = false;
            clickButton3 = false;
            clickButton4 = false;

            button1 = null;
            button2 = null;
            button3 = null;
            button4 = null;

            QTEPannel.gameObject.SetActive(false);
            times = Random.Range(0, intervalTime);
        } else {
            clickButton1 = false;
            clickButton2 = false;
            clickButton3 = false;
            clickButton4 = false;
            Debug.Log("fail!");
            TriggerFail();
        }
    }
}
