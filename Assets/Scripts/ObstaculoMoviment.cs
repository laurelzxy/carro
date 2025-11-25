using UnityEngine;

public class ObstaculoMoviment : MonoBehaviour
{
    public float speed = 5f;

    public int damage = 1;


    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se colidiu com o player
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        Debug.Log("Colidiu com: " + other.name);

        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject); // destrói o obstáculo após dano
        }
    }
}
