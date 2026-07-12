using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BolinhaController))]
public class PushAbility : MonoBehaviour
{
    public float alcance = 5f;
    public float cooldown = 3f;

    private float proximoUso;
    private BolinhaController bolinha;

    private void Awake()
    {
        bolinha = GetComponent<BolinhaController>();
    }

    public void OnPush(InputValue value)
    {
        if (!value.isPressed)
            return;

        if (Time.time < proximoUso)
            return;

        GameObject inimigo = gameObject.CompareTag("Player")
            ? GameObject.FindGameObjectWithTag("Player2")
            : GameObject.FindGameObjectWithTag("Player");

        if (inimigo == null)
            return;

        Rigidbody rbInimigo = inimigo.GetComponent<Rigidbody>();

        Vector3 direcao = (inimigo.transform.position - transform.position).normalized;

        float distancia = Vector3.Distance(transform.position, inimigo.transform.position);

        if (distancia > alcance)
            return;

        float multiplicador = 1f - (distancia / alcance);

        rbInimigo.AddForce(
            direcao * bolinha.ForcaAtual * multiplicador,
            ForceMode.Impulse);

        proximoUso = Time.time + cooldown;
    }
}