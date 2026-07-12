using UnityEngine;
using System.Collections;

public class RoundManager : MonoBehaviour
{
    public int pontosP1 = 0;
    public int pontosP2 = 0;

    public Transform bolinhaP1;
    public Transform bolinhaP2;

    public DeathZone deathZone;


    private Vector3 posicaoInicialP1;
    private Vector3 posicaoInicialP2;

    private bool roundEmAndamento = false;


    void Start()
    {
        posicaoInicialP1 = bolinhaP1.position;
        posicaoInicialP2 = bolinhaP2.position;

        StartCoroutine(IniciarRound());
    }


    IEnumerator IniciarRound()
    {
        yield return new WaitForSeconds(3);

        roundEmAndamento = true;

        Debug.Log("Round iniciado!");
    }


    public void Player1WinsRound()
    {
        if(!roundEmAndamento)
            return;


        roundEmAndamento = false;

        pontosP1++;

        Debug.Log("Jogador 1 ganhou o round!");
        Debug.Log("Placar: P1 " + pontosP1 + " x " + pontosP2 + " P2");


        VerificarVencedor();

        StartCoroutine(RestartRound());
    }


    public void Player2WinsRound()
    {
        if(!roundEmAndamento)
            return;


        roundEmAndamento = false;

        pontosP2++;

        Debug.Log("Jogador 2 ganhou o round!");
        Debug.Log("Placar: P1 " + pontosP1 + " x " + pontosP2 + " P2");


        VerificarVencedor();

        StartCoroutine(RestartRound());
    }



    void VerificarVencedor()
    {
        if(pontosP1 >= 2)
        {
            Debug.Log("JOGADOR 1 VENCEU A PARTIDA!");
            
            // Depois vamos carregar a cena de vitória
        }


        if(pontosP2 >= 2)
        {
            Debug.Log("JOGADOR 2 VENCEU A PARTIDA!");

            // Depois vamos carregar a cena de vitória
        }
    }



    IEnumerator RestartRound()
    {
        yield return new WaitForSeconds(2);


        bolinhaP1.position = posicaoInicialP1;
        bolinhaP2.position = posicaoInicialP2;


        Rigidbody rb1 = bolinhaP1.GetComponent<Rigidbody>();
        Rigidbody rb2 = bolinhaP2.GetComponent<Rigidbody>();


        rb1.linearVelocity = Vector3.zero;
        rb1.angularVelocity = Vector3.zero;


        rb2.linearVelocity = Vector3.zero;
        rb2.angularVelocity = Vector3.zero;


        if(deathZone != null)
        {
            deathZone.LiberarRound();
        }


        yield return new WaitForSeconds(1);


        roundEmAndamento = true;

        Debug.Log("Novo round iniciado!");
    }
}