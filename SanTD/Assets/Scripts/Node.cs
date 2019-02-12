using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Material m_Material;
    Material m_OrigMaterial;
    public Material Replacement;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        m_Material = GetComponent<Renderer>().material;
        m_OrigMaterial = GetComponent<Renderer>().material;
    }
    private void OnMouseEnter()
    {
        rend.material = Replacement; 
    }
    private void OnMouseExit()
    {
        rend.material = m_OrigMaterial;
    }
}
