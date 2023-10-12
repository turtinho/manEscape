using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocadorAudio : MonoBehaviour {
	private static AudioSource tocador;
	public static AudioSource Tocador
	{
		get {return tocador;}
	}
	static TocadorAudio()
	{
		GameObject gameObject = new GameObject("TocadorAudio");
		gameObject.AddComponent<TocadorAudio>();
		//A cena é recarregada e todos os objetos são destruídos, para evitar:
		GameObject.DontDestroyOnLoad(gameObject);
	}
	private void Awake(){
		tocador = gameObject.AddComponent<AudioSource>();
		AudioClip musica = Resources.Load<AudioClip>("musica");

		AudioSource tocadorMusica = gameObject.AddComponent<AudioSource> ();
		tocadorMusica.clip = musica;
		tocadorMusica.loop = true;
		tocadorMusica.Play();
	}
}

