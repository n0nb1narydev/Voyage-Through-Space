using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgCube : MonoBehaviour
{
    [SerializeField]
        private int _lives = 20;
    [SerializeField]
        private float _speed = 2f; 
        public Animator deathAnimation;
        public Player player;
        private bool isAlive = true;

    

    // Start is called before the first frame update
    void Start()
    {
        deathAnimation = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
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
        else if(other.tag == "Player" && player._isShieldsUpActive == false)
        {
            Destroy(other.gameObject);
            player.lives = 0;
            player._uiManager.UpdateLives(player.lives);  
        }
        else if(other.tag == "Player" && player._isShieldsUpActive == true)
        {
            DestroyCubeAnim();
            Destroy(this.gameObject, 1f);

            player._isShieldsUpActive = false;
            player.lives --;
            player._shieldVisualizer.SetActive(false);
            player._uiManager.UpdateLives(player.lives);

        } 
        
    }

    public void Damage()
    {
        _lives--;

            if(_lives == 0)
            
            {
                while(isAlive == true)
                {
                    ScoreScript.scoreValue += 100;
                    isAlive = false;
                }
            
            DestroyCubeAnim();
            Destroy(this.gameObject, 1f);
        
            }
    }
    public void DestroyCubeAnim()
    {
        deathAnimation.SetTrigger("OnDeath");
        _speed = 0f;
    }
}
