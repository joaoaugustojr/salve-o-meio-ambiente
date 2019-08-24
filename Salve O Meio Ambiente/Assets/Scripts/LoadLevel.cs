using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {
    
    public string nomeLevel;
    public GameObject loadScreen;
    private Scrollbar sBar;

    void Start()
    {
        sBar = loadScreen.GetComponent<Scrollbar>();
        Time.timeScale = 1;
        StartCoroutine(espera());
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nomeLevel);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            sBar.size = progress;
            yield return null;
        }
    }
}
