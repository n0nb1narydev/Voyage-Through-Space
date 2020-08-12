using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgCube : MonoBehaviour
{
    [SerializeField]
        private int _lives = 20;
    [SerializeField]
        private float _speed = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        Player player = other.transform.GetComponent<Player>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( Vector3.down * _speed * Time.deltaTime);
    } 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            this.Damage();
            Destroy(other.gameObject);
        }
        if(other.tag == "Player")
        {      
                    Destroy(other.gameObject);

        }

    }

    public void Damage()
    {
        _lives--;

        if(_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
