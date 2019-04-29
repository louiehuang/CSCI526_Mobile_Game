using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QTESystem : MonoBehaviour {

    float times = 5f;
    private float hasButtonTime = 0f;
    private int waitTime = 5;

    private bool hasButton1 = false;
    private bool hasButton2 = false;
    private bool hasButton3 = false; 
    private bool hasButton4 = false;

    private int startTime = 30;
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

    private int width;
    private int height;

    public Image ProgressBarImage;

    private int QTEStartTime = 3;
    public Text QTEText;
    public GameObject QTEButton;

    private void Start() {
        width = Screen.width;
        height = Screen.height;
        QTEPannel.gameObject.SetActive(false);
        LosePannel.gameObject.SetActive(false);
        QTEButton.SetActive(false);
    }


    private Button CreateQTEButton1() {
        //Debug.Log("CreateQTEButton");
        //int ni = 200;
        //int ni = 2800;
        //int nj = 400;
        //int nj = 1500;
        
        int ni = Random.Range(100, (width - 100) / 2);
        int nj = Random.Range(100, (height - 100) / 2);
        Debug.Log("1: " + ni + " " + nj);
        var button = Instantiate(QTEPrefab1, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick1);

        hasButton1 = true;

        return button;
    }

    private Button CreateQTEButton2() {
        //Debug.Log("CreateQTEButton");
        int ni = Random.Range((width + 100) / 2, width - 100);
        int nj = Random.Range(100, (height - 100) / 2);
        Debug.Log("2: " + ni + " " + nj);
        var button = Instantiate(QTEPrefab2, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick2);

        hasButton2 = true;

        return button;
    }

    private Button CreateQTEButton3() {
        //Debug.Log("CreateQTEButton");
        int ni = Random.Range((width + 100) / 2, width - 100);
        int nj = Random.Range((height + 100) / 2, height - 100);
        Debug.Log("3: " + ni + " " + nj);
        var button = Instantiate(QTEPrefab3, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick3);

        hasButton3 = true;

        return button;
    }

    private Button CreateQTEButton4() {
        //Debug.Log("CreateQTEButton");
        int ni = Random.Range(100, (width - 100) / 2);
        int nj = Random.Range((height + 100) / 2, height - 100);
        Debug.Log("4: " + ni + " " + nj);
        var button = Instantiate(QTEPrefab4, new Vector3(ni, nj, 0), Quaternion.identity) as Button;

        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(QTEPannel.transform);
        button.onClick.AddListener(OnClick4);

        hasButton4 = true;

        return button;
    }

    private void TriggerFail() {
        ProgressBarImage.fillAmount = 1f;
        hasButtonTime = 0f;
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

        Destroy(button1.gameObject);
        Destroy(button2.gameObject);
        Destroy(button3.gameObject);
        Destroy(button4.gameObject);

        clickButton1 = false;
        clickButton2 = false;
        clickButton3 = false;
        clickButton4 = false;

        button1 = null;
        button2 = null;
        button3 = null;
        button4 = null;

        QTEPannel.gameObject.SetActive(false);
        times = Random.Range(startTime, intervalTime);
    }


    void Update() {

        times -= Time.deltaTime;
        if (times < QTEStartTime && times >= 0) {
            QTEButton.SetActive(true);
            QTEText.text = string.Format("{0:00.00}", Mathf.Clamp(times, 0f, Mathf.Infinity));
        }

        if (GameManager.GameIsOver) {
            QTEPannel.gameObject.SetActive(false);
            LosePannel.gameObject.SetActive(false);
            QTEButton.SetActive(false);
            return;
        }

        if (times < 0) {
            QTEButton.SetActive(false);
            BuildManager build = BuildManager.instance;
            if (build.hasDraged) {
                return;
            }
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
            if (hasButton1 && hasButton2 && hasButton3 && hasButton4 && hasButtonTime >= 0) {
                hasButtonTime = times;
            }

            if (hasButtonTime - times >= waitTime) {
                TriggerFail();
            } else {
                //Debug.Log(1 - (hasButtonTime - times) / waitTime);
                ProgressBarImage.fillAmount = 1 - (hasButtonTime - times) / waitTime;
            }
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

            Destroy(button1.gameObject);
            Destroy(button2.gameObject);
            Destroy(button3.gameObject);
            Destroy(button4.gameObject);

            clickButton1 = false;
            clickButton2 = false;
            clickButton3 = false;
            clickButton4 = false;

            button1 = null;
            button2 = null;
            button3 = null;
            button4 = null;

            hasButtonTime = 0f;

            QTEPannel.gameObject.SetActive(false);
            times = Random.Range(startTime, intervalTime);
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
