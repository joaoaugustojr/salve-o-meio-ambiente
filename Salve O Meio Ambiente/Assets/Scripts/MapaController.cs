using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapaController : MonoBehaviour
{
    private int[] pontuacao;
    private bool[] lockFases;
    public GameObject[] stars;
    public GameObject[] menusInativos;
    public GameObject[] menusAtivos;
    public Color corHabilitada = new Color(255, 255, 255, 255);

    void Awake()
    {
        pontuacao = LevelController.levelController.LoadGame();
        lockFases = LevelController.levelController.GetLockScenes();

        DesbloqueiaFases();
        IniciaMapa();
    }

    public void PrintDados()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(pontuacao[i]);
            Debug.Log(lockFases[i]);
        }
    }

    public void DesbloqueiaFases()
    {
        for (int i = 1; i < lockFases.Length; i++)
        {
            if (!lockFases[i])
            {
                menusInativos[i].SetActive(false);
                menusAtivos[i].SetActive(true);
            }
        }
    }

    public void IniciaMapa()
    {
        for (int i = 0; i < pontuacao.Length; i++)
        {
            if (pontuacao[i] == 0)
            {
            }

            if (pontuacao[i] == 1)
            {
                if (i == 0)
                {
                    stars[0].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 1)
                {
                    stars[3].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 2)
                {
                    stars[6].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 3)
                {
                    stars[9].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 4)
                {
                    stars[12].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 5)
                {
                    stars[15].GetComponent<Image>().color = corHabilitada;
                }
            }

            if (pontuacao[i] == 2)
            {
                if (i == 0)
                {
                    stars[0].GetComponent<Image>().color = corHabilitada;
                    stars[1].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 1)
                {
                    stars[3].GetComponent<Image>().color = corHabilitada;
                    stars[4].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 2)
                {
                    stars[6].GetComponent<Image>().color = corHabilitada;
                    stars[7].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 3)
                {
                    stars[9].GetComponent<Image>().color = corHabilitada;
                    stars[10].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 4)
                {
                    stars[12].GetComponent<Image>().color = corHabilitada;
                    stars[13].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 5)
                {
                    stars[15].GetComponent<Image>().color = corHabilitada;
                    stars[16].GetComponent<Image>().color = corHabilitada;
                }
            }

            if (pontuacao[i] == 3)
            {
                if (i == 0)
                {
                    stars[0].GetComponent<Image>().color = corHabilitada;
                    stars[1].GetComponent<Image>().color = corHabilitada;
                    stars[2].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 1)
                {
                    stars[3].GetComponent<Image>().color = corHabilitada;
                    stars[4].GetComponent<Image>().color = corHabilitada;
                    stars[5].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 2)
                {
                    stars[6].GetComponent<Image>().color = corHabilitada;
                    stars[7].GetComponent<Image>().color = corHabilitada;
                    stars[8].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 3)
                {
                    stars[9].GetComponent<Image>().color = corHabilitada;
                    stars[10].GetComponent<Image>().color = corHabilitada;
                    stars[11].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 4)
                {
                    stars[12].GetComponent<Image>().color = corHabilitada;
                    stars[13].GetComponent<Image>().color = corHabilitada;
                    stars[14].GetComponent<Image>().color = corHabilitada;
                }
                if (i == 5)
                {
                    stars[15].GetComponent<Image>().color = corHabilitada;
                    stars[16].GetComponent<Image>().color = corHabilitada;
                    stars[17].GetComponent<Image>().color = corHabilitada;
                }
            }
        }
    }
}
