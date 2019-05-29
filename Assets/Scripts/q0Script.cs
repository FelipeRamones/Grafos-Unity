using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q0Script : MonoBehaviour {

	private Color colorQ0; //Variável que recebe a cor de GameControllerScript e é usada para pintar o sprite

	//Método que recebe a string digitada no InputField e o tamanho dela como int em novas variáveis locais
	public void receiverQ0(string wordQ0, int counterQ0){

		//IF que testa se a letra do índice 0 da string é 'a' ou 'b'

		if (wordQ0.ToCharArray () [0] == 'a' || wordQ0.ToCharArray () [0] == 'b') {

			//Troca de cor do sprite

			colorQ0 = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().activeStateColor;
			GameObject.Find ("q0").GetComponent<SpriteRenderer> ().color = colorQ0;

			//Remoção da primeira letra da palavra armazenada na variável local (cópia da string original de game controller)
			wordQ0 = wordQ0.Substring (1);

			//Decrécimo do contador para fins de controle de quando o loop deve acabar
			counterQ0--;

			Debug.Log ("5 segundos antes");

			//Espera de 5 segundos para fins estéticos, método não está sendo chamado... tentar corrigir.
			GameObject.Find ("GameController").GetComponent<GameControllerScript> ().waitFiveSeconds();

			Debug.Log ("5 segundos depois");

			//colorQ0 = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().neutralStateColor;
			//GameObject.Find ("q0").GetComponent<SpriteRenderer> ().color = colorQ0;
			//GameObject.Find ("q1").GetComponent<q1Script> ().receiverQ1(wordQ0, counterQ0);

		} else {
			colorQ0 = GameObject.Find ("GameController").GetComponent<GameControllerScript> ().failureStateColor;
			GameObject.Find ("q0").GetComponent<SpriteRenderer> ().color = colorQ0;
		}
	}
}
