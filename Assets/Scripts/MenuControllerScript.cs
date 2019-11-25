using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour {

	public void startButton(){

		GameObject.Find ("ClickSound").GetComponent<AudioSource> ().Play ();

		StartCoroutine(this.startLoading ());
	}

	public void instructionsButton(){

		GameObject.Find ("ClickSound").GetComponent<AudioSource> ().Play ();

		StartCoroutine(this.instructionsLoading ());
	}

	public void exitButton(){
		
		GameObject.Find ("ClickSound").GetComponent<AudioSource> ().Play ();

		StartCoroutine(this.quitFromMenu ());
	}

	public IEnumerator startLoading(){
		yield return new WaitForSeconds(0.5f);

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public IEnumerator instructionsLoading(){
		yield return new WaitForSeconds(0.5f);

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 2);
	}

	public IEnumerator quitFromMenu(){
		yield return new WaitForSeconds(0.5f);

		Application.Quit ();
	}
}
