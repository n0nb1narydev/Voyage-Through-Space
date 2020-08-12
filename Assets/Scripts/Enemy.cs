using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
        private float _speed = 4f;
        private GameObject _enemyPrefab;

        private Player _player;

    void Start() 
    {
        _player = GameObject.Find("Player").GetComponent<Player>(); 
    }
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
            
            if (_player != null) // Null Checking
            {
                _player.Damage();
            }

            Destroy(this.gameObject); 
        }
        
        if (other.tag == "Laser")
        {
            ScoreScript.scoreValue += 10;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
