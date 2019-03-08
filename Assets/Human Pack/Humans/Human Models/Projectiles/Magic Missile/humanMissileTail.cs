using UnityEngine;
using System.Collections;

public class humanMissileTail : MonoBehaviour
{

	public TrailRenderer tail;
	public float scrollSpeed = 0.5F;
	void Update()
	{
		float offset = Time.time * scrollSpeed;
		tail.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
