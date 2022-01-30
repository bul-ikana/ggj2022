using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMechaScript : MonoBehaviour
{
	// Get upgrade and destroy object
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
				GetComponent<ChangeSceneScript>().changeScene("Overworld");
				Destroy(this);
		}
	}
}
