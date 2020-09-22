using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_A1 : MonoBehaviour
{

    public float speed = 1;
    public float rotateSpeed = 30f;
    public float timeToRotate = 10f;
    public float rotationTime = 1f;
    private float timeToChange = 0;


    // Start is called before the first frame update
    void Start()
    {

        transform.rotation = Quaternion.Euler(Vector3.forward * 180.0f);

    }

    // Update is called once per frame
    void Update()
    {

        if (timeToChange >= timeToRotate)
        {


            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (rotationTime >= 0)
            {
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
                rotationTime -= Time.deltaTime;
            }

        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            timeToChange += Time.deltaTime;
        }






    }

    private void ChangePhase()
    {

    }
}
// transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
