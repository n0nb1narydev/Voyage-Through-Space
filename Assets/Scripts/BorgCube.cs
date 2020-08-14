using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgCube : MonoBehaviour
{
    [SerializeField]
        private int _lives = 20;
    [SerializeField]
        private float _speed = 2f; 
        private Animator _anim;
    [SerializeField]
        public GameObject deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
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
    }

    public void Damage()
    {
        _lives--;

            if(_lives == 0)
            {
                deathAnimation.SetActive(true);
                _speed = 0;
                Destroy(this.gameObject, 1.8f);
                ScoreScript.scoreValue += 100;
                    // Bug: Score adds whil animation is still occuring if shot
            }
    }
    // private IEnumerator ScoreAdd()
    // {
    //     yield return new WaitForSeconds(2.5f);
        
    // }
}
