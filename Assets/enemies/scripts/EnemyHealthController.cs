using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    public int healt = 10;


    private void OnTriggerEnter2D(Collider2D bullet)
    {
        BulletControl bulletControl = bullet.gameObject.GetComponent<BulletControl>();
        Destroy(bullet.gameObject);
        healt -= bulletControl.damage;

        if (healt <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log("DAMAGE OF BULLET IS: " + bulletControl.damage);
    }
}
