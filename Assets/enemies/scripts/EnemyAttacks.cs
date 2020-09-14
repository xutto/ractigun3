using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeToAtack = 2f;
    public float atackDuration = 3f;
    public GameObject shot;
    public GameObject cannon0;

    private float nextFire;
    [SerializeField]
    [Range(0.05F, 2.0F)]
    private float fireRate = 0.88F;

    void Start()
    {

    }

    void Update()
    {
        timeToAtack -= Time.deltaTime;

        if (timeToAtack < 0)
        {
            atackDuration -= Time.deltaTime;
            if (atackDuration > 0)
            {
                shoot();
            }
        }

    }

    private void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, cannon0.transform.position, cannon0.transform.rotation);
        }


    }


}
