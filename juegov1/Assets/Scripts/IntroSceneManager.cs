using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    // Referencia al botón de Play
    public Button playButton;
    

    void Start()
    {
    }
    public void StartGame()
    {
        // Asignar la función al botón de Play
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }
        else
        {
            Debug.LogError("❌ No se asignó el botón de Play en el Inspector.");
        }
    }

    // Función que se ejecuta cuando se hace clic en el botón de Play
    void OnPlayButtonClicked()
    {
        Debug.Log("🎮 Botón de Play clickeado - Cambiando a PantallaInicial");
        SceneManager.LoadScene("PantallaInicial");
    }
}