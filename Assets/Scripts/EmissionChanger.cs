using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmissionChanger : MonoBehaviour
{
    private readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    [SerializeField] private Material mat;
    
    private Light m_light;
    private Color m_initialColor;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        m_light = GetComponentInChildren<Light>();
        if (mat == null)
        {
            mat = GetComponent<Renderer>().material;
        }
        m_initialColor = mat.color;

        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            mat.SetColor(EmissionColor, m_initialColor * (m_light.gameObject.activeSelf ? 1 : 0));
        }
    }
}
