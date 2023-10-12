using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour {
	public AudioClip explosao;

	void OnCollisionEnter2D(Collision2D collision2D){
		Destroy (gameObject);
		TocadorAudio.Tocador.PlayOneShot (explosao);
}
}