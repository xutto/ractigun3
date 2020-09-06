using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed = 10;
    public float limitReach = 60;
    private float reach;

    // Start is called before the first frame update
    void Start()
    {
        reach = this.transform.position.y + limitReach;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
        if (transform.position.y >= reach)
        {
            Destroy(this.gameObject);
        }

    }
}
