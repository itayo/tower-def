using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> wps;
    private int idx = 1;
    public float speed = 0.1f;
    private int idxDir = 1;
    public ScoreManager scm;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(wps.Count);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wps[idx].transform.position, speed * Time.deltaTime);
        Vector3 dir = wps[idx].transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg+90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Vector2.Distance(transform.position, wps[idx].transform.position) < 0.1f)
        {
            if (idx == wps.Count - 1) { idxDir = -1; scm.Decrease(); }
            if (idx == 0) { idxDir = 1; scm.Decrease(); }
            idx += idxDir;
        }
    }
}
