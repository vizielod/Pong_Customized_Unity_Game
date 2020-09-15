using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public CameraShake cameraShake;

    public GameObject ball, leftRocket, rightRocket, leftGoal, rightGoal;

    public int player1_currentScore = 0, player2_currentScore = 0;
    public Text scoreText_1, scoreText_2;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText_1.text = "Score: 0";

        scoreText_2.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Goal_Player1()
    {
        Debug.Log("Player 1 scored a goal!");

        player1_currentScore++;
        scoreText_1.text = "Score: " + player1_currentScore;
    }

    public void Goal_Player2()
    {
        Debug.Log("Player 2 scored a goal!");

        player2_currentScore++;
        scoreText_2.text = "Score: " + player2_currentScore;
    }
}
