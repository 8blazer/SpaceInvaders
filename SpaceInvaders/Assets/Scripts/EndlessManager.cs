using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public GameObject greenEnemy;
    public GameObject redEnemy;
    public GameObject yellowEnemy;
    public GameObject orangeEnemy;
    public GameObject purpleEnemy;
    public GameObject cyanEnemy;

    int wave = 1;
    int waveSize = 10;
    int enemiesLeft = 0;

    int yellowProbability = 9999;
    int redProbability = 9999;
    int cyanProbability = 9999;
    int purpleProbability = 9999;
    int orangeProbability = 9999;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeft == 0)
        {
            if (yellowProbability > 2)
            {
                yellowProbability--;
            }
            if (redProbability > 3)
            {
                redProbability--;
            }
            if (orangeProbability > 4)
            {
                orangeProbability--;
            }
            if (cyanProbability > 5)
            {
                cyanProbability--;
            }
            if (purpleProbability > 6)
            {
                purpleProbability--;
            }
            waveSize++;

            int i = 0;
            while (i < waveSize)
            {
                if (Random.Range(1, purpleProbability) == 1)
                {
                    Instantiate(purpleEnemy, transform.position, Quaternion.identity);  //NOT ACTUAL TRANSFORM.POSITION
                }

                i++;
            }
        }
    }

    public void AddEnemy()
    {
        enemiesLeft++;
    }

    public void KillEnemy()
    {
        enemiesLeft--;
    }
}
