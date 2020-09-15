using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource gameMusicAudio;

    //public CameraShake cameraShake;
    public bool startPlaying;

    public GameObject ball, leftRocket, rightRocket, leftGoal, rightGoal;

    public int player1_currentScore = 0, player2_currentScore = 0;
    public Text scoreText_1, scoreText_2, ballSpeedText;

    public BoostSpawner boostSpawner;
    public RacketRightManager racketRightManager;
    public RacketLeftManager racketLeftManager;
    public BoostManager boostManager;

    private BallMovement ballMovement;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ballMovement = BallMovement.instance;

        gameMusicAudio.Play();
        //boostManager = BoostManager.instance;
        scoreText_1.text = "0";

        scoreText_2.text = "0";

        ballSpeedText.text = "Ball speed: " + ballMovement.getBallSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        ballSpeedText.text = "Ball speed: " + ballMovement.getBallSpeed();
        if (player1_currentScore == 5 || player2_currentScore == 5)
        {
            //Simple way to stop the game playing without adding startPlaying and hasStarted variables.
            Destroy(ball);
            StartCoroutine(Quit());
        }
    }

    private IEnumerator Quit()
    {
        yield return new WaitForSecondsRealtime(3f);
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void Goal_Player1()
    {
        Debug.Log("Player 1 scored a goal!");

        player1_currentScore++;
        scoreText_1.text = player1_currentScore.ToString();
    }

    public void Goal_Player2()
    {
        Debug.Log("Player 2 scored a goal!");

        player2_currentScore++;
        scoreText_2.text = player2_currentScore.ToString();
    }
}
