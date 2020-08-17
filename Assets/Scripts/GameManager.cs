using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
        // Update is called once per frame
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Return) && _isGameOver == true)
        {
            SceneManager.LoadScene(1); //Current Game Scene
        }
    }
        public void GameOver()
        {
            _isGameOver = true;
            
        }
    

}
