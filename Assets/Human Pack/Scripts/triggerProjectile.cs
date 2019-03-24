using UnityEngine;
using System.Collections;

public class triggerProjectile : MonoBehaviour {

	public GameObject projectile;
	public Transform shootPoint;

	private GameObject magicMissile;
	public float attackLenght;
	public float attackRange;

	public GameObject hitEffect;


	public void shoot()
	{
		magicMissile = Instantiate(projectile, shootPoint.position, transform.rotation) as GameObject;
	
		StartCoroutine(lerpyLoop(magicMissile));
	}

	// shoot loop
	public IEnumerator lerpyLoop(GameObject projectileInstance)
	{
		var victim = transform.position + transform.forward * attackRange;

		float progress = 0;
		float timeScale = 1.0f / attackLenght;
		Vector3 origin = projectileInstance.transform.position;

		// lerp ze missiles!
		while (progress < 1)
		{
			if (projectileInstance)
			{			
			progress += timeScale * Time.deltaTime;
			float ypos = (progress - Mathf.Pow(progress, 2)) * 12;
			float ypos_b = ((progress + 0.1f) - Mathf.Pow((progress + 0.1f), 2)) * 12;
			projectileInstance.transform.position = Vector3.Lerp(origin, victim, progress) + new Vector3(0, ypos, 0);
			if (progress < 0.9f)
			{
				projectileInstance.transform.LookAt(Vector3.Lerp(origin, victim, progress + 0.1f) + new Vector3(0, ypos_b, 0));
			}
			yield return null;
			}
		}

		Destroy(projectileInstance);

		if (hitEffect)
			Instantiate(hitEffect, victim, transform.rotation);

		yield return null;
	}

	public void clearProjectiles()
	{
		if (magicMissile)
			Destroy(magicMissile);
	}
	
}
