using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEditor;

[Serializable]
class PlayerData
{
    public int[] maxPontuacao = new int[6];
    public bool[] lockFase = new bool[6];
}

public class LevelController : MonoBehaviour
{
    #region VARIAVEIS

    private int pontuacao = 0;
    private int tempo = 0;
    private bool gameOver;
    private bool coletando = false;
    private Animator lixoAnim;
    private AudioSource audioSource;
    private string filePath;

    public static LevelController levelController;
    public static int jogadorEscolhido = 1;
    public int pontuacaoMaxima = 20;

    public Text pontuacaoText, pontuacaoMaxText;
    public GameObject gameoverPainel;
    public GameObject lataDeLixoUI, fimDeFaseUI;
    public GameObject play1, play2, play3, play4;
    public GameObject estrela1, estrela2, estrela3;
    public GameObject audioBackgroud;
    public AudioClip audioColetaLixo, audioGameOver;
    public Color corHabilitada = new Color(255, 255, 255, 255);

    #endregion

    void Awake()
    {
        if (levelController == null)
        {
            levelController = this;
        }
        else if (levelController != this)
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/playerInfoGame.dat";
        audioSource = gameObject.GetComponent<AudioSource>();

        selecionaJogador();

        if (!File.Exists(filePath))
        {
            ResetGame();
        }

    }

    void Start()
    {

        Time.timeScale = 1;
        lixoAnim = lataDeLixoUI.GetComponent<Animator>();
        pontuacaoText.text = getPontuacao().ToString();
        pontuacaoMaxText.text = getPontuacaoMaxima().ToString();

    }

    void Update()
    {
        if (gameOver)
        {
            gameoverPainel.SetActive(true);
            Time.timeScale = 0;
        }

        if (coletando)
        {

            if (tempo >= 50)
            {
                lixoAnim.SetBool("Coleta", false);
                coletando = false;
                tempo = 0;
            }
            else
            {
                tempo++;
            }

        }
    }

