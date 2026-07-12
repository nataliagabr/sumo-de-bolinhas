using UnityEngine;

public class AplicarBolinha : MonoBehaviour
{
    public bool jogador1;

    private void Start()
    {
        AplicarEscolha();
    }


    void AplicarEscolha()
    {
        if(GameManager.Instance == null)
        {
            Debug.LogError("GameManager não encontrado!");
            return;
        }


        string nomeEscolhido;


        if(jogador1)
        {
            nomeEscolhido = GameManager.Instance.bolinhaJogador1;
        }
        else
        {
            nomeEscolhido = GameManager.Instance.bolinhaJogador2;
        }


        Debug.Log("Aplicando bolinha: " + nomeEscolhido);


        BolinhaData dados = BuscarBolinha(nomeEscolhido);


        if(dados == null)
        {
            Debug.LogError("Bolinha não encontrada!");
            return;
        }


        AplicarDados(dados);
    }



    BolinhaData BuscarBolinha(string nome)
    {
        BolinhaData[] bolinhas = Resources.LoadAll<BolinhaData>("Bolinhas");


        foreach(BolinhaData b in bolinhas)
        {
            if(b.nomeBolinha == nome)
            {
                return b;
            }
        }


        return null;
    }



    void AplicarDados(BolinhaData dados)
    {
        Renderer renderer = GetComponent<Renderer>();

        if(renderer != null)
        {
            renderer.material = dados.material;
        }


        transform.localScale = Vector3.one * dados.tamanho;


        Rigidbody rb = GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.mass = dados.peso;
        }
    }
}