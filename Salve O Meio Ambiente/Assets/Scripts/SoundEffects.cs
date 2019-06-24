using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip audioClick;

	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}

    public void audioClickPlay()
    {
        audioSource.clip = audioClick;
        audioSource.Play();
    }

}
