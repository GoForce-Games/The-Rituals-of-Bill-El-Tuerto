using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class ValidadorFrase : MonoBehaviour
{
    public TMP_InputField campoTexto;
    public GameObject pistasSangre; // lo que aparece en la pared
    public GameObject tecladoFlotante;
    
    // Referencias al teclado XR
    private bool tecladoEstadoAnterior = true;
    private bool validando = false;
    
    private void Start()
    {
        pistasSangre.SetActive(false);
        
        // Asegurarnos de que tenemos asignado el campo de texto
        if (campoTexto == null)
        {
            Debug.LogError("¡El campo de texto no está asignado en el ValidadorFrase!");
            return;
        }
        
        // Añadir escuchador para detectar cuando se envía el texto (Enter tradicional)
        campoTexto.onEndEdit.AddListener(OnEndEdit);
    }
    
    private void Update()
    {
        // Detectamos si el teclado flotante se ha cerrado
        if (tecladoFlotante != null)
        {
            bool tecladoActivoAhora = tecladoFlotante.activeSelf;
            
            // Si el teclado estaba activo pero ahora no está activo (se cerró)
            if (tecladoEstadoAnterior && !tecladoActivoAhora && !validando)
            {
                Debug.Log("Teclado cerrado - validando texto");
                validando = true;
                
                // Ejecutar validación y quitar foco
                StartCoroutine(ValidarDespuesDeEspera(0.1f));
            }
            
            tecladoEstadoAnterior = tecladoActivoAhora;
        }
    }
    
    IEnumerator ValidarDespuesDeEspera(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        ValidarFrase();
        // Quitar el foco del campo de texto para que deje de parpadear el cursor
        EventSystem.current.SetSelectedGameObject(null);
        validando = false;
    }
    
    private void OnEndEdit(string text)
    {
        // Para el caso del Enter tradicional (probablemente no se use en XR pero por si acaso)
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (!validando)
            {
                validando = true;
                ValidarFrase();
                EventSystem.current.SetSelectedGameObject(null);
                validando = false;
            }
        }
    }
    
    public void ValidarFrase()
    {
        string frase = campoTexto.text.Trim().ToLower();
        Debug.Log("Validando frase: " + frase);
        
        if (frase == "la llave es el zapato")
        {
            Debug.Log("¡Frase correcta!");
            pistasSangre.SetActive(true);
            tecladoFlotante.SetActive(false); // ocultar el teclado tras acertar
            campoTexto.interactable = false; // opcional: desactivar el campo de texto después de acertar
        }
        else
        {
            Debug.Log("Frase incorrecta");
            // feedback de error si quieres (vibración, color rojo, etc)
            // Ejemplo de feedback visual temporal:
            Color originalColor = campoTexto.textComponent.color;
            campoTexto.textComponent.color = Color.red;
            Invoke("ResetTextColor", 0.5f);
        }
    }
    
    private void ResetTextColor()
    {
        if (campoTexto != null && campoTexto.textComponent != null)
        {
            campoTexto.textComponent.color = Color.black; // Restablece al color original
        }
    }
    
    // Para llamar a la validación desde un botón externo si es necesario
    public void ValidarDesdeBoton()
    {
        ValidarFrase();
        EventSystem.current.SetSelectedGameObject(null); // Quitar el foco
    }
}