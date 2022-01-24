using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneScript : MonoBehaviour {
  private GameManagerScript gameManager;

  private void Start() {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
  }

  public void changeScene(string sceneToLoad) {
    gameManager.ChangeView(sceneToLoad);
  }

  public void CloseMenuWindow() {
    gameManager.CloseMenuWindow();
  }

  public void Exit() {
    gameManager.QuitGame();
  }
}
