using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
        private float _laserSpeed = 8.0f;

    
    void Update()
    {
        
        Vector3 laserDirection = new Vector3(0, 1, 0);
        transform.Translate( laserDirection * _laserSpeed * Time.deltaTime);

    if (transform.position.y > 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject); 
        }
        
    }


        
    
    
}
