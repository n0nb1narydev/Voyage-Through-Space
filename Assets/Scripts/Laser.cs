using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
        private float _laserSpeed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        //translate laser up
        Vector3 laserDirection = new Vector3(0, 1, 0);
        transform.Translate( laserDirection * _laserSpeed * Time.deltaTime);

    if(transform.position.y > 8f)
        {
            Destroy(this.gameObject); 
        }
        
    }

    //destroy laser clone if the laser pos on y >= 8 
        
    
    
}
