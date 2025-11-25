using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float verticalSpeed = 5f;
    //public float horizontalLimit = 2.5f;
    public float upperLimit = 2f;         // LIMITE até onde pode subir
    public float lowerLimit = -4.5f;        // LIMITE até onde pode descer (se quiser)

    private Rigidbody2D rb;
    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        moveX = 0f;
        moveY = 0f;

        // LADOS
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            moveX = -1f;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            moveX = 1f;

        // CIMA / BAIXO
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            moveY = 1f;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            moveY = -1f;
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(moveX * speed, moveY * verticalSpeed);

        Vector2 newPos = rb.position + move * Time.fixedDeltaTime;

        // LIMITES
        //newPos.x = Mathf.Clamp(newPos.x, -horizontalLimit, horizontalLimit);
        newPos.y = Mathf.Clamp(newPos.y, lowerLimit, upperLimit);

        rb.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Debug.Log("Power-up coletado!");

            // aqui você coloca o efeito do power-up
            // exemplo:
            // speed += 2f;

            Destroy(other.gameObject);
        }
    }
}
