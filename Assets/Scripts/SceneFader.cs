using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Collections.Generic;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    private float minX = float.MaxValue;
    private float minZ = float.MaxValue;
    private float maxX = float.MinValue;
    private float maxZ = float.MinValue;

    public float MinX { get { return minX; } set { minX = value; } }
    public float MinZ { get { return minZ; } set { minZ = value; } }
    public float MaxX { get { return maxX; } set { maxX = value; } }
    public float MaxZ { get { return maxZ; } set { maxZ = value; } }

    void Start() {
        StartCoroutine(FadeIn());
        updateEdgeData();
        Debug.Log("edge is : (" + minX+", "+minZ+") and ("+maxX+", "+maxZ+")");
    }

    private void updateEdgeData() {
        GameObject nodes = GameObject.Find("Nodes");
        if (nodes == null) return;
        foreach (Transform child in nodes.transform) {
            //Debug.Log(child.gameObject.name);
            minX = Math.Min(minX, child.position.x);
            maxX = Math.Max(maxX, child.position.x);
            minZ = Math.Min(minZ, child.position.z);
            maxZ = Math.Max(maxZ, child.position.z);
        }
    }



    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn() {
        float t = 1f;

        while (t > 0f) {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            if(img != null)
                img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene) {
        float t = 0f;

        while (t < 1f) {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            if(img != null)
                img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }



}