    public void selecionaJogador()
    {
        switch (jogadorEscolhido)
        {
            case 1:
                play1.SetActive(true);
                play2.SetActive(false);
                play3.SetActive(false);
                play4.SetActive(false);
                break;
            case 2:
                play2.SetActive(true);
                play1.SetActive(false);
                play3.SetActive(false);
                play4.SetActive(false);
                break;
            case 3:
                play3.SetActive(true);
                play1.SetActive(false);
                play2.SetActive(false);
                play4.SetActive(false);
                break;
            case 4:
                play4.SetActive(true);
                play1.SetActive(false);
                play2.SetActive(false);
                play3.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void coletaLixo()
    {
        audioSource.clip = audioColetaLixo;
        audioSource.Play();
        coletando = true;
        lixoAnim.SetBool("Coleta", true);
        pontuacao++;
        pontuacaoText.text = pontuacao.ToString();
    }

    public void AtivarMenuFimDeFase()
    {
        fimDeFaseUI.SetActive(true);
        Time.timeScale = 0;

        if (pontuacao == 0)
        {
            SaveGame(0);
        }
        else if (pontuacao <= (pontuacaoMaxima / 2))
        {
            //Debug.Log("UMA ESTRELA");
            estrela1.GetComponent<Image>().color = corHabilitada;
            SaveGame(1);
        }
        else if (pontuacao > (pontuacaoMaxima / 2) && pontuacao < pontuacaoMaxima)
        {
            //Debug.Log("DUAS ESTRELAS");
            estrela1.GetComponent<Image>().color = corHabilitada;
            estrela2.GetComponent<Image>().color = corHabilitada;
            SaveGame(2);
        }
        else if (pontuacao == pontuacaoMaxima)
        {
            //Debug.Log("TRES ESTRELAS");
            estrela1.GetComponent<Image>().color = corHabilitada;
            estrela2.GetComponent<Image>().color = corHabilitada;
            estrela3.GetComponent<Image>().color = corHabilitada;
            SaveGame(3);
        }
    }

    public void GameOver()
    {
        audioBackgroud.GetComponent<AudioSource>().Stop();
        audioSource.clip = audioGameOver;
        audioSource.Play();
        gameOver = true;
    }

    public void SaveGame(int estrelas)
    {
        string fase = SceneManager.GetActiveScene().name;
        int[] maxEstrelas = LoadGame();

        BinaryFormatter bf = new BinaryFormatter(); //escreve dados no arquivo
        FileStream fso = File.Open(filePath, FileMode.Open);
        PlayerData playerData = (PlayerData)bf.Deserialize(fso);
        fso.Close();

        switch (fase)
        {
            case "Fase01":
                if (estrelas > maxEstrelas[0])
                {
                    playerData.maxPontuacao[0] = estrelas;
                    //Debug.Log("Pontuacao Atualizada!");
                    if (estrelas >= 2)
                    {
                        playerData.lockFase[1] = false;
                    }
                }
                break;
            case "Fase02":
                if (estrelas > maxEstrelas[1])
                {
                    playerData.maxPontuacao[1] = estrelas;
                    //Debug.Log("Pontuacao Atualizada!");
                    if (estrelas >= 2)
                    {
                        playerData.lockFase[2] = false;
                    }
                }
                break;
            case "Fase03":
                if (estrelas > maxEstrelas[2])
                {
                    playerData.maxPontuacao[2] = estrelas;
                    //Debug.Log("Pontuacao Atualizada!");
                    if (estrelas >= 2)
                    {
                        playerData.lockFase[3] = false;
                    }
                }
                break;
            case "Fase04":
                if (estrelas > maxEstrelas[3])
                {
                    playerData.maxPontuacao[3] = estrelas;
                    //Debug.Log("Pontuacao Atualizada!");
                    if (estrelas >= 2)
                    {
                        playerData.lockFase[4] = false;
                    }
                }
                break;
            case "Fase05":
                if (estrelas > maxEstrelas[4])
                {
                    playerData.maxPontuacao[4] = estrelas;
                    //Debug.Log("Pontuacao Atualizada!");
                    if (estrelas >= 2)
                    {
                        playerData.lockFase[5] = false;
                    }
                }
                break;
            case "Fase06":
                if (estrelas > maxEstrelas[5])
                {
                    playerData.maxPontuacao[5] = estrelas;
                    //desabilitar proxima fase
                    //colocar msg final de jogo
                    //voltar para escolha de personagens
                }
                break;
            default:
                break;
        }

        FileStream fs = File.Create(filePath);
        bf.Serialize(fs, playerData);
        fs.Close();
    }

    public int[] LoadGame()
    {
        int[] pontuacaoSalva = new int[6];


        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(filePath, FileMode.Open);

            PlayerData playerData = (PlayerData)bf.Deserialize(fs);
            fs.Close();

            pontuacaoSalva = playerData.maxPontuacao;
        }

        return pontuacaoSalva;
    }

    public bool[] GetLockScenes()
    {
        bool[] locks = new bool[6];

        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(filePath, FileMode.Open);

            PlayerData playerData = (PlayerData)bf.Deserialize(fs);
            fs.Close();

            locks = playerData.lockFase;
        }

        return locks;
    }

    public void ResetGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); //escreve dados no arquivo
        FileStream fs = File.Create(filePath);
        PlayerData playerData = new PlayerData();

        for (int i = 0; i < 6; i++)
        {
            playerData.maxPontuacao[i] = 0;
            playerData.lockFase[i] = true;
        }

        bf.Serialize(fs, playerData);
        fs.Close();
    }

    public void Jogador01()
    {
        jogadorEscolhido = 1;
    }

    public void Jogador02()
    {
        jogadorEscolhido = 2;
    }

    public void Jogador03()
    {
        jogadorEscolhido = 3;
    }

    public void Jogador04()
    {
        jogadorEscolhido = 4;
    }

    public int getPontuacao()
    {
        return pontuacao;
    }

    public int getPontuacaoMaxima()
    {
        return pontuacaoMaxima;
    }

}
