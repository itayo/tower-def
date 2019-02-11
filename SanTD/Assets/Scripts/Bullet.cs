using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public int damage;
    public float speed = 70f;
    public void myTarget(Transform newTarget, int newDamage)
    {
        target = newTarget;
        damage = newDamage;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            hitTarget();
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
    void hitTarget()
    {
        EnemyMovement t = target.GetComponent<EnemyMovement>();
        t.hit(damage);
        Debug.Log("WE HIT " + target.GetInstanceID().ToString());
        Destroy(gameObject);
    }
}
