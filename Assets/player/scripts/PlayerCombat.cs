using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public GameObject bullet;
    public GameObject cannon;
    [SerializeField]
    [Range(0.05F, 2.0F)]
    private float fireRate = 0.1F;
    private float nextFire = 0.0F;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxisRaw("Fire1") > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, cannon.transform.position, cannon.transform.rotation);
        }

    }
}
