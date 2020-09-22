using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_A1 : MonoBehaviour
{

    public float speed = 1;
    public int phase = 0;

    // Start is called before the first frame update
    void Start()
    {

        transform.rotation = Quaternion.Euler(Vector3.forward * 180.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        } else if (phase == 1){
            transform.rotation = Quaternion.Euler(Vector3.forward * 180.0f);
        }


    }

    private void ChangePhase()
    {

    }
}
