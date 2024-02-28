using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    private int bestScore;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    public Text endScoreText;
    public Text bestScoreText;

    public void Awake(){
        Application.targetFrameRate = 60;
        

        gameOver.SetActive(false);

        scoreText.text = "";
        endScoreText.text = "";
        bestScoreText.text = "";

        Pause();
    }


    public void Play(){
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);
        endScoreText.text = "";
        bestScoreText.text = "";
        
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>(); 

        for(int i = 0; i < pipes.Length; i++){
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause(){
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver(){
        gameOver.SetActive(true);
        playButton.SetActive(true);
        scoreText.text = "";

        FindBestScore();

        Pause();
    }
    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
    }

    private void FindBestScore(){
        if(score>bestScore){
            bestScore = score;
        }
        endScoreText.text = "score - " + score;
        bestScoreText.text = "best  - " + bestScore;
    }
}
