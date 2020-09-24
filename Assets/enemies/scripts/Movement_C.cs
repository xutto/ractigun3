using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_C : MonoBehaviour
{

    public bool isMovingRigth = false;
    public bool isMovingLeft = false;

    public float translateTime = 0.8f;
    public float speed = 15f;
    public int phase = 0;
    public float timeAttack = 2f;

    private Vector2 direction;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        transform.rotation = Quaternion.Euler(Vector3.forward * 180.0f);
        animator = GetComponent<Animator>();

        if (isMovingRigth)
        {
            direction = Vector2.right;
        }
        else if (isMovingLeft)
        {
            direction = Vector2.left;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (phase == 0)
        {
            if (translateTime >= 0)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                translateTime -= Time.deltaTime;
            }
            else
            {
                WaitAndMoving();
            }
        }
        else if (phase == 1)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }

    private void WaitAndMoving()
    {
        if (timeAttack >= 0)
        {
            timeAttack -= Time.deltaTime;
        }
        else
        {
            MovingInDirection();
            phase = 1;
        }
    }

    private void MovingInDirection()
    {
        if (isMovingRigth)
        {
            animator.SetBool("isMovingRigth", true);
        }
        else if (isMovingLeft)
        {
            animator.SetBool("isMovingLeft", true);
        }
    }
}
