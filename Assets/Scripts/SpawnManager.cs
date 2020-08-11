using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _borgCube;
    [SerializeField]
    private GameObject _tripleShotPU;

    private bool _stopSpawning = true;
    void Start()
    {
       StartCoroutine(SpawnRoutine());
       StartCoroutine(SpawnBoss());
       StartCoroutine(SpawnPowerUps());
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
           newEnemy.transform.parent = _enemyContainer.transform; //puts enemy clones in the container
           yield return new WaitForSeconds (5.0f);
       }
    }

    IEnumerator SpawnPowerUps()
    {
        yield return new WaitForSeconds(Random.Range(5.0f, 30.0f));
        Vector3 posToSpawn = new Vector3 (Random.Range(-8.0f, 8.0f), 7, 0);
        Instantiate(_tripleShotPU, posToSpawn, Quaternion.identity);

    }
    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(Random.Range(10.0f, 30.0f));
        Vector3 posToSpawn = new Vector3(0, 18, 0);
        Instantiate( _borgCube, posToSpawn, Quaternion.identity);
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = false;
    }
}
