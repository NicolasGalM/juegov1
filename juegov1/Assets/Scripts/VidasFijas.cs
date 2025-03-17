using UnityEngine;

public class VidasFijas : MonoBehaviour
{
    public Transform camara; // Referencia a la cámara
    private Vector3 offset; // Distancia inicial entre la cámara y las vidas
    private bool mostrarVidas = false; // Controla si las vidas son visibles
    public Transform player; // Referencia al jugador

    void Start()
    {
        if (player == null || camara == null)
        {
            Debug.LogError("❌ No se han asignado Player o Cámara en VidasFijas.");
            return;
        }

        // Guardamos la diferencia inicial entre la cámara y las vidas para mantener la posición fija
        offset = transform.position - camara.position;

        // Ocultar las vidas hasta que el jugador se mueva
        SetVidasVisible(false);
    }

    void LateUpdate()
    {
        if (!mostrarVidas && Mathf.Abs(player.position.x) > 0.1f) // Aparecen cuando el jugador se mueve un poco
        {
            mostrarVidas = true;
            SetVidasVisible(true);
        }

        // 🔹 Mantener las vidas en la misma posición relativa con la cámara
        transform.position = camara.position + offset;
    }

    private void SetVidasVisible(bool visible)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(visible);
        }
    }
}
