﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
        private float _speed = 4f;
        private GameObject _enemyPrefab;

        private Player _player;
        private Animator _anim;
        private bool isAlive = true;

    void Start() 
    {
        _player = GameObject.Find("Player").GetComponent<Player>(); //null check
            if(_player == null)
            {
                Debug.LogError("Component: Player not found.");
            }

        _anim = GetComponent<Animator>();
        if(_anim == null)
            {
                Debug.LogError("Component: Animator not found.");
            }

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate ( Vector3.down * _speed * Time.deltaTime );

        if(transform.position.y < -5.5f)
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
            
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0f;
            Destroy(this.gameObject, 1f); 

        }
        
        if (other.tag == "Laser")
        {
            while(isAlive == true)
            {
                ScoreScript.scoreValue += 10;
                isAlive = false;
            }
            
            Destroy(other.gameObject);
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0f;
            Destroy(this.gameObject, 1f);

        }
    }
  
    
}
