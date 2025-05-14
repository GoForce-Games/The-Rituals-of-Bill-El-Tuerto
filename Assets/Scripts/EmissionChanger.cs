using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmissionChanger : MonoBehaviour
{
    private readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    public float storedValue;

    [SerializeField] private Material mat;
    
    private Light light;
    private Color initialColor;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        light = GetComponentInChildren<Light>();
        if (mat == null)
        {
            mat = GetComponent<Renderer>().material;
        }
        initialColor = mat.color;

        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            mat.SetColor(EmissionColor, initialColor * (light.gameObject.activeSelf ? 1 : 0));
        }
    }
}
