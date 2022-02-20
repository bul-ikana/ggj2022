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
			collision.gameObject.GetComponent<MinigameControls>().powersObtained.ForEach(addUpgrde);
        	
        	gameObject.GetComponent<ChangeSceneScript>().changeScene("Overworld");
			Destroy(this);
		}
	}

	void addUpgrde(string name)
    {
        GameManagerScript gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		gm.addUpgrade(name);
    }
}
