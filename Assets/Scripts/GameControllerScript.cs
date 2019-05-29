using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	//Variáveis de cores para piscar os sprites, - Amarelo: Sendo avaliado, Verde: Conclusão verdadeira, Vermelho: Conclusão falsa, Branco: Neutro.
	public Color neutralStateColor = new Color (Color.white.r, Color.white.g, Color.white.b, 255f);
	public Color activeStateColor = new Color (Color.yellow.r, Color.yellow.g, Color.yellow.b, 255f);
	public Color acceptStateColor = new Color (Color.green.r, Color.green.g, Color.green.b, 255f);
	public Color failureStateColor = new Color (Color.red.r, Color.red.g, Color.red.b, 255f);

	//Variável que coleta o tomanho da string para contar se ainda restam caracteres a serem analisados.
	public int counter;

	//Variável que coleta o texto do InputField. Recepção de texto setada na interface da unity.
	public InputField entryText;

	//String para coletar a palavra digitada no InputField;
	public string word;

	public void buttonPressed(){

		word = entryText.text;

		counter = word.Length;

		GameObject.Find ("q0").GetComponent<q0Script> ().receiverQ0(word, counter);

		Debug.Log (word);

		GameObject.Find ("Button").GetComponent<Button> ().interactable = false;
		GameObject.Find ("InputField").GetComponent<InputField> ().interactable = false;
	}

	public IEnumerator waitFiveSeconds(){
		Debug.Log ("Método está sendo chamado corretamente");

		yield return new WaitForSeconds (5);
	}

}
