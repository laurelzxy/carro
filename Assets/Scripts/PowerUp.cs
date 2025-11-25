using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 3f; // Velocidade de descida

    void Update()
    {
        // Faz o power-up descer
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destrói quando sai da tela
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
