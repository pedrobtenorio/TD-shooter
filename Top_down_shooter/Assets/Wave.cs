using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [System.Serializable]

    public class wave
    {
        
        public inimigo[] inimigos;
        public int count;
        public float timer;
        

    }

    public wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWavens;

    private bool finished;

    private wave CurrentWave;

    private int CurrentWaveIndex;

    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        StartCoroutine(StartWave(CurrentWaveIndex));
    }


    private void Update()
    {
        if (finished == true && GameObject.FindGameObjectsWithTag("Inimigo").Length == 0)
        {
            finished = false;
            if (CurrentWaveIndex + 1 < waves.Length)
            {
                CurrentWaveIndex++;
                StartCoroutine(StartWave(CurrentWaveIndex));
            }
            else
            {
                Debug.Log("Game Finished");
            }

        }

    }

    IEnumerator StartWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWavens);
        StartCoroutine(spawnWave(index));
    }

    IEnumerator spawnWave(int index)
    {
        CurrentWave = waves[index];

        for(int i=0; i< CurrentWave.count; i++)
        {
            if(player == null)
            {
                yield break;
            }
            
             inimigo inimigoR = CurrentWave.inimigos[Random.Range(0, CurrentWave.inimigos.Length)];
             Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
             Instantiate(inimigoR, randomSpot.position, randomSpot.rotation);

            if (i == CurrentWave.count - 1)
            {
                finished = true;
            }
            else
            {
                finished = false;
            }

            yield return new WaitForSeconds(CurrentWave.timer);
        }


        
    }

   
}
