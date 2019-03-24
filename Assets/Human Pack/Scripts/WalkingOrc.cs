using UnityEngine;
using System.Collections;

public class WalkingOrc : MonoBehaviour
{

	private Animator animator;

	public float walkspeed = 5;
	private float horizontal;
	private float vertical;
	private float rotationDegreePerSecond = 1000;
	private bool isAttacking = false;

	public GameObject gamecam;
	public Vector2 camPosition;
	private bool dead;


	public GameObject[] characters;
	public int currentChar = 0;


	void Start()
	{
		setCharacter(0);
	}

	void FixedUpdate()
	{
		if (animator && !dead)
		{
			//walk
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");

			Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
			float speedOut;

			if (stickDirection.sqrMagnitude > 1) stickDirection.Normalize();

			if (!isAttacking)
				speedOut = stickDirection.sqrMagnitude;
			else
				speedOut = 0;

			if (stickDirection != Vector3.zero && !isAttacking)
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(stickDirection, Vector3.up), rotationDegreePerSecond * Time.deltaTime);
			GetComponent<Rigidbody>().velocity = transform.forward * speedOut * walkspeed + new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);

			animator.SetFloat("Speed", speedOut);

		}
	}

	void Update()
	{
		if (!dead)
		{
			// move camera
			if (gamecam)
				gamecam.transform.position = transform.position + new Vector3(0, camPosition.x, -camPosition.y);

			// attack

			if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump") && !isAttacking)
			{
				isAttacking = true;
				//animator.Play("Attack");
				animator.SetTrigger("Attack");
				StartCoroutine(stopAttack(1));
				activateTrails(true);
			}

			animator.SetBool("isAttacking", isAttacking);

			//switch character

			if (Input.GetKeyDown("left"))
			{
				setCharacter(-1);
				isAttacking = true;
				StartCoroutine(stopAttack(1f));
			}

			if (Input.GetKeyDown("right"))
			{
				setCharacter(1);
				isAttacking = true;
				StartCoroutine(stopAttack(1f));
			}

			// death
			if (Input.GetKeyDown("m"))
				StartCoroutine(selfdestruct());
		}

	}

	public IEnumerator stopAttack(float lenght)
	{
		yield return new WaitForSeconds(lenght); // attack lenght
		isAttacking = false;
		activateTrails(false);
	}

	public IEnumerator selfdestruct()
	{
		animator.SetTrigger("isDead");
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		dead = true;

		yield return new WaitForSeconds(1.3f);
		GameObject.FindWithTag("GameController").GetComponent<gameContoller>().resetLevel();
	}

	public void setCharacter(int i)
	{
	
		currentChar += i;

		if (currentChar > characters.Length - 1)
			currentChar = 0;
		if (currentChar < 0)
			currentChar = characters.Length - 1;

		foreach (GameObject child in characters)
		{
			if (child == characters[currentChar])
				child.SetActive(true);
			else
			{
				child.SetActive(false);

				if (child.GetComponent<triggerProjectile>())
					child.GetComponent<triggerProjectile>().clearProjectiles();
			}
		}

		animator = GetComponentInChildren<Animator>();
	}

	public void activateTrails(bool state)
	{
		var tails = GetComponentsInChildren<TrailRenderer>();
		foreach (TrailRenderer tt in tails)
		{
			tt.enabled = state;
		}
	}
}
