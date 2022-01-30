using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Upgrades {
	public bool hasBombs = false;
	public bool hasLaser = false;
	public bool hasVision = false;
	public bool hasEnergy = false;
}

public class GameManagerScript : MonoBehaviour {
	public GameObject MenuObject;

	private static bool existsAlready = false;
	private Vector3 mechaPosition = new Vector3(0,0,0);
	private GameObject menuWindow;
	private Upgrades upgrades;
	//private int currentView = Constants.ROBOT_VIEW;

	void Start() {
		upgrades = new Upgrades();
		// Limit application to 60 FPS
		Application.targetFrameRate = 60;
		// Keep global object between scenes
		if (!existsAlready){
			DontDestroyOnLoad(gameObject);
			existsAlready = true;
		} else Destroy(gameObject);
	}

	// Upgrade functions
	public Upgrades getPlayerUpgrades() {
		return upgrades;
	}

	public void addUpgrade(string upgradeName) {
    switch (upgradeName) {
      case "Bombs": upgrades.hasBombs = true; break;
      case "Laser": upgrades.hasLaser = true; break;
      case "Vision": upgrades.hasVision = true; break;
      case "Energy": upgrades.hasEnergy = true; break;
    }
	}

	public void CloseMenuWindow(){
		Destroy(menuWindow);
		menuWindow = null;
	}

	public void QuitGame(){
		Destroy(menuWindow);
		menuWindow = null;
	}

	public void ChangeView(string sceneToLoad) {
    int sceneId;
    // Cant load scenes using a strings
    switch (sceneToLoad) {
      case "Title": sceneId = 0; break;
      case "History": sceneId = 1; break;
      case "Overworld": sceneId = 2; break;
      case "Gate1": sceneId = 3; break;
      case "Gate2": sceneId = 4; break;
      case "Gate3": sceneId = 5; break;
      case "Gate4": sceneId = 6; break;
      case "Gameover": sceneId = 7; break;
      default: sceneId = 0; break;
    }
		SceneManager.LoadScene(sceneId, LoadSceneMode.Single);
	}

	public void SaveMechaPosition(Transform mecha) {
		mechaPosition = mecha.position;
	}

	public Vector3 GetMechaSavedPosition() {
		return mechaPosition;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (menuWindow == null) {
				menuWindow = Instantiate(MenuObject, transform.position, transform.rotation);
				// Show active upgrades in the ui
				Transform UIUpgrades = menuWindow.transform.Find("Canvas/Upgrades").transform;
				if (upgrades.hasBombs) UIUpgrades.Find("Upgrade1").gameObject.SetActive(true);
				if (upgrades.hasLaser) UIUpgrades.Find("Upgrade2").gameObject.SetActive(true);
				if (upgrades.hasVision) UIUpgrades.Find("Upgrade3").gameObject.SetActive(true);
				if (upgrades.hasEnergy) UIUpgrades.Find("Upgrade4").gameObject.SetActive(true);
			}
			else CloseMenuWindow();
		}
	}
}
