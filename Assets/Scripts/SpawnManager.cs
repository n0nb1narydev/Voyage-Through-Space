using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Player pl;
    [SerializeField]
        private GameObject _enemyPrefab;
    [SerializeField]
        private GameObject _enemyContainer;
    [SerializeField]
        private GameObject _borgCubePrefab;
        private bool _stillSpawning = true;
    [SerializeField]
        private GameObject[] powerups;

        
    void Start()
    {
           
    }
    public void StartSpawning()
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
         yield return new WaitForSeconds(3f);
       while(_stillSpawning)
       {   
           Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f),7,0);
           GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
           newEnemy.transform.parent = _enemyContainer.transform; //puts enemy clones in the container
           yield return new WaitForSeconds (5.0f);
       }
    }

    IEnumerator SpawnPowerUps()
    {
        yield return new WaitForSeconds(3f);
       while(_stillSpawning)
       {   
                yield return new WaitForSeconds(Random.Range(10, 15));
                Vector3 posToSpawn = new Vector3 (Random.Range(-8.0f, 8.0f), 7, 0);
                int randomPowerUp = Random.Range(0, 3);
                Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity); 
       }
    }
    IEnumerator SpawnBoss()
    {
         yield return new WaitForSeconds(3f);
        while(_stillSpawning)
        {
            yield return new WaitForSeconds(Random.Range(20, 35));
            Vector3 posToSpawn = new Vector3(0, 18, 0);
            Instantiate( _borgCubePrefab, posToSpawn, Quaternion.identity);
        }
    }
    public void OnPlayerDeath()
    {
        _stillSpawning = false;
    }
    
}
