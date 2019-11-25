using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe geral para controle de inputs, pausas e UI.
public class GameControllerScript : MonoBehaviour {

	//Variáveis responsáveis por guardar as cores que serão usadas na execução.
	public Color runningColor = new Color (Color.yellow.r, Color.yellow.g, Color.yellow.b, .1f);
	public Color standardColor = new Color (Color.white.r, Color.white.g, Color.white.b, .1f);
	public Color failureColor = new Color (Color.red.r, Color.red.g, Color.red.b, .1f);
	public Color acceptColor = new Color (Color.green.r, Color.green.g, Color.green.b, .1f);

	//Variável que instancia o campo de digitação de texto.
	public InputField entryText;

	//Variáveis que recebem a string digitada no InputField e que guarda o tamanho da string em numeros inteiros, respectivamente.
	private string text;
	private int count;

	public Image popUpImage;
	public Text popUpText;

	//Método que é chamado quando o botão é clicado.
	public void buttonPressed(){

		popUpImage.enabled = false;
		popUpText.enabled = false;

		/*Setando as cores dos sprites pra branco (cor padrão que escolhi) em caso de nova palavra ser digitada,
		Na primeira execução ele troca os sprites de branco pra branco não surtindo efeito visual ao usuário.*/
		GameObject.Find ("q0").GetComponent<SpriteRenderer> ().color = this.standardColor;
		GameObject.Find ("q1").GetComponent<SpriteRenderer> ().color = this.standardColor;
		GameObject.Find ("q2").GetComponent<SpriteRenderer> ().color = this.standardColor;
		GameObject.Find ("StartMarker").GetComponent<SpriteRenderer> ().color = this.standardColor;

		//Atrbuindo a string do InputField para a variável previamente declarada text e o comprimento dastring para a variável count.
		this.text = entryText.text;
		this.count = this.text.Length;

		GameObject.Find ("AudioSuccess").GetComponent<AudioSource> ().Stop ();
		GameObject.Find ("AudioFailure").GetComponent<AudioSource> ().Stop ();
		GameObject.Find ("AudioToggle").GetComponent<AudioSource> ().Stop ();

		GameObject.Find ("Fog").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("InputField").GetComponent<Image> ().enabled = false;
		GameObject.Find ("InputField").GetComponent<InputField> ().enabled = false;
		GameObject.Find ("Placeholder").GetComponent<Text> ().enabled = false;
		GameObject.Find ("TextInputField").GetComponent<Text> ().enabled = false;
		GameObject.Find ("Button").GetComponent<Image> ().enabled = false;
		GameObject.Find ("Button").GetComponent<Button> ().enabled = false;
		GameObject.Find ("TextButton").GetComponent<Text> ().enabled = false;

		//Checando se o usuário digitou algo.
		if (text == "") {

			/*Caso usuário aperte o botão com o InputField em branco o StartMarker se tinge de vermelho e 
			é pedido em console que o usuário digite algo e tente denovo.*/
			GameObject.Find ("StartMarker").GetComponent<SpriteRenderer> ().color = failureColor;

			GameObject.Find ("AudioFailure").GetComponent<AudioSource> ().Play ();

			GameObject.Find ("GameController").GetComponent<GameControllerScript> ().enableTryAgain ();

			this.popUpNull();

		} else {
			//Caso usuário digite algo:

			//A string text e o contador count são enviados para o método q0StateEnter na classe q0Script
			GameObject.Find ("q0").GetComponent<q0Script> ().q0StateEnter (this.text, this.count);
		}
	}

	/*Método para esperar um segundo com o sprite de q0 pintado de amarelo e depois o pintar de branco denovo 
	para sinalizar execução ao usuário.*/
	public IEnumerator waitASecondQ0(){

		//Esperar um segundo antes de executar próxima linha.
		yield return new WaitForSeconds (1);

		//Pintar sprite do GameObject em questão de branco.
		GameObject.Find ("q0").GetComponent<q0Script> ().resumeState ();
	}

