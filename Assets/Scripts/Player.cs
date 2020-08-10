using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Player : MonoBehaviour //Unity Specific Term
{

        [SerializeField] //allows you to read/overwrite it in the Inspector
            private float _speed = 3.5f; 
        [SerializeField]
            private GameObject _laserPrefab;
        [SerializeField]
            private float _fireRate = 0.15f;
            private float _canFire = -1f;
        [SerializeField]    
            private int _lives = 3;
            private SpawnManager _spawnManager;
        

    void Start()
    {
        transform.position = new Vector3(0, -3.8f, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();//Give acces to spawnmanager
        if(_spawnManager == null)
        {
            Debug.LogError("The spawn manager is NULL");
        }
    }

    void Update() // runs 60 frames per second
    {
        CalculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

        
    }


    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
        Vector3  direction = new Vector3(horizontalInput, verticalInput, 0); //make a Vector3 variable
        
        transform.Translate(direction * _speed * Time.deltaTime);
            
    //Set Player Bounds and Ship Wrap
        // transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.postion.y, -3.8f, 0), 0); Gives error CS1061
        if( transform.position.y >= 0 )
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        } else if(transform.position.y <= -3.8f)
        {
            transform.position = new Vector3( transform.position.x, -3.8f, 0);
        }
        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f,transform.position.y, 0);
        } else if ( transform.position.x <= -11.3f )
        {
            transform.position = new Vector3( 11.3f, transform.position.y, 0);
        }
    }
    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
            
        Vector3 offset = new Vector3(0, 0.8f, 0);
        Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity); //default rotation 99% of the time what you'll use.
    }
    public void Damage()
    {
        _lives--;

        if(_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
