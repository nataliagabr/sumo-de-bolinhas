using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BolinhaController : MonoBehaviour
{
    [Header("Dados da Bolinha")]
    public BolinhaData dados;

    private Rigidbody rb;

    public float VelocidadeAtual { get; private set; }
    public float ForcaAtual { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        AplicarDados();
    }

    public void AplicarDados()
    {
        if (dados == null)
            return;

        VelocidadeAtual = dados.velocidade;
        ForcaAtual = dados.forca;

        rb.mass = dados.peso;

        transform.localScale = Vector3.one * dados.tamanho;

        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && dados.material != null)
            renderer.material = dados.material;
    }
}
