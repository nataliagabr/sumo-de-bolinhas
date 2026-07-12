using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public RoundManager roundManager;

    private bool detectou = false;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entrou na ZonaMorte: " + other.name);


        if(detectou)
            return;


        if(other.CompareTag("Player"))
        {
            detectou = true;

            Debug.Log("Jogador 1 caiu!");

            roundManager.Player2WinsRound();
        }


        if(other.CompareTag("Player2"))
        {
            detectou = true;

            Debug.Log("Jogador 2 caiu!");

            roundManager.Player1WinsRound();
        }
    }


    public void LiberarRound()
    {
        detectou = false;
    }
}