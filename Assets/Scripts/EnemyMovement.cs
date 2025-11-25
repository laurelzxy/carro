using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    public float speed = 2f;              // velocidade para baixo
    public float lateralSpeed = 1f;       // velocidade lateral
    public float minX = -2.5f;            // limite lateral esquerdo
    public float maxX = 2.5f;             // limite lateral direito
    public float delayBeforeMove = 10f;   // tempo antes dele começar a descer

    private float targetX;                // posição X que ele vai se mover
    private float descendTargetY;         // posição Y que ele deve parar de descer
    private bool reachedDescendPosition = false;
    private float timer = 0f;             // temporizador para o delay
    private bool startedMoving = false;   // controle se o movimento já começou

    void Start()
    {
        // posição X aleatória pra ele vir de lado
        targetX = Random.Range(minX, maxX);

        // posição Y que ele precisa chegar (desce só um pouco)
        descendTargetY = transform.position.y - Random.Range(1f, 2f);
    }

    void Update()
    {
        // --- DELAY ANTES DE COMEÇAR A DESCER ---
        if (!startedMoving)
        {
            timer += Time.deltaTime;

            if (timer >= delayBeforeMove)
                startedMoving = true;
            else
                return; // não faz nada até o delay acabar
        }

        // --- PRIMEIRA FASE: DESCER UM POUCO ---
        if (!reachedDescendPosition)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(transform.position.x, descendTargetY),
                speed * Time.deltaTime
            );

            if (Mathf.Abs(transform.position.y - descendTargetY) < 0.05f)
                reachedDescendPosition = true;
        }
        else
        {
            // --- SEGUNDA FASE: MOVIMENTO LATERAL ALEATÓRIO ---
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(targetX, transform.position.y),
                lateralSpeed * Time.deltaTime
            );

            // quando chegar perto do alvo, escolhe outro aleatório
            if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
            {
                targetX = Random.Range(minX, maxX);
            }
        }
    }
}
