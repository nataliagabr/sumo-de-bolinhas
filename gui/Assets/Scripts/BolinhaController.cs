using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BolinhaController : MonoBehaviour
{
    [Header("Dados da Bolinha")]
    public BolinhaData dados;

    private Rigidbody rb;

    public float VelocidadeAtual { get; private set; }
    public float ForcaAtual { get; private set; }

    [Header("Moedas")]
    public int moedas = 0;
    public float aumentoForca = 1f;
    public float aumentoPeso = 0.2f;
    public float reducaoVelocidade = 0.2f;

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

    public void ColetarMoeda()
    {
        moedas++;

        ForcaAtual += aumentoForca;

        rb.mass += aumentoPeso;

        VelocidadeAtual = Mathf.Max(2f, VelocidadeAtual - reducaoVelocidade);

        PlayerObserverManager.NotifyCoinChanged(moedas);
    }
}