using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject standardTurretPrefab;
    public Vector3 standardTurretOffsets;
    private GameObject turretToBuild;
    private Vector3 offsetTurretToBuild;
    public static BuildManager instance;
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
        offsetTurretToBuild = standardTurretOffsets;
    }
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("ERROR -Multiple buildmanagers!");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
