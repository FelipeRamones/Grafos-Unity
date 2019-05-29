using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q1Script : MonoBehaviour {

	private Color colorQ1;

	public void receiverQ1(string wordQ1, int counterQ1){
		if (wordQ1.ToCharArray () [0] == 'a' || wordQ1.ToCharArray () [0] == 'b') {
			colorQ1 = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().activeStateColor;
			GameObject.Find ("q0").GetComponent<SpriteRenderer> ().color = colorQ1;

			wordQ1 = wordQ1.Remove (1);

			counterQ1--;
		} else {

		}
	}

	/*private string wordStateQ1;
	private int counterStateQ1;

	public q1Script(string wordQ1, int counterQ1){

	}

	public string getWordStateQ1(){
		return this.wordStateQ1;
	}

	public void setWordStateQ1(string wordStateQ1){
		this.wordStateQ1 = wordStateQ1;
	}

	public int getCounterStateQ1(int counterStateQ1){
		return this.counterStateQ1;
	}

	public void setCounterStateQ1 (int counterStateQ1){
		this.counterStateQ1 = counterStateQ1;
	}*/
}
