using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    //ID for powerups 
    //0 = triple shot
    //1  = speed
    //2 = shields
    [SerializeField]
        private int powerupID;
    [SerializeField]
        private float _speed = 3;

    
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
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                // if(powerupID == 0)
                // {
                //     player.TripleShotActive();
                //     Debug.log("Tripleshot Collected");
                // } 
                // else if(powerupID == 1)
                // {
                //     player.WarpDriveActive();
                //     Debug.log("Speed Boost Collected");
                // }
                // else if (powerupID == 2)
                // {
                //     Debug.log("Speed Boost Collected");
                // } Convert to Switch Statement
                switch(powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.WarpDriveActive();
                        break;
                    case 2:
                        break;
                    //default: would be the else
                }
            }
            Destroy(this.gameObject);
        }

    }
}


