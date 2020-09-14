using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShots : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0, 0, 1000 * Time.deltaTime);
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
