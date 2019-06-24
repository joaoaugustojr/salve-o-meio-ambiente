using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoColet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Player Colidiu com lixo!!");
            gameObject.SetActive(false);
            LevelController.levelController.coletaLixo();
        }
    }
}
