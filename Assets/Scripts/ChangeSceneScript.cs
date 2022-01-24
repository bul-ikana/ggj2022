using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneScript : MonoBehaviour {
  private GameManagerScript gameManager;

  private void Start() {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
  }

  public void changeScene(string sceneToLoad) {
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
      default: sceneId = 0; break;
    }
    gameManager.ChangeView(sceneId);
  }

  public void CloseMenuWindow() {
    gameManager.CloseMenuWindow();
  }

  public void Exit() {
    gameManager.QuitGame();
  }
}
