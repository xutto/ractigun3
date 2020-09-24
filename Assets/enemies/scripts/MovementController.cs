using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float initialVelocity = 0.0F;

    //this is our target velocity while accelerating
    public float finalVelocity = 500.0F;

    //this is our current velocity
    public float currentVelocity = 0.0F;

    //this is the velocity we add each second while accelerating
    public float accelerationRate = 10.0F;

    //this is the velocity we subtract each second while decelerating
    public float decelerationRate = 50.0F;

    public float retractrileSpeed = 12.0F;

    private GameObject player;

    public float rotateSpeed = 20;

    public float timeTargeting = 0;

    public int phase = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //rotate allways to player
        RotateToPlayer();

        if (phase == 0)
        {
            ChangePhase(MoveToAttack(8, Vector2.down, Space.World));
        }
        else if (phase == 1)
        {
            MoveToExit(25, Vector2.up, Space.World);
        }
    }

    private void ChangePhase(int finish)
    {
        if (finish == 1)
        {
            timeTargeting -= Time.deltaTime;
            if (timeTargeting < 0)
            {
                phase = 1;
            }
        }
    }

    private void RotateToPlayer()
    {
        // Rotate our transform a step closer to the target's.
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    private void TranslateWithAccel(Vector2 direction, Space reference)
    {
        //add to the current velocity according while accelerating
        currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        transform.Translate(currentVelocity * Time.deltaTime * direction, reference);
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
    }

    private int TranslateWithDeaccel(Vector2 direction, Space reference)
    {
        int flagToFinish = 0;
        currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        if (currentVelocity > 0)
        {
            transform.Translate(currentVelocity * Time.deltaTime * direction, reference);
        }
        else
        {
            transform.Translate(0, 0, 0);
            flagToFinish = 1;
        }
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
        return flagToFinish;
    }
    private int MoveToAttack(float positionTo, Vector2 direction, Space reference)
    {
        int flagToFinish = 0;
        if (transform.position.y > positionTo)
        {
            TranslateWithAccel(direction, reference);
        }
        else
        {
            flagToFinish = TranslateWithDeaccel(direction, reference);
        }
        return flagToFinish;

    }

    private void MoveToExit(float toPosition, Vector2 direction, Space refecerence)
    {

        if (transform.position.y < toPosition)
        {
            transform.Translate(retractrileSpeed * Time.deltaTime * direction, refecerence);
        }

    }
}
/*

referenceTime = time.time (10) <- start desde que se incia la script

resultTime = time.time (14) - referenceTime(10)
resultTime = 4;





*/