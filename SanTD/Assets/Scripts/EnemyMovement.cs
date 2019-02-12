using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f;
    private Transform target;
    private int waypointIdx = 0;
    public int hp = 5;
    void Start()
    {
        target = Waypoints.waypoints[waypointIdx];
    }
    public void hit(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            Destroy(gameObject);
        
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized *speed * Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position,target.position) <=0.4f)
        {
            getNextWp();
        }
    }
    private void getNextWp()
    {
        waypointIdx++;
        if(waypointIdx >= Waypoints.waypoints.Length)
        {
            Destroy(gameObject);
        }
        else
            target = Waypoints.waypoints[waypointIdx];
    }
}
