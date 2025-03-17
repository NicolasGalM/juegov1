using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 3;
    private static GameManager audioListenerInstance;

    void Awake()
    {
        // Si ya existe una instancia del GameManager, destruye este objeto duplicado
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar escenas
        }

        // Verificar si ya hay un AudioListener activo
        if (audioListenerInstance == null)
        {
            audioListenerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // Cargar la IntroScene al inicio del juego
        SceneManager.LoadScene("IntroScene");

        // Llamar a la función para cambiar a PantallaInicial después de un retraso
        Invoke("CargarPantallaInicial", 5f); // 5 segundos de retraso
    }

    void CargarPantallaInicial()
    {
        SceneManager.LoadScene("PantallaInicial");
    }
    public void ReduceVidas()
{
    vidas--;

    Debug.Log($"⚠️ Vida reducida. Vidas restantes: {vidas}");

    VidasUI vidasUI = FindObjectOfType<VidasUI>();
    if (vidasUI != null)
    {
        Debug.Log("🔄 Llamando a ActualizarVidas()");
        vidasUI.ActualizarVidas(vidas);
    }
    else
    {
        Debug.LogError("❌ No se encontró VidasUI en la escena.");
    }

    if (vidas <= 0)
    {
        Debug.Log("💀 Game Over - Cambiando a escena GameOver");
        SceneManager.LoadScene("GameOver");
    }
}




    // 🔹 Método para aumentar vidas sin exceder el límite de 3
    public void AumentarVida()
    {
        if (vidas < 3)
        {
            vidas++;
            Debug.Log("Vida extra obtenida. Vidas actuales: " + vidas);
        }
    }

    // 🔹 Método para cambiar de escena y aumentar vidas si es necesario
    public void CambiarEscena(string nombreEscena)
    {
        Debug.Log("Cambiando de escena a: " + nombreEscena);
        
        // Aumentar vida solo si es menor a 3
        AumentarVida();

        // Cambiar de escena
        SceneManager.LoadScene(nombreEscena);
    }
}
