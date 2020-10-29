using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class runing : MonoBehaviour
{
	public Animator ani;
	public float moveSpeed = 10f;
	public bool nen;
	public Rigidbody2D rb;
	

	//public Transform gunTip;
	public GameObject chim;
	float FireRate = 0.5f;
	float nextFire = 0;
	public bool facingR;
	public bool dich;

	void Start()
	{

		ani = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		facingR = true;
		soundmanager.PlaySound("nen");

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "nen")
		{
			nen = true;
		}
		
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{

			if (nen == true)
			{
				nen = false;
				//transform.Translate(0, Time.deltaTime * 40f, 0);
				rb.AddForce(Vector2.up * 1050f);
				ani.SetBool("loljum", true);

				ani.Play("jum");

				ani.SetBool("loljum", false);
			}


		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			

			transform.Translate((Time.deltaTime) * 10f, 0, 0);

			
			transform.localScale = new Vector3(0.6f, 0.6f, 0);

			ani.SetBool("run", true);

			ani.Play("di");

			ani.SetBool("run", false);
			facingR = true;

		}

		// Đi qua trái

		if (Input.GetKey(KeyCode.LeftArrow))
		{

		
			transform.Translate(-(Time.deltaTime) * 10f, 0, 0);


			transform.localScale = new Vector3(-0.6f, 0.6f, 0);


			ani.SetBool("run", true);

			ani.Play("di");

			ani.SetBool("run", false);
			facingR = false;

		}


	
		if (Input.GetKey(KeyCode.Space))
		{
			soundmanager.PlaySound("playerhit");
			StartCoroutine(Begin());
			fireBullet();
		}

	}
	IEnumerator Begin()
	{
		ani.SetBool("ishot", true);
		yield return new WaitForSeconds(0.4f);
		ani.SetBool("ishot", false);

	}

	//shoot
	void fireBullet()
	{
		Vector3 gunTip = GameObject.Find("Guntip").transform.position;
		if (Time.time > nextFire)
		{

			nextFire = Time.time + FireRate;
			if (facingR ==true)
			{

				Instantiate(chim,new Vector3( gunTip.x +8, gunTip.y +5, gunTip.z), Quaternion.Euler(new Vector3(0, 0, 0)));
				
			}
			else if(facingR==false )
			{
				Instantiate(chim, new Vector3(gunTip.x - 8, gunTip.y - 5, gunTip.z), Quaternion.Euler(new Vector3(0, 0, 180)));


			}
		}
	}
}
