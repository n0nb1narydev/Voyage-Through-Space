using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
        private float _speed = 4f;
        private GameObject _enemyPrefab;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate ( Vector3.down * _speed * Time.deltaTime );

        // Instantiate( _enemyPrefab, transform.position, Quaternion.identity);
        if(transform.position.y < -5f)
        {
            float randomX = Random.Range( -8f, 8f );
            transform.position = new Vector3 (randomX, 7, 0);
        }
        

        


     
    // Instantiate( _enemyPrefab, transform.position, Quaternion.identity);
    }
     private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Hit: " + other.transform.name);
        if(other.tag == "Player")
        {
            Destroy(other.gameObject); 
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
           
        }
    }
}
