using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{

    public float timeToStep0 = 2f;
    public float timeToStep1 = 8f;
    public float timeToStep2 = 15f;
    public GameObject[] enemiesA;
    public GameObject[] enemiesB;
    public GameObject[] enemiesC;
    private int enemiesBquantity = 4;
    public int step = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (step == 0)
        {
            timeToStep0 -= Time.deltaTime;

            if (timeToStep0 < 0)
            {
                Instantiate(enemiesA[0], new Vector2(-0, 22), transform.rotation);
                step = 1;
            }
        }
        else if (step == 1)
        {

            timeToStep1 -= Time.deltaTime;
            if (timeToStep1 < 0)
            {
                StartCoroutine(nameof(EnemyBSpawnLoop));
                step = 2;
            }
        }
        else if (step == 2)
        {

            timeToStep2 -= Time.deltaTime;
            if (timeToStep2 < 0)
            {
                Instantiate(enemiesC[0], new Vector2(2, 18), transform.rotation);
                Instantiate(enemiesC[0], new Vector2(5, 18.5f), transform.rotation);
                Instantiate(enemiesC[0], new Vector2(8, 19), transform.rotation);
                Instantiate(enemiesC[1], new Vector2(-2, 18), transform.rotation);
                Instantiate(enemiesC[1], new Vector2(-5, 18.5f), transform.rotation);
                Instantiate(enemiesC[1], new Vector2(-8, 19), transform.rotation);
                step = 3;
            }
        }

    }

    IEnumerator EnemyBSpawnLoop()
    {
        for (float i = 0; i < enemiesBquantity; i++)
        {
            Instantiate(enemiesB[0], new Vector2(-10, 20), transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }

        Instantiate(enemiesB[1], new Vector2(-10, 20), transform.rotation);


        // yield return null;
    }
}
