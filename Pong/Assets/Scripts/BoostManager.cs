using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{

    public float speed = 15f;

    private Rigidbody2D boost;

    private RacketManager racketManager;
    private BallMovement ballMovement;
    // Start is called before the first frame update
    void Start()
    {
        racketManager = RacketManager.instance;

        ballMovement = BallMovement.instance;

        boost = GetComponent<Rigidbody2D>();
        //initial velocity
        boost.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        racketManager = RacketManager.instance;
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
            //gameObject.SetActive(false);
            //ballMovement.setBallSpeed(ballMovement.getBallSpeed() * 1.5f);
            //racketManager.setRacketLength(2f);
            racketManager.setRacketSizeY(racketManager.getRacketSizeY() + 1f);

            gameObject.SetActive(false);
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            //gameObject.SetActive(false);
            //ballMovement.setBallSpeed(ballMovement.getBallSpeed() * 1.5f);
            racketManager.setRacketSizeY(racketManager.getRacketSizeY() + 1f);
            gameObject.SetActive(false);
        }

        gameObject.SetActive(false);

    }

    public void setBoostSpeed(float speed)
    {
        this.speed = speed;
    }
}
