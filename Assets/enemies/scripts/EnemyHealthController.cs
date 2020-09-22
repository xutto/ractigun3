using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    public int healt = 10;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("playerBullet"))
        {

            BulletControl bulletControl = other.gameObject.GetComponent<BulletControl>();
            Destroy(other.gameObject);
            healt -= bulletControl.damage;

            if (healt <= 0)
            {
                Destroy(gameObject);
            }

            Debug.Log("DAMAGE OF BULLET IS: " + bulletControl.damage);

        }
    }
}
