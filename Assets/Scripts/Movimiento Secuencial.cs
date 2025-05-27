using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRelativo : MonoBehaviour
{
    public Vector3 desplazamiento1 = new Vector3(3, 0, 0);  // Por ejemplo: +3 en X
    public Vector3 desplazamiento2 = new Vector3(0, 0, 5);  // Por ejemplo: +5 en Z

    void Start()
    {
        StartCoroutine(MoverSecuencial());
    }

    System.Collections.IEnumerator MoverSecuencial()
    {
        // Guarda la posición inicial
        Vector3 inicio = transform.position;

        // Calcula destino1 relativo
        Vector3 destino1 = inicio + desplazamiento1;
        yield return StartCoroutine(MoverAObjetivo(destino1, 1f));

        // Calcula destino2 relativo desde destino1
        Vector3 destino2 = destino1 + desplazamiento2;
        yield return StartCoroutine(MoverAObjetivo(destino2, 1f));
    }

    System.Collections.IEnumerator MoverAObjetivo(Vector3 objetivo, float duracion)
    {
        Vector3 posicionInicial = transform.position;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            transform.position = Vector3.Lerp(posicionInicial, objetivo, tiempo / duracion);
            yield return null;
        }

        transform.position = objetivo;
    }
}