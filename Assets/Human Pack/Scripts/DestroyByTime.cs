using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifetime;

	void Update () {

		lifetime -= Time.deltaTime;

		if (lifetime <= 0)
			Destroy(gameObject);	
	}
}
