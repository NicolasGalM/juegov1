using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;
    public AudioClip deathSound;     
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * 5f, rb.linearVelocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 8f);
        }

        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (collision.gameObject.CompareTag("EnemyFire"))
        {
            Die();
        }

        // 🔹 Si el jugador toca el TargetStar, llama al GameManager para cambiar de escena
        if (collision.gameObject.CompareTag("Star"))
        {
            Debug.Log("Jugador tocó TargetStar. Solicitando cambio de escena a GameManager...");
            
            if (GameManager.instance != null)
            {
                GameManager.instance.CambiarEscena("Segunda"); // El GameManager maneja el cambio de nivel
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Abs(theScale.x) * (facingRight ? 1 : -1); 
        transform.localScale = theScale;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void Die()
    {
        if (audioSource && deathSound)
        {
            audioSource.PlayOneShot(deathSound);
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.ReduceVidas();

            if (GameManager.instance.vidas <= 0)
            {
                return;
            }

            Debug.Log("Te quedan " + GameManager.instance.vidas + " vidas");
        }

        Invoke("RestartLevel", 2f);
    }

    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
