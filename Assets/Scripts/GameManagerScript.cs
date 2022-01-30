using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Upgrades {
	public bool hasBombs = false;
	public bool hasLaser = false;
	public bool hasVision = false;
	public bool hasEnergy = false;

	public bool mgHasBombs = false;
	public bool mgHasLaser = false;
	public bool mgHasVision = false;
	public bool mgHasEnergy = false;
}

public class GameManagerScript : MonoBehaviour {
    public int mechaHealth;
    public int mechaMaxHealth;

	public GameObject MenuObject;
	private static bool existsAlready = false;
	private GameObject MenuWindow;
	private Upgrades upgrades;
	//private int currentView = Constants.ROBOT_VIEW;
	private string currentSceneName = "Title";

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

	public string getCurrentScene() {
		return currentSceneName;
	}

	public void addUpgrade(string upgradeName) {
		switch (upgradeName) {
			case "Bombs": upgrades.hasBombs = true; break;
			case "Laser": upgrades.hasLaser = true; break;
			case "Vision": upgrades.hasVision = true; break;
			case "Energy": upgrades.hasEnergy = true; break;
		}
	}

	public void toggleMinigameUpgrade(string upgradeName) {
		switch (upgradeName) {
			case "Bombs": upgrades.mgHasBombs = !upgrades.mgHasBombs; break;
			case "Laser": upgrades.mgHasLaser = !upgrades.mgHasLaser; break;
			case "Vision": upgrades.mgHasVision = !upgrades.mgHasVision; break;
			case "Energy": upgrades.mgHasEnergy = !upgrades.mgHasEnergy; break;
		}
	}

	public void CloseMenuWindow(){
		Destroy(MenuWindow);
		Time.timeScale = 1;
		MenuWindow = null;
	}

	public void QuitGame(){
		Destroy(MenuWindow);
		MenuWindow = null;
		Time.timeScale = 1;
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
		currentSceneName = sceneToLoad;
		SceneManager.LoadScene(sceneId, LoadSceneMode.Single);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (MenuWindow == null) {
				MenuWindow = Instantiate(MenuObject, transform.position, transform.rotation);
				// Show active upgrades in the ui
				Time.timeScale = 0;
				Transform UIUpgrades = MenuWindow.transform.Find("Canvas/Upgrades").transform;
				if (upgrades.hasBombs || upgrades.mgHasBombs) UIUpgrades.Find("Upgrade1").gameObject.SetActive(true);
				if (upgrades.hasLaser || upgrades.mgHasLaser) UIUpgrades.Find("Upgrade2").gameObject.SetActive(true);
				if (upgrades.hasVision || upgrades.mgHasVision) UIUpgrades.Find("Upgrade3").gameObject.SetActive(true);
				if (upgrades.hasEnergy || upgrades.mgHasEnergy) UIUpgrades.Find("Upgrade4").gameObject.SetActive(true);
			}
			else CloseMenuWindow();
		}
	}
}
