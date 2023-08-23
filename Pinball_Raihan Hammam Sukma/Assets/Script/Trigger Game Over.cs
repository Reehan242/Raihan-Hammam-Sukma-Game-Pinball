using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    public Collider bola;
    public GameObject gameOver;
    public GameOverUIController gameOverUIController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola) 
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= 0;
            gameOver.SetActive(true);
        }
    }
}
