using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Gun Basics")]
    public float range = 15.0f;
    public float rotSpeed = 10f;
    public float fireRate = 1f;
    public int myDamage = 1;
    [Header("GameObject Dependencies")]
    public string enemyTag = "ENEMY";
    public Transform partToRotate;
    public GameObject bullet;
    public Transform firePoint;


    private Transform target;
    private float fireCountDown=0f;
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }
    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closest = Mathf.Infinity;
        GameObject closestE = null;
        foreach(GameObject e in enemies)
        {
            float DistanceToEnemy = Vector3.Distance(transform.position, e.transform.position);
            if(DistanceToEnemy < closest)
            {
                closestE = e;
                closest = DistanceToEnemy;
            }
           
        }
        if (closestE != null && closest <= range)
        {
            target = closestE.transform;
        }
        else target = null;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(fireCountDown > 0.0f)
        {
            fireCountDown -= Time.deltaTime;
        }
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);

        Vector3 actRot = Quaternion.Lerp(partToRotate.rotation, lookRot, Time.deltaTime* rotSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, actRot.y,0f);
        if(fireCountDown <= 0f)
        {
            shoot();
            fireCountDown = 1.0f / fireRate;
        }
    }
    void shoot()
    {
       GameObject m_bullet= (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet myBullet = m_bullet.GetComponent<Bullet>();
        if(myBullet != null)
            myBullet.myTarget(target, myDamage);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
