using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControlle : MonoBehaviour {

    private Queue<string> palavras;
    public Text nome, descricao;
    public GameObject dialogUI;

	void Start () {
        palavras = new Queue<string>();
	}

    public void StartDialog(Dialog dialog)
    {
        Time.timeScale = 0;
        dialogUI.SetActive(true);
        nome.text = dialog.nome;
        palavras.Clear();

        foreach (string palavra in dialog.palavras)
        {
            palavras.Enqueue(palavra);
        }

        ProximaPalavra();
    }

    public void ProximaPalavra()
    {
        if (palavras.Count == 0)
        {
            Time.timeScale = 1;
            dialogUI.SetActive(false);
        } else
        {
            string frase = palavras.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSequence(frase));
        }
    }

    IEnumerator TypeSequence(string frase)
    {
        descricao.text = "";

        foreach (char letra in frase.ToCharArray())
        {
            descricao.text += letra;
            yield return null;
        }
    }
}
