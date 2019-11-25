using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsControllerScript : MonoBehaviour {

	private int currentPage = 1;

	public void nextPageButton(){
		GameObject.Find ("TogglePageButton").GetComponent<AudioSource> ().Play ();

		switch(this.currentPage){
		case 1:
			currentPage++;
			GameObject.Find ("Page1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Page1Text").GetComponent<Text> ().enabled = false;

			GameObject.Find ("Page2").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Page2Text").GetComponent<Text> ().enabled = true;

			GameObject.Find ("PreviousPage").GetComponent<Image> ().enabled = true;
			GameObject.Find ("PreviousPage").GetComponent<Button> ().enabled = true;
			GameObject.Find ("PreviousPageText").GetComponent<Text> ().enabled = true;

			break;

		case 2:
			currentPage++;
			GameObject.Find ("Page2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Page2Text").GetComponent<Text> ().enabled = false;

			GameObject.Find ("Page3").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Page3Text").GetComponent<Text> ().enabled = true;

			break;

		case 3:
			currentPage++;
			GameObject.Find ("Page3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Page3Text").GetComponent<Text> ().enabled = false;

			GameObject.Find ("Page4Text").GetComponent<Text> ().enabled = true;

			GameObject.Find ("NextPage").GetComponent<Image> ().enabled = false;
			GameObject.Find ("NextPage").GetComponent<Button> ().enabled = false;
			GameObject.Find ("NextPageText").GetComponent<Text> ().enabled = false;

			GameObject.Find ("BackToMenu").GetComponent<Image> ().enabled = true;
			GameObject.Find ("BackToMenu").GetComponent<Button> ().enabled = true;
			GameObject.Find ("BackToMenuText").GetComponent<Text> ().enabled = true;

			GameObject.Find ("BackToGame").GetComponent<Image> ().enabled = true;
			GameObject.Find ("BackToGame").GetComponent<Button> ().enabled = true;
			GameObject.Find ("BackToGameText").GetComponent<Text> ().enabled = true;

			break;
		}
	}

	public void previousPageButton(){
		GameObject.Find ("TogglePageButton").GetComponent<AudioSource> ().Play ();

		switch(this.currentPage){
		case 2:
			currentPage--;
			GameObject.Find ("Page1").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Page1Text").GetComponent<Text> ().enabled = true;

			GameObject.Find ("Page2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Page2Text").GetComponent<Text> ().enabled = false;

			GameObject.Find ("PreviousPage").GetComponent<Image> ().enabled = false;
			GameObject.Find ("PreviousPage").GetComponent<Button> ().enabled = false;
			GameObject.Find ("PreviousPageText").GetComponent<Text> ().enabled = false;

			break;
		
		case 3:
			currentPage--;

			GameObject.Find ("Page2").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Page2Text").GetComponent<Text> ().enabled = true;

			GameObject.Find ("Page3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Page3Text").GetComponent<Text> ().enabled = false;

			break;

		case 4:
			currentPage--;

			GameObject.Find ("Page3").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Page3Text").GetComponent<Text> ().enabled = true;

			GameObject.Find ("Page4Text").GetComponent<Text> ().enabled = false;

			GameObject.Find ("NextPage").GetComponent<Image> ().enabled = true;
			GameObject.Find ("NextPage").GetComponent<Button> ().enabled = true;
			GameObject.Find ("NextPageText").GetComponent<Text> ().enabled = true;

			GameObject.Find ("BackToMenu").GetComponent<Image> ().enabled = false;
			GameObject.Find ("BackToMenu").GetComponent<Button> ().enabled = false;
			GameObject.Find ("BackToMenuText").GetComponent<Text> ().enabled = false;

			GameObject.Find ("BackToGame").GetComponent<Image> ().enabled = false;
			GameObject.Find ("BackToGame").GetComponent<Button> ().enabled = false;
			GameObject.Find ("BackToGameText").GetComponent<Text> ().enabled = false;

			break;
		}
			
	}

	public void backToMenuButton(){
		GameObject.Find ("ClickButton").GetComponent<AudioSource> ().Play ();

		StartCoroutine(this.backToMenuWait ());
	}

	public void backToGameButton(){
		GameObject.Find ("ClickButton").GetComponent<AudioSource> ().Play ();

		StartCoroutine (this.backToGameWait ());
	}

	public IEnumerator backToMenuWait(){
		yield return new WaitForSeconds (0.5f);

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 2);
	}

	public IEnumerator backToGameWait(){
		yield return new WaitForSeconds (0.5f);

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 1);
	}
}

