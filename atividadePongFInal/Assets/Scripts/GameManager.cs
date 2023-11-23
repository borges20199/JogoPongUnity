using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        // No script do GameManager
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;
    public int playerScore = 0;
    public int enemyScore = 0;
    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;
    public int winPoints = 5;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;




// ...
    void Start()
    {
    ResetGame();
        }
        public void ResetGame()
        {
                // Redefina as posições iniciais das raquetes
                playerPaddle.position = new Vector3(-7f, 0f, 0f);
                enemyPaddle.position = new Vector3(7f, 0f, 0f);

                // Redefina a posição da bola
                ballController.ResetBall();

                // Redefina a pontuação dos jogadores
                playerScore = 0;
                enemyScore = 0;

                // Atualize os textos de pontuação
                textPointsEnemy.text = enemyScore.ToString();
                textPointsPlayer.text = playerScore.ToString();

                screenEndGame.SetActive(false);
        }

        public void ScorePlayer()
        {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
        }
        public void ScoreEnemy()
        {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
        }
        public void CheckWin()
        {
            if(enemyScore >= winPoints || playerScore >= winPoints)
                {
                    //ResetGame(;
                    EndGame();
                }
        }

        public void EndGame()
        {
            screenEndGame.SetActive(true);
            string winner = SaveController.Instance.GetName(playerScore > enemyScore);
            textEndGame.text = "Vitória do" + winner;
            SaveController.Instance.SaveWinner(winner);
            
            Invoke("LoadMenu", 2f);

        }

        private void LoadMenu()
        {
        SceneManager.LoadScene("Menu");
        }



}









     