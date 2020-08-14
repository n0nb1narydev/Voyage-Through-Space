using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    
    [SerializeField]
        private Image _livesImg;
    [SerializeField]
        private Sprite[] _liveSprites;
    [SerializeField]
        private Text _gameOverText;
    [SerializeField]
        private Text _restartText;
    [SerializeField]
        private Text _How_to_Text;
        private Astroid _astroid;

    public GameManager _gameManager;
        

    // Start is called before the first frame update
    void Start()
    {
         _gameOverText.gameObject.SetActive(false); 
         _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
         _astroid = GameObject.Find("Astroid").GetComponent<Astroid>();
      
    }
    // Update is called once per frame
    void Update()
    {          
     if(_astroid.isAlive == false)
     {
        _How_to_Text.gameObject.SetActive(false);  
     }
    }
    
    public void UpdateLives(int currentLives)
    {
      //access display image sprite and give it a new one   
      _livesImg.sprite = _liveSprites[currentLives];

      if(currentLives == 0)
      {
          
          GameOverSequence();
      }
    }
    
    void GameOverSequence()
    {
            _gameManager.GameOver();
           _gameOverText.gameObject.SetActive(true);
           _restartText.gameObject.SetActive(true);
           StartCoroutine(FlashingGameOverText());

    }
    IEnumerator FlashingGameOverText()
    {
        while(true)
        {
        _restartText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _restartText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);  
        }
    }

}
