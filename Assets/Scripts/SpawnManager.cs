using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    void Start()
    {
       StartCoroutine(SpawnRoutine());
    }
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
       while(true)
       {   
           Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f),7,0);
           Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
           yield return new WaitForSeconds (3.0f);
       }
       

    }
}
