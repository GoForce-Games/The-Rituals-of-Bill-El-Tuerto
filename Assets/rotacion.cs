using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    public Transform objetoARotar;
    public float velocidad = 90f; // grados por segundo
    private float objetivoZ = 50f;
    private bool haLlegado = false;

    void Update()
    {
        if (objetoARotar == null || haLlegado) return;

        // Obtener rotación actual en ángulos de Euler
        Vector3 rotacionActual = objetoARotar.localEulerAngles;

        // Convertir ángulo a rango -180 a 180 para comparación precisa
        float zActual = NormalizeAngle(rotacionActual.z);

        // Si ya hemos llegado (con margen), fijar rotación y salir
        if (Mathf.Abs(zActual - objetivoZ) < 0.1f)
        {
            objetoARotar.localRotation = Quaternion.Euler(rotacionActual.x, rotacionActual.y, objetivoZ);
            haLlegado = true;
            return;
        }

        // Rotar suavemente hacia objetivo
        float nuevaZ = Mathf.MoveTowardsAngle(zActual, objetivoZ, velocidad * Time.deltaTime);
        objetoARotar.localRotation = Quaternion.Euler(rotacionActual.x, rotacionActual.y, nuevaZ);
    }

    // Normaliza ángulo a rango -180 a 180 para comparar correctamente
    float NormalizeAngle(float angle)
    {
        angle = angle % 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
