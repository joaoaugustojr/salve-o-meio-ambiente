using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    //private static AudioSource audioSource;

    public Text pontuacaoMaxima;
    public Text pontuacao;
    public AudioClip audioClick;

    void Awake()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        //DontDestroyOnLoad(audioSource);
    }

    public void pauseGame()
    {
        gameObject.SetActive(true);
        //audioSource.clip = audioClick;
        //audioSource.Play();
        pontuacao.text = LevelController.levelController.getPontuacao().ToString();
        pontuacaoMaxima.text = LevelController.levelController.pontuacaoMaxima.ToString();
        Time.timeScale = 0;
    }

    public void resumeLevel()
    {   
        //audioSource.clip = audioClick;
        //audioSource.Play();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void repetirLevel()
    {
        //audioSource.clip = audioClick;
        //audioSource.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
