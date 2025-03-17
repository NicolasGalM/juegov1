using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Punto inicial
    public Transform pointB; // Punto final
    public float speed = 2f; // Velocidad de movimiento

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = pointB.position; // Inicia moviéndose hacia el punto B
    }

    void FixedUpdate()
    {
        // Mueve la plataforma suavemente entre los puntos
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);

        // Cambia de dirección al llegar a un punto
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }

    // 🔹 Cuando el Player toca la plataforma, se vuelve su "hijo" (para moverse con ella)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // 🔹 Cuando el Player deja la plataforma, se separa de ella
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
