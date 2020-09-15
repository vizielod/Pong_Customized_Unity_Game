using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static BallMovement instance;

    private AudioSource pongEffect;
    private AudioSource goalEffect;

    private CameraShake cameraShake;
    private GameObject cameraShakeObject;

    public float speed = 15f;

    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    private Rigidbody2D ball;

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //cameraShakeObject = GameObject.Find("Main Camera");
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        pongEffect = GameObject.Find("Audio Source Pong").GetComponent<AudioSource>();
        goalEffect = GameObject.Find("Audio Source Goal").GetComponent<AudioSource>();

        ball = GetComponent<Rigidbody2D>();
        //initial velocity
        //ball.velocity = Vector2.right * speed;
        int random = Random.Range(0, 2) * 2 - 1;
        if (random == 1)
        {
            ball.velocity = Vector2.right * speed;
        }
        else if (random == -1)
        {
            ball.velocity = Vector2.left * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        pongEffect.Play();
        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            //Gradually increasing the speed of the ball by each Player hit
            setBallSpeed(speed + 2f);

            // Shake the camera
            StartCoroutine(cameraShake.Shake(.30f, .3f));

            // Change ball color similar to Racket color
            transform.GetComponent<Renderer>().material.color = Color.green;

            // Change ball trail color - by activating and deactivating the proper Trail
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            ball.velocity = (dir * speed);
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            //Gradually increasing the speed of the ball by each Player hit
            setBallSpeed(speed + 2f);

            // Shake the camera
            StartCoroutine(cameraShake.Shake(.30f, .3f));

            // Change ball color similar to Racket color
            transform.GetComponent<Renderer>().material.color = Color.red;

            // Change ball trail color - by activating and deactivating the proper Trail
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);

            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            ball.velocity = (dir * speed);
        }

        if(col.gameObject.tag == "LeftGoal")
        {
            goalEffect.Play();
            ball.velocity = Vector2.left * 0;
            // Shake the camera
            StartCoroutine(cameraShake.Shake(4.5f, .5f));

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            scorePlayer1++;
            GameManager.instance.Goal_Player1();

            if(gameObject.name == "Ball(Clone)")
            {
                Destroy(gameObject);
            }
            // If player1 scores the ball starts to move towards Player2 after respawning on the middle if the field
            StartCoroutine(RespawnBallAfterLeftGoal());
            /*setBallSpeed(15f);
            transform.position = Vector3.zero;
            ball.velocity = Vector2.left * speed;
            ball.GetComponent<Renderer>().material.color = Color.white;*/
        }

        if (col.gameObject.tag == "RightGoal")
        {
            goalEffect.Play();
            ball.velocity = Vector2.right * 0;
            // Shake the camera
            StartCoroutine(cameraShake.Shake(4.5f, .5f));

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            scorePlayer2++;
            GameManager.instance.Goal_Player2();

            if (gameObject.name == "Ball(Clone)")
            {
                Destroy(gameObject);
            }
            // If player2 scores the ball starts to move towards Player1 after respawning on the middle if the field
            StartCoroutine(RespawnBallAfterRightGoal());
            /*setBallSpeed(15f);
            transform.position = Vector3.zero;
            ball.velocity = Vector2.right * speed;
            ball.GetComponent<Renderer>().material.color = Color.white;*/
        }
    }

    private IEnumerator RespawnBallAfterRightGoal()
    {
        yield return new WaitForSecondsRealtime(5f);
        setBallSpeed(15f);
        transform.position = Vector3.zero;
        ball.velocity = Vector2.right * speed;
        ball.GetComponent<Renderer>().material.color = Color.white;
    }

    private IEnumerator RespawnBallAfterLeftGoal()
    {
        yield return new WaitForSecondsRealtime(5f);
        setBallSpeed(15f);
        transform.position = Vector3.zero;
        ball.velocity = Vector2.left * speed;
        ball.GetComponent<Renderer>().material.color = Color.white;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    public void setBallSpeed(float speed)
    {
        this.speed = speed;
    }

    public float getBallSpeed()
    {
        return speed;
    }

    public void setBallVelocity(float speedIncr)
    {
        ball.velocity = ball.velocity * speedIncr;
    }
}
