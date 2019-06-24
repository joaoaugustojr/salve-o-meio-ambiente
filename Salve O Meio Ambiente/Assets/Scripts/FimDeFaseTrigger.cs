using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimDeFaseTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //.Log("Player Colidiu com o fim!!");
            LevelController.levelController.AtivarMenuFimDeFase();
        }
    }
}
