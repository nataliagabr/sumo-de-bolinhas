using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float tempoSpawn = 5f;

    public Vector2 limiteX = new Vector2(-8, 8);
    public Vector2 limiteZ = new Vector2(-8, 8);

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 2f, tempoSpawn);
    }

    void SpawnCoin()
    {
        Vector3 posicao = new Vector3(
            Random.Range(limiteX.x, limiteX.y),
            0.5f,
            Random.Range(limiteZ.x, limiteZ.y));

        Instantiate(coinPrefab, posicao, Quaternion.identity);
    }
}