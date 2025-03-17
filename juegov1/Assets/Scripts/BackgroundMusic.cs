using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Agregar componente si no lo tiene
        AudioClip music = Resources.Load<AudioClip>("musicFondo"); // Cargar el audio desde Resources

        if (music != null)
        {
            audioSource.clip = music;
            audioSource.loop = true; // Para que la música se repita
            audioSource.volume = 0.5f; // Ajustar volumen si es necesario
            audioSource.Play(); // Reproducir música
        }
        else
        {
            Debug.LogError("No se encontró el audio en Resources. Verifica el nombre.");
        }
    }
}
