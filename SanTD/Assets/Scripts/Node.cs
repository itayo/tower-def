using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Color m_origColor;
    private Color m_MarkedColor;
    public Renderer rend;
    public GameObject turret = null;
    void Start()
    {
        rend = GetComponent<Renderer>();
        m_origColor = rend.material.color;
        m_MarkedColor = 0.5f * m_origColor;
    }
    private void OnMouseEnter()
    {
        rend.material.color = m_MarkedColor; 
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cant place turrent, TODO - FIX THIS");
        }
        else
        {
            GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
            if (turretToBuild != null)
            {
                turret = (GameObject)Instantiate(turretToBuild, transform.position + new Vector3(0f,0.5f,0f), transform.rotation);
            }
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = m_origColor;
    }
}
