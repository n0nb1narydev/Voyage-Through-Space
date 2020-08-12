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
        

    // Start is called before the first frame update
    void Start()
    {
         _gameOverText.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {          
    
    }
    
    public void UpdateLives(int currentLives)
    {
      //access display image sprite and give it a new one   
      _livesImg.sprite = _liveSprites[currentLives];

      if(currentLives == 0)
      {
          
          {
           _gameOverText.gameObject.SetActive(true);
           StartCoroutine(FlashingGameOverText());

          }
      }
    }
    IEnumerator FlashingGameOverText()
    {
        while(true)
        {
        _gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _gameOverText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);  
        }
    }
    
}
