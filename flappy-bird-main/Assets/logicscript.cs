using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicscript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool flyIsAlive2 = true;
    public AudioSource ping;
    public int highScore;
    public Text highScoreText;


    [ContextMenu("Increase Score")]
   public void addScore(int scoreToAdd) 
    {
        if (flyIsAlive2 == true) { 
         playerScore = playerScore + scoreToAdd;
         scoreText.text = playerScore.ToString();
         ping.Play();
            if (playerScore > PlayerPrefs.GetInt("highScore", 0))
            {
                highscore();
            }
           
           //for challenge :))
           //if (playerScore%10==0){  Time.timeScale+=1; }
           

    }
    
    }

    private void Start()
    {
        Update();
    }
    public void restartgame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameover() 
    {
        
      gameOverScreen.SetActive(true);
       flyIsAlive2 = false;

    }
    public void highscore() {
       
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", playerScore);
            highScoreText.text = highScore.ToString();
        
        }
    private void Update()
    {
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("highScore");
    }
    
}
