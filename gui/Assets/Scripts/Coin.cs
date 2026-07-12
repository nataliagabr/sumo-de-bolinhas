using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BolinhaController bolinha = other.GetComponent<BolinhaController>();

        if (bolinha != null)
        {
            bolinha.ColetarMoeda();

            PlayerObserverManager.NotifyCoinCollected();

            Destroy(gameObject);
        }
    }
}