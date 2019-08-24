using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Text pontuacaoMaxima;
    public Text pontuacao;
    public AudioClip audioClick;

    public void pauseGame()
    {
        gameObject.SetActive(true);

        pontuacao.text = LevelController.levelController.getPontuacao().ToString();
        pontuacaoMaxima.text = LevelController.levelController.pontuacaoMaxima.ToString();
        Time.timeScale = 0;
    }

    public void resumeLevel()
    {   
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void repetirLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
