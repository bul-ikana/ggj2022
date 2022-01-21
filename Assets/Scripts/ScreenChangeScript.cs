using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChangeScript : MonoBehaviour {
	public GameManagerScript calledBy;
	public int screenToChange;

	public void ANIMATION_CHANGE_VIEW() {
		calledBy.setView(screenToChange);
	}
	public void ANIMATION_KILLSELF() {
		Destroy(transform.parent.gameObject);
	}
}
