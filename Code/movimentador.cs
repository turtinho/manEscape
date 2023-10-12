using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentador : MonoBehaviour {
	[SerializeField]
	private GameObject GameOver;
	float velocidade = 5f;
	private Fase fase;
	private AudioSource tocadorAudio;
	public AudioClip pulo;
	public AudioClip gameOver;

	private void Awake() {
		tocadorAudio = GetComponent<AudioSource>();
		//this.fase = GameObject.FindObjectOfType<Fase>();
	}

	private void LateUpdate(){
		Rigidbody2D rigiody2D = GetComponent<Rigidbody2D> ();
		Animator animator = GetComponent<Animator> ();
		if (rigiody2D.velocity.x < 0 || rigiody2D.velocity.x >0) {
			animator.Play("andando");
		}else{
			animator.Play("Parado");
		}
	}

	private void OnCollisionEnter2D(Collision2D collision2D){
		//testando se foi a pedra quem colidiu
		if (collision2D.gameObject.GetComponent<Pedra> () != null) {
			TocadorAudio.Tocador.PlayOneShot (gameOver);
			this.GameOver.SetActive(true);
			//infla a imagem de game over
			Time.timeScale = 0;
			//para o tempo de execução do jogo
		}
	}

	public void ReiniciaJogo()
	{
		Time.timeScale = 1;
		//inicia do tempo de jogo
		this.GameOver.SetActive(false);
		//desinfla a imagem de game over
		Application.LoadLevel (Application.loadedLevelName);
		//recarregando a cena
	}

	private void Update () {
		Rigidbody2D rigibody2D = GetComponent<Rigidbody2D> ();

		if (Input.GetKey (KeyCode.RightArrow)) {

			float velocidadeX =
			Mathf.Clamp(
					rigibody2D.velocity.x + 0.5f,
				0,
				2
			);
			rigibody2D.velocity = new Vector2 (velocidadeX,
				rigibody2D.velocity.y	
			);

			transform.localScale = new Vector2 (2, 2);
			//aqui, é onde invertemos o sentido do boneco (direita,esquerda)
			//utilizando somente o eixoX, modificando conforme o movimento

		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			float velocidadeX =
				Mathf.Clamp (
					rigibody2D.velocity.x - 0.5f,
					-2,
					0);

			rigibody2D.velocity = new Vector2 (velocidadeX,
				rigibody2D.velocity.y	
			);
			transform.localScale = new Vector2 (-2, 2);
			//aqui, é onde invertemos o sentido do boneco (direita,esquerda)
			//utilizando somente o eixoX, modificando conforme o movimento
		}
		if(Input.GetKeyDown (KeyCode.UpArrow)){
			Rigidbody2D rigibody = GetComponent<Rigidbody2D> ();
			rigibody.AddForce(new Vector2(0,250));	
			tocadorAudio.PlayOneShot(pulo);		
		}
	}
	private void OnDestroy(){
		Debug.Log ("Personagem Destruído");
	}

}
