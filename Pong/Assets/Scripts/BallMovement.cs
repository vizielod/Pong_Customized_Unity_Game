using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static BallMovement instance;

    public CameraShake cameraShake;

    public float speed = 15f;

    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    private Rigidbody2D ball;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ball = GetComponent<Rigidbody2D>();
        //initial velocity
        ball.velocity = Vector2.right * speed;
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

        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            //Gradually increasing the speed of the ball by each Player hit
            setBallSpeed(speed + 2f);

            // Shake the camera
            StartCoroutine(cameraShake.Shake(.15f, .2f));

            // Change ball color similar to Racket color
            transform.GetComponent<Renderer>().material.color = Color.green;

            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            ball.velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            //Gradually increasing the speed of the ball by each Player hit
            setBallSpeed(speed + 2f);

            // Shake the camera
            StartCoroutine(cameraShake.Shake(.15f, .2f));

            // Change ball color similar to Racket color
            transform.GetComponent<Renderer>().material.color = Color.red;

            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            ball.velocity = dir * speed;
        }

        if(col.gameObject.tag == "LeftGoal")
        {
            // Shake the camera
            StartCoroutine(cameraShake.Shake(.30f, 1f));

            scorePlayer1++;
            GameManager.instance.Goal_Player1();

            // If player1 scores the ball starts to move towards Player2 after respawning on the middle if the field
            setBallSpeed(15f);
            transform.position = Vector3.zero;
            ball.velocity = Vector2.left * speed;
            ball.GetComponent<Renderer>().material.color = Color.white;
        }

        if (col.gameObject.tag == "RightGoal")
        {
            // Shake the camera
            StartCoroutine(cameraShake.Shake(.30f, 1f));

            scorePlayer2++;
            GameManager.instance.Goal_Player2();

            // If player2 scores the ball starts to move towards Player1 after respawning on the middle if the field
            setBallSpeed(15f);
            transform.position = Vector3.zero;
            ball.velocity = Vector2.right * speed;
            ball.GetComponent<Renderer>().material.color = Color.white;
        }
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
}
