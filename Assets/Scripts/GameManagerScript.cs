using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	public GameObject MenuObject;
	public GameObject ScreenTransition;

	private static bool existsAlready = false;
	private GameObject MenuWindow;
	//private int currentView = Constants.ROBOT_VIEW;

	void Start() {
		// Limit application to 60 FPS
		Application.targetFrameRate = 60;
		// Keep global object between scenes
		if (!existsAlready){
			DontDestroyOnLoad(gameObject);
			existsAlready = true;
		} else Destroy(gameObject);
	}

	public void CloseMenuWindow(){
		Destroy(MenuWindow);
		MenuWindow = null;
	}

	public void QuitGame(){
		Destroy(MenuWindow);
		MenuWindow = null;
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

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (MenuWindow == null)
				MenuWindow = Instantiate(MenuObject, transform.position, transform.rotation);
			else
				CloseMenuWindow();
			
			/* Create a transition, who will call setView at an animation event
			GameObject transition = Instantiate(ScreenTransition, currentCamera.transform.position, currentCamera.transform.rotation);
			transition.GetComponentInChildren<ScreenChangeScript>().calledBy = this;
			transition.GetComponentInChildren<ScreenChangeScript>().screenToChange = currentView;*/
		}
	}
}
