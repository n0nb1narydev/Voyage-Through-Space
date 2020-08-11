using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
        private float _speed = 4f;
        private GameObject _enemyPrefab;


    // Update is called once per frame
    void Update()
    {
        transform.Translate ( Vector3.down * _speed * Time.deltaTime );

        if(transform.position.y < -3.7f)
        {
            float randomX = Random.Range( -8f, 8f );
            transform.position = new Vector3 (randomX, 7, 0);
        }

    }
     private void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log("Hit: " + other.transform.name);
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>(); 
            
            if (player != null) // Null Checking
            {
                player.Damage();
            }

            Destroy(this.gameObject); 
            // other.transform (cannot do other.player)
        }
        
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
           
        }
    }
}
