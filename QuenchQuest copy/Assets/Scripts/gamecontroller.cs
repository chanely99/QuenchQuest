using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroller : MonoBehaviour {

    public GameObject bullets;
    public Vector2 spawnValues;
    public int count;
    public float spawnwait;
    public float startwait;
    private bool keepplaying = true;
    private int timecounter =10;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        timecounter--;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startwait);
        while (keepplaying)
        {
            for (int i = 0; i <= count; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Instantiate(bullets, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnwait);
            }

            if (timecounter <=0)
                keepplaying = false;
        }

    }
}
