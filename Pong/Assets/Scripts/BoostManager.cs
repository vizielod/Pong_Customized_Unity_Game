using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{

    public float speed = 15f;

    private Rigidbody2D boost;

    private RacketLeftManager racketLeftManager;
    private RacketRightManager racketRightManager;
    private BallMovement ballMovement;

    //private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        racketLeftManager = RacketLeftManager.instance;
        racketRightManager = RacketRightManager.instance;

        ballMovement = BallMovement.instance;

        boost = GetComponent<Rigidbody2D>();
        //initial velocity
        int random = Random.Range(0, 2)*2-1;
        if(random == 1)
        {
            boost.velocity = Vector2.right * speed;
        }
        else if (random == -1)
        {
            boost.velocity = Vector2.left * speed;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        racketLeftManager = RacketLeftManager.instance;
        racketRightManager = RacketRightManager.instance;
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
            if (gameObject.name == "RacketSizeUp(Clone)")
            {
                if(racketLeftManager.getRacketSizeY() < 6f)
                {
                    racketLeftManager.setRacketSizeY(racketLeftManager.getRacketSizeY() + 0.5f);
                }
                
            }
            else if (gameObject.name == "RacketSizeDown(Clone)")
            {
                if(racketLeftManager.getRacketSizeY() > 0.5f)
                {
                    racketLeftManager.setRacketSizeY(racketLeftManager.getRacketSizeY() - 0.5f);
                }
                    
            }
            else if(gameObject.name == "RacketSpeedUp(Clone)")
            {
                if (racketLeftManager.getRacketSpeed() < 60f)
                {
                    racketLeftManager.setRacketSpeed(racketLeftManager.getRacketSpeed() + 10f);
                }
            }
            else if (gameObject.name == "RacketSpeedDown(Clone)")
            {
                if (racketLeftManager.getRacketSpeed() > 10f)
                {
                    racketLeftManager.setRacketSpeed(racketLeftManager.getRacketSpeed() - 10f);
                }
            }
            else if (gameObject.name == "SpawnExtraBall(Clone)")
            {

                GameObject ball = Instantiate((GameObject)Resources.Load("Prefabs/Ball", typeof(GameObject)), Vector3.zero, Quaternion.identity);     
                
            }
            else if (gameObject.name == "BallSpeedIncr(Clone)")
            {
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() + 10f);
            }
            else if (gameObject.name == "BallSpeedDecr(Clone)")
            {
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() - 10f);
            }
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            //gameObject.SetActive(false);
            //ballMovement.setBallSpeed(ballMovement.getBallSpeed() * 1.5f);
            if (gameObject.name == "RacketSizeUp(Clone)")
            {
                if(racketRightManager.getRacketSizeY() < 6f)
                {
                    racketRightManager.setRacketSizeY(racketRightManager.getRacketSizeY() + 0.5f);
                }
                
            }
            else if (gameObject.name == "RacketSizeDown(Clone)")
            {
                if(racketRightManager.getRacketSizeY() > 0.5f)
                {
                    racketRightManager.setRacketSizeY(racketRightManager.getRacketSizeY() - 0.5f);
                }
            }
            else if (gameObject.name == "RacketSpeedUp(Clone)")
            {
                if (racketRightManager.getRacketSpeed() < 60f)
                {
                    racketRightManager.setRacketSpeed(racketRightManager.getRacketSpeed() + 10f);
                }
            }
            else if (gameObject.name == "RacketSpeedDown(Clone)")
            {
                if (racketRightManager.getRacketSpeed() > 10f)
                {
                    racketRightManager.setRacketSpeed(racketRightManager.getRacketSpeed() - 10f);
                }
            }
            else if (gameObject.name == "SpawnExtraBall(Clone)")
            {

                GameObject ball = Instantiate((GameObject)Resources.Load("Prefabs/Ball", typeof(GameObject)), Vector3.zero, Quaternion.identity);

            }
            else if (gameObject.name == "BallSpeedIncr(Clone)")
            {
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() + 10f);
            }
            else if (gameObject.name == "BallSpeedDecr(Clone)")
            {
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() - 10f);
            }
            gameObject.SetActive(false);
            Destroy(gameObject);

        }

        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void setBoostSpeed(float speed)
    {
        this.speed = speed;
    }
}
