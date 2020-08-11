using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
 [SerializeField]
        private float _speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.down * _speed * Time.deltaTime);
      
      if(transform.position.y == -3.7f)
      {
          Destroy(this.gameObject);
      }
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //communicate with the player script other
            other.TripleShotActive();
            Destroy(this.gameObject);
        }

    }
}


