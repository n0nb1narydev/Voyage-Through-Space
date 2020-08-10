using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = true;
    void Start()
    {
       StartCoroutine(SpawnRoutine());
    }
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
       while(_stopSpawning)
       {   
           Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f),7,0);
           GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
           newEnemy.transform.parent = _enemyContainer.transform;
           yield return new WaitForSeconds (5.0f);
       }
       

    }
    public void OnPlayerDeath()
    {
        _stopSpawning = false;
    }
}
