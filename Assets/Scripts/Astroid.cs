using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField]
        private float _speed = 3f;
    [SerializeField]
        private GameObject _explosionAnim;
        public bool isAlive = true;
        private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate object on zed access 3f
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            _explosionAnim.SetActive(true);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 1f);
            isAlive = false;
        }
    }
}
