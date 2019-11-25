using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q0Script : MonoBehaviour {

	private Color nodeColor;

	private string text;
	private int count;

	public void q0StateEnter(string text, int count){



		if (text.ToCharArray () [0] == 'a' || text.ToCharArray () [0] == 'b') {

			nodeColor = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().runningColor;
			this.GetComponent<SpriteRenderer> ().color = nodeColor;


			this.text = text.Remove (0, 1);

			this.count = count - 1;

			if (this.count <= 0) {
				nodeColor = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().failureColor;
				this.GetComponent<SpriteRenderer> ().color = nodeColor;

				GameObject.Find ("AudioFailure").GetComponent<AudioSource> ().Play ();

				GameObject.Find ("GameController").GetComponent<GameControllerScript> ().popUpOff();

				GameObject.Find ("GameController").GetComponent<GameControllerScript> ().enableTryAgain ();
			} else {
				GameObject.Find ("AudioToggle").GetComponent<AudioSource> ().Play ();

				StartCoroutine (GameObject.Find ("GameController").GetComponent<GameControllerScript> ().waitASecondQ0 ());
			}

		} else {
			nodeColor = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().failureColor;
			this.GetComponent<SpriteRenderer> ().color = nodeColor;

			GameObject.Find ("AudioFailure").GetComponent<AudioSource> ().Play ();

			GameObject.Find ("GameController").GetComponent<GameControllerScript> ().popUpOff();

			GameObject.Find ("GameController").GetComponent<GameControllerScript> ().enableTryAgain ();
		}
		
	}

	public void resumeState(){
		nodeColor = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().standardColor;
		this.GetComponent<SpriteRenderer> ().color = nodeColor;

		this.pointToNextState ();
	}

	private void pointToNextState(){
		GameObject.Find ("q1").GetComponent<q1Script> ().q1StateEnter (this.text, this.count);
	}
}
