using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpriteAnimation : MonoBehaviour
{
    public Image m_Image; // Referencia al componente Image
    public Sprite[] m_SpriteArray; // Array de sprites para la animaci�n
    public float m_Speed = .02f; // Velocidad de la animaci�n
    private int m_IndexSprite; // �ndice del sprite actual
    private Coroutine m_CorotineAnim; // Referencia a la corrutina
    private bool IsDone; // Bandera para detener la animaci�n

    void Start ()
    {
        Func_PlayUIAnim();
    }
    // M�todo para iniciar la animaci�n
    public void Func_PlayUIAnim()
    {
        IsDone = false;
        m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
    }

    // M�todo para detener la animaci�n
    public void Func_StopUIAnim()
    {
        IsDone = true;
        if (m_CorotineAnim != null)
        {
            StopCoroutine(m_CorotineAnim);
        }
    }

    // Corrutina para la animaci�n
    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            m_IndexSprite = 0; // Reiniciar el �ndice si se alcanza el final del array
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite]; // Cambiar el sprite
        m_IndexSprite += 1; // Incrementar el �ndice
        if (IsDone == false)
        {
            m_CorotineAnim = StartCoroutine(Func_PlayAnimUI()); // Llamar a la corrutina de nuevo
        }
    }
}