	/*Método para esperar um segundo com o sprite de q1 pintado de amarelo e depois o pintar de branco denovo 
	para sinalizar execução ao usuário.*/
	public IEnumerator waitASecondQ1(){

		//Esperar um segundo antes de executar próxima linha.
		yield return new WaitForSeconds (1);

		//Pintar sprite do GameObject em questão de branco.
		GameObject.Find ("q1").GetComponent<q1Script> ().resumeState ();
	}

	/*Método para esperar um segundo com o sprite de q2 pintado de amarelo e depois o pintar de branco denovo 
	para sinalizar execução ao usuário.*/
	public IEnumerator waitASecondQ2(){

		//Esperar um segundo antes de executar próxima linha.
		yield return new WaitForSeconds (1);

		//Pintar sprite do GameObject em questão de branco.
		GameObject.Find ("q2").GetComponent<q2Script> ().resumeState ();
	}

	//Método que ativa o pop up verde com mensagem de palavra aceita.
	public void popUpOn(){

		//Passando cor da variável local para o componente de imagem do pop up.
		GameObject.Find("PopUpResult").GetComponent<Image> ().color = this.acceptColor;

		//Trocando texto do pop up por PALAVRA ACEITA.
		GameObject.Find("PopUpResult").GetComponentInChildren<Text> ().text = "PALAVRA ACEITA";

		//habilitando texto e imagem do pop up.
		popUpImage.enabled = true;
		popUpText.enabled = true;
	}

	public void popUpOff(){
		
		//Passando cor da variável local para o componente de imagem do pop up.
		GameObject.Find("PopUpResult").GetComponent<Image> ().color = this.failureColor;

		//Trocando texto do pop up por PALAVRA REJEITADA.
		GameObject.Find("PopUpResult").GetComponentInChildren<Text> ().text = "PALAVRA REJEITADA";

		//habilitando texto e imagem do pop up.
		popUpImage.enabled = true;
		popUpText.enabled = true;
	}

	public void popUpNull(){
		GameObject.Find("PopUpResult").GetComponent<Image> ().color = this.failureColor;
		GameObject.Find("PopUpResult").GetComponentInChildren<Text> ().text = "DIGITE UMA PALAVRA";
		popUpImage.enabled = true;
		popUpText.enabled = true;
	}

	public void quitButton(){
		Application.Quit ();
	}

	public void tryNewWordButton(){
		this.disableTryAgain ();

		GameObject.Find ("Fog").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find ("InputField").GetComponent<Image> ().enabled = true;
		GameObject.Find ("InputField").GetComponent<InputField> ().enabled = true;
		GameObject.Find ("Placeholder").GetComponent<Text> ().enabled = true;
		GameObject.Find ("TextInputField").GetComponent<Text> ().enabled = true;
		GameObject.Find ("Button").GetComponent<Image> ().enabled = true;
		GameObject.Find ("Button").GetComponent<Button> ().enabled = true;
		GameObject.Find ("TextButton").GetComponent<Text> ().enabled = true;


		popUpImage.enabled = false;
		popUpText.enabled = false;

		//Setando as cores dos sprites pra branco (cor padrão que escolhi) em caso do usuário clicar em clear.
		GameObject.Find ("q0").GetComponent<SpriteRenderer> ().color = this.standardColor;
		GameObject.Find ("q1").GetComponent<SpriteRenderer> ().color = this.standardColor;
		GameObject.Find ("q2").GetComponent<SpriteRenderer> ().color = this.standardColor;
		GameObject.Find ("StartMarker").GetComponent<SpriteRenderer> ().color = this.standardColor;

	}

	public void enableTryAgain(){
		GameObject.Find ("TryAgainButton").GetComponent<Image> ().enabled = true;
		GameObject.Find ("TryAgainButton").GetComponent<Button> ().enabled = true;
		GameObject.Find ("TextTryAgain").GetComponent<Text> ().enabled = true;
	}

	public void disableTryAgain(){
		GameObject.Find ("TryAgainButton").GetComponent<Image> ().enabled = false;
		GameObject.Find ("TryAgainButton").GetComponent<Button> ().enabled = false;
		GameObject.Find ("TextTryAgain").GetComponent<Text> ().enabled = false;
	}
}
