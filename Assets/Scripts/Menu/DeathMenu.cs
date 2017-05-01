using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;
	public string level1;

	public void RestartGame(){

		Application.LoadLevel (level1);
	}

	public void QuittoMain(){

		Application.LoadLevel (mainMenuLevel);
	}
}
