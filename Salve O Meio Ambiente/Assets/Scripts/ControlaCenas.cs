using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaCenas : MonoBehaviour
{
    public string nomeDaCena;
    public int tempoMaximo = 0;
    private int tempo = 0;

    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0) // 0 cena da intro
        {
            if (tempo == tempoMaximo)
            {
                SceneManager.LoadScene(nomeDaCena);
                tempo = 0;
            }
            else
            {
                tempo = (int)Time.time;
            }
        }
    }

    public void carregaCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }

    public void sairJogo()
    {
        Application.Quit();
    }
}
