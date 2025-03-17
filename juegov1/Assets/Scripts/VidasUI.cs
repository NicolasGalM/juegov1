using UnityEngine;

public class VidasUI : MonoBehaviour
{
    public SpriteRenderer[] corazones; // Array de corazones (GameObjects con SpriteRenderer)
    public Sprite corazonLleno; // Sprite de corazón lleno
    public Sprite corazonVacio; // Sprite de corazón vacío

    void Start()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("❌ GameManager no está inicializado en VidasUI.");
            return;
        }

        ActualizarVidas(GameManager.instance.vidas);
    }

    public void ActualizarVidas(int cantidadVidas)
    {
        if (corazones == null || corazones.Length == 0)
        {
            Debug.LogError("❌ El array de corazones no está inicializado en el Inspector.");
            return;
        }

        Debug.Log($"🔄 Actualizando UI de vidas: {cantidadVidas} vidas");

        for (int i = 0; i < corazones.Length; i++)
        {
            if (corazones[i] != null)
            {
                corazones[i].sprite = (i < cantidadVidas) ? corazonLleno : corazonVacio;
                Debug.Log($"🖼️ Corazón {i} cambiado a {(i < cantidadVidas ? "Lleno" : "Vacío")}");
            }
            else
            {
                Debug.LogError($"❌ Corazón en índice {i} no está asignado en el Inspector.");
            }
        }
    }
}
