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
			string upgradeToAdd = collision.gameObject.GetComponent<MinigameControls>().powerObtained;
        	GameManagerScript gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
			gm.addUpgrade(upgradeToAdd);
        	gameObject.GetComponent<ChangeSceneScript>().changeScene("Overworld");
			Destroy(this);
		}
	}
}
