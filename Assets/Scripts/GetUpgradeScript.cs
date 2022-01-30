using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpgradeScript : MonoBehaviour
{
	protected SoundManager audio;

	public string upgradeToAdd;

	void Start()
	{
		audio = GetComponent<SoundManager>();
	}

	// Damage mecha on collision
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			audio.PlayStay("take");
			collision.gameObject.GetComponent<MinigameControls>().powerObtained = upgradeToAdd;
        	GameManagerScript gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
			gm.toggleMinigameUpgrade(upgradeToAdd);
			Destroy(this.gameObject);
		}
	}
}
