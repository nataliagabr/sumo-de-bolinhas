using UnityEngine;
using TMPro;

public class BolinhaCardUI : MonoBehaviour
{
    public BolinhaData bolinha;

    public TMP_Text nomeTexto;
    public TMP_Text atributosTexto;


    void Start()
    {
        AtualizarCard();
    }


    public void AtualizarCard()
    {
        if(bolinha == null)
            return;


        nomeTexto.text = bolinha.nomeBolinha;


        atributosTexto.text =
        "Velocidade: " + bolinha.velocidade +
        "\nForça: " + bolinha.forca +
        "\nPeso: " + bolinha.peso;
    }
}