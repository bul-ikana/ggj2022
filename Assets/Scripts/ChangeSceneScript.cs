using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneScript : MonoBehaviour {
	public GameObject ScreenTransition;
	public string screenToChange;

  private GameManagerScript gameManager;

  private void Start() {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
  }

  public void changeScene(string sceneToLoad) {
		// Create a transition, who will call setView at an animation event
		GameObject transition = Instantiate(ScreenTransition, this.transform.position, this.transform.rotation);
		DontDestroyOnLoad(transition);
		transition.GetComponentInChildren<ChangeSceneScript>().screenToChange = sceneToLoad;
  }

	public void CallGmChangescene(){
		gameManager.ChangeView(screenToChange);
	}

	public void KillTransition(){
		Destroy(this);
	}

  public void CloseMenuWindow() {
    gameManager.CloseMenuWindow();
  }

  public void Exit() {
    gameManager.QuitGame();
  }
}
