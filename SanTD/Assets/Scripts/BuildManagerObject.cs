using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class BuildManagerObject : MonoBehaviour
{
    BuildManagerObject(GameObject turret_, Vector3 offset_)
    {
        turret = turret_;
        offset = offset_;
    }
    public GameObject turret;
    public Vector3 offset;
}
