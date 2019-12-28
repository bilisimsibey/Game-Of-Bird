using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayControl : MonoBehaviour
{
    public static GamePlayControl ornek;

    [SerializeField]
    private Text scoreText,endText,bestScoreText,gameOverText;
    public Image HelpIcon;
    [SerializeField]
    private Button restartButton, pauseButton;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Sprite[] medalIcon;

    [SerializeField]
    private Image medal; 

    private void Awake()
    {
         MakeInstance();
        HelpIcon.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void MakeInstance()
    {
        if (ornek==null)
        {
            ornek = this;

        }
    }
    public void PauseGame()
    {
        if (scriptBird.instance!=null)
        {
            if (scriptBird.instance.isAlive)
            {

                pausePanel.SetActive(true);
                Time.timeScale = 0;
                endText.text = ""+scriptBird.instance.score;
                bestScoreText.text = "" + DataControl.ornek.getHighScore();

                restartButton.onClick.RemoveAllListeners();
                restartButton.onClick.AddListener(()=> ResumeGame());

            }
        }

    }

    public void goToMenuButon()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(true);

    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        HelpIcon.gameObject.SetActive(false);

    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;

    }

    public void SkoruGoster(int score) //karakter öldügü zaman
    {
        pausePanel.SetActive(true);
        endText.text =""+ scriptBird.instance.score;
        gameOverText.gameObject.SetActive(true);

        scoreText.gameObject.SetActive(false);




        if (score>DataControl.ornek.getHighScore())
        {
            DataControl.ornek.setHighScore(score);
        }
        bestScoreText.text = "" + DataControl.ornek.getHighScore();


        if (score<=10)
        {
            medal.sprite = medalIcon[0];
        }


        else if (score>10 && score <=30)
        {
            medal.sprite = medalIcon[1];
        }


        else
        {
            medal.sprite = medalIcon[2];
        }

        
        

        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(()=>RestartGame());


    }
}
