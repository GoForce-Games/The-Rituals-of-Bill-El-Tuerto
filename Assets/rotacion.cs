using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    public Transform objetoARotar;
    public float velocidad = 90f; 
    private float objetivoZ = 50f;
    private bool haLlegado = false;

    void Update()
    {
        if (objetoARotar == null || haLlegado) return;

        
        Vector3 rotacionActual = objetoARotar.localEulerAngles;

        
        float zActual = NormalizeAngle(rotacionActual.z);

        
        if (Mathf.Abs(zActual - objetivoZ) < 0.1f)
        {
            objetoARotar.localRotation = Quaternion.Euler(rotacionActual.x, rotacionActual.y, objetivoZ);
            haLlegado = true;
            return;
        }

       
        float nuevaZ = Mathf.MoveTowardsAngle(zActual, objetivoZ, velocidad * Time.deltaTime);
        objetoARotar.localRotation = Quaternion.Euler(rotacionActual.x, rotacionActual.y, nuevaZ);
    }

    
    float NormalizeAngle(float angle)
    {
        angle = angle % 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
