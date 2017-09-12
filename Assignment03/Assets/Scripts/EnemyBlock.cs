using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
	public int moveSpeed;

	public MeshRenderer mat;

	void Start ()
	{
		mat = GetComponent<MeshRenderer> ();

		Destroy (gameObject, 3.5f);

	}


	void FixedUpdate ()
	{
		transform.position += Vector3.back * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy (gameObject);
			other.gameObject.GetComponent<MeshRenderer> ().material.color = mat.material.color;
			GameController.Instance.score += 100;
			GameController.Instance.scoreText.text = "Score: " + GameController.Instance.score;

		}
	}

}
