using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	public Camera RobotCamera;
	public Camera HumanCamera;
	public GameObject RobotWorld;
	public GameObject HumanWorld;
	public GameObject ScreenTransition;

	private int currentView = Constants.ROBOT_VIEW;
	private Camera currentCamera;

	void Start() {
		// Limit application to 60 FPS
		Application.targetFrameRate = 60;
		currentCamera = RobotCamera;
		setView(currentView);
	}
	// Switch the players view to the given camera
	public void setView(int view) {
		HumanCamera.enabled = false;
		RobotCamera.enabled = false;
		RobotWorld.SetActive(false);
		HumanWorld.SetActive(false);

		switch (view) {
			case Constants.HUMAN_VIEW:
				HumanCamera.enabled = true;
				HumanWorld.SetActive(true);
			break;
			case Constants.ROBOT_VIEW:
				RobotCamera.enabled = true;
				RobotWorld.SetActive(true);
			break;
		}
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (currentView == Constants.ROBOT_VIEW) currentView = Constants.HUMAN_VIEW;
			else currentView = Constants.ROBOT_VIEW;
			
			// Create a transition, who will call set view at an animation event
			GameObject transition = Instantiate(ScreenTransition, currentCamera.transform.position, currentCamera.transform.rotation);
			transition.GetComponentInChildren<ScreenChangeScript>().calledBy = this;
			transition.GetComponentInChildren<ScreenChangeScript>().screenToChange = currentView;
		}
	}
}
