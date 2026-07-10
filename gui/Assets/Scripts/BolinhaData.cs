using UnityEngine;

[CreateAssetMenu(fileName = "NovaBolinha", menuName = "Sumo/Bolinha Data")]
public class BolinhaData : ScriptableObject
{
    [Header("Informações")]
    public string nomeBolinha;

    [Header("Visual")]
    public Material material;

    [Header("Status")]
    public float velocidade = 5f;
    public float forca = 10f;
    public float peso = 1f;
    public float tamanho = 1f;
}

