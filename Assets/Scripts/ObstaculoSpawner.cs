using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaculoPrefab;
    public GameObject powerUpPrefab;

    public float spawnInterval = 1.5f;

    // limites da pista
    public float minX = -2.5f;
    public float maxX = 2.5f;

    [Range(0, 100)]
    public int chancePowerUp = 20; // porcentagem de gerar power-up

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObj();
            timer = 0f;
        }
    }

    void SpawnObj()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);

        int sorteio = Random.Range(0, 100);

        if (sorteio < chancePowerUp)
        {
            // spawna um power-up
            Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            // spawna um obstáculo
            Instantiate(obstaculoPrefab, spawnPos, Quaternion.identity);
        }
    }
}
