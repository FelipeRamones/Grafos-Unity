using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q2Script : MonoBehaviour {

	private Color colorQ2;

	public void receiverQ2(string wordQ2, int counterQ2){
		if (wordQ2.ToCharArray () [0] == 'a' || wordQ2.ToCharArray () [0] == 'b') {
			colorQ2 = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().activeStateColor;
			GameObject.Find ("q0").GetComponent<SpriteRenderer> ().color = colorQ2;

			wordQ2 = wordQ2.Remove (1);

			counterQ2--;
		} else {

		}
	}


	/*private string wordStateQ2;
	private int counterStateQ2;

	public q2Script(string wordQ2, int counterQ2){

	}

	public string getWordStateQ2(){
		return this.wordStateQ2;
	}

	public void setWordStateQ2(string wordStateQ2){
		this.wordStateQ2 = wordStateQ2;
	}

	public int getCounterStateQ2(int counterStateQ2){
		return this.counterStateQ2;
	}

	public void setCounterStateQ2 (int counterStateQ2){
		this.counterStateQ2 = counterStateQ2;
	}*/
}
