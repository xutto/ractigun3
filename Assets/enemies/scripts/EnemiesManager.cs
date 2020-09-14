using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{

    public float timer = 2f;
    private float timeSpawnRate;
    public GameObject enemyA0;
    public int step = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeSpawnRate = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                Instantiate(enemyA0, new Vector2(-10, 22), transform.rotation);
                timer = timeSpawnRate;
                step = 1;
            }
        }
    }
}
