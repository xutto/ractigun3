using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{

   [SerializeField]
    [Range(2, 100)]
    private float speed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(speed * Time.deltaTime * Vector2.down);
        if (transform.position.y <= -10f)
        {
            transform.position = new Vector2(0, 10.5f);
        }

    }
}
