using UnityEngine;

public class SelecaoBolinhaUI : MonoBehaviour
{
    public void EscolherBolinhaP1(BolinhaData bolinha)
    {
        if(GameManager.Instance == null)
        {
            Debug.LogError("GameManager não encontrado!");
            return;
        }


        GameManager.Instance.EscolherBolinhaJogador1(bolinha.nomeBolinha);

        Debug.Log("Jogador 1 escolheu: " + bolinha.nomeBolinha);
    }



    public void EscolherBolinhaP2(BolinhaData bolinha)
    {
        if(GameManager.Instance == null)
        {
            Debug.LogError("GameManager não encontrado!");
            return;
        }


        GameManager.Instance.EscolherBolinhaJogador2(bolinha.nomeBolinha);

        Debug.Log("Jogador 2 escolheu: " + bolinha.nomeBolinha);
    }
}