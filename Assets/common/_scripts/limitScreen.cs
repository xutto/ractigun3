using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (
        (transform.position.x <= -25) ||
        (transform.position.x >= 25) ||
        (transform.position.y <= -25) ||
        (transform.position.y >= 25)
        )
        {
            Destroy(this.gameObject);
        }


    }
}
