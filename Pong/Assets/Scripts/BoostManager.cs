using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    public AudioSource boostAudio;
    public AudioSource nerfAudio;

    public static BoostManager instance;

    public float speed = 15f;
    public float boostTimer = 10f;

    private Rigidbody2D boost;

    private RacketLeftManager racketLeftManager;
    private RacketRightManager racketRightManager;
    private BallMovement ballMovement;

    public bool hasStarted;

    //private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        racketLeftManager = RacketLeftManager.instance;
        racketRightManager = RacketRightManager.instance;

        ballMovement = BallMovement.instance;

        boostAudio = GameObject.Find("Audio Source Boost").GetComponent<AudioSource>();
        nerfAudio = GameObject.Find("Audio Source Nerf").GetComponent<AudioSource>();

        boost = GetComponent<Rigidbody2D>();
        //initial velocity
        int random = Random.Range(0, 2) * 2 - 1;
        if (random == 1)
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
        if(col.gameObject.name == "Ball")
        {
            Color ballColor = col.transform.GetComponent<Renderer>().material.color;
            if (ballColor == Color.red)
            {
                BoostRightRocket();
                Debug.Log("Right Rocket Boosted");
            }
            if (ballColor == Color.green)
            {
                BoostLeftRacket();
                Debug.Log("Left Rocket Boosted");
            }
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {

            //gameObject.SetActive(false);
            //ballMovement.setBallSpeed(ballMovement.getBallSpeed() * 1.5f);
            //racketManager.setRacketLength(2f);
            /*if (gameObject.name == "RacketSizeUp(Clone)")
            {
                //Play boost sound effect
                boostAudio.Play();

                //set the timer of the boost
                racketLeftManager.setSizeTimer(15f);
                if (racketLeftManager.getRacketSizeY() < 6f)
                {
                    racketLeftManager.setRacketSizeY(racketLeftManager.getRacketSizeY() + 0.5f);
                }
                
            }
            else if (gameObject.name == "RacketSizeDown(Clone)")
            {
                //Play boost sound effect
                nerfAudio.Play();

                //set the timer of the boost
                racketLeftManager.setSizeTimer(15f);
                if (racketLeftManager.getRacketSizeY() > 0.5f)
                {
                    racketLeftManager.setRacketSizeY(racketLeftManager.getRacketSizeY() - 0.5f);
                }
                    
            }
            else if(gameObject.name == "RacketSpeedUp(Clone)")
            {
                //Play boost sound effect
                boostAudio.Play();

                //set the timer of the boost
                racketLeftManager.setSpeedTimer(15f);
                if (racketLeftManager.getRacketSpeed() < 60f)
                {
                    racketLeftManager.setRacketSpeed(racketLeftManager.getRacketSpeed() + 10f);
                }
            }
            else if (gameObject.name == "RacketSpeedDown(Clone)")
            {
                //Play boost sound effect
                nerfAudio.Play();

                //set the timer of the boost
                racketLeftManager.setSpeedTimer(15f);
                if (racketLeftManager.getRacketSpeed() > 10f)
                {
                    racketLeftManager.setRacketSpeed(racketLeftManager.getRacketSpeed() - 10f);
                }
            }
            else if (gameObject.name == "SpawnExtraBall(Clone)")
            {
                boostAudio.Play();
                GameObject ball = Instantiate((GameObject)Resources.Load("Prefabs/Ball", typeof(GameObject)), Vector3.zero, Quaternion.identity);     
                
            }
            else if (gameObject.name == "BallSpeedIncr(Clone)")
            {
                //Play boost sound effect
                boostAudio.Play();
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() + 10f);
            }
            else if (gameObject.name == "BallSpeedDecr(Clone)")
            {
                //Play boost sound effect
                nerfAudio.Play();
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() - 10f);
            }*/
            BoostLeftRacket();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            //gameObject.SetActive(false);
            //ballMovement.setBallSpeed(ballMovement.getBallSpeed() * 1.5f);
            /*if (gameObject.name == "RacketSizeUp(Clone)")
            {
                //Play boost sound effect
                boostAudio.Play();

                //set the timer of the boost
                racketRightManager.setSizeTimer(15f);
                if (racketRightManager.getRacketSizeY() < 6f)
                {
                    racketRightManager.setRacketSizeY(racketRightManager.getRacketSizeY() + 0.5f);
                }
                
            }
            else if (gameObject.name == "RacketSizeDown(Clone)")
            {
                //Play boost sound effect
                nerfAudio.Play();

                //set the timer of the boost
                racketRightManager.setSizeTimer(15f);
                if (racketRightManager.getRacketSizeY() > 0.9f)
                {
                    racketRightManager.setRacketSizeY(racketRightManager.getRacketSizeY() - 0.3f);
                }
            }
            else if (gameObject.name == "RacketSpeedUp(Clone)")
            {
                //Play boost sound effect
                boostAudio.Play();

                //set the timer of the boost
                racketRightManager.setSpeedTimer(15f);
                if (racketRightManager.getRacketSpeed() < 60f)
                {
                    racketRightManager.setRacketSpeed(racketRightManager.getRacketSpeed() + 10f);
                }
            }
            else if (gameObject.name == "RacketSpeedDown(Clone)")
            {
                //Play boost sound effect
                nerfAudio.Play();

                //set the timer of the boost
                racketRightManager.setSpeedTimer(15f);
                if (racketRightManager.getRacketSpeed() > 10f)
                {
                    racketRightManager.setRacketSpeed(racketRightManager.getRacketSpeed() - 10f);
                }
            }
            else if (gameObject.name == "SpawnExtraBall(Clone)")
            {
                //Play boost sound effect
                boostAudio.Play();
                GameObject ball = Instantiate((GameObject)Resources.Load("Prefabs/Ball", typeof(GameObject)), Vector3.zero, Quaternion.identity);

            }
            else if (gameObject.name == "BallSpeedIncr(Clone)")
            {
                //Play boost sound effect
                boostAudio.Play();
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() + 10f);
            }
            else if (gameObject.name == "BallSpeedDecr(Clone)")
            {
                //Play boost sound effect
                nerfAudio.Play();
                ballMovement.setBallSpeed(ballMovement.getBallSpeed() - 10f);
            }*/
            BoostRightRocket();
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

    public void BoostLeftRacket()
    {
        if (gameObject.name == "RacketSizeUp(Clone)")
        {
            //Play boost sound effect
            boostAudio.Play();

            //set the timer of the boost
            racketLeftManager.setSizeTimer(boostTimer);
            if (racketLeftManager.getRacketSizeY() < 3f)
            {
                racketLeftManager.setRacketSizeY(racketLeftManager.getRacketSizeY() + 0.5f);
            }

        }
        else if (gameObject.name == "RacketSizeDown(Clone)")
        {
            //Play boost sound effect
            nerfAudio.Play();

            //set the timer of the boost
            racketLeftManager.setSizeTimer(boostTimer);
            if (racketLeftManager.getRacketSizeY() > 0.9f)
            {
                racketLeftManager.setRacketSizeY(racketLeftManager.getRacketSizeY() - 0.3f);
            }

        }
        else if (gameObject.name == "RacketSpeedUp(Clone)")
        {
            //Play boost sound effect
            boostAudio.Play();

            //set the timer of the boost
            racketLeftManager.setSpeedTimer(boostTimer);
            if (racketLeftManager.getRacketSpeed() < 60f)
            {
                racketLeftManager.setRacketSpeed(racketLeftManager.getRacketSpeed() + 10f);
            }
        }
        else if (gameObject.name == "RacketSpeedDown(Clone)")
        {
            //Play boost sound effect
            nerfAudio.Play();

            //set the timer of the boost
            racketLeftManager.setSpeedTimer(boostTimer);
            if (racketLeftManager.getRacketSpeed() > 10f)
            {
                racketLeftManager.setRacketSpeed(racketLeftManager.getRacketSpeed() - 10f);
            }
        }
        else if (gameObject.name == "SpawnExtraBall(Clone)")
        {
            boostAudio.Play();
            GameObject ball = Instantiate((GameObject)Resources.Load("Prefabs/Ball", typeof(GameObject)), Vector3.zero, Quaternion.identity);

        }
        else if (gameObject.name == "BallSpeedIncr(Clone)")
        {
            //Play boost sound effect
            boostAudio.Play();
            ballMovement.setBallSpeed(ballMovement.getBallSpeed() + 10f);
        }
        else if (gameObject.name == "BallSpeedDecr(Clone)")
        {
            //Play boost sound effect
            nerfAudio.Play();
            ballMovement.setBallSpeed(ballMovement.getBallSpeed() - 10f);
        }
    }

    public void BoostRightRocket()
    {
        if (gameObject.name == "RacketSizeUp(Clone)")
        {
            //Play boost sound effect
            boostAudio.Play();

            //set the timer of the boost
            racketRightManager.setSizeTimer(boostTimer);
            if (racketRightManager.getRacketSizeY() < 3f)
            {
                racketRightManager.setRacketSizeY(racketRightManager.getRacketSizeY() + 0.5f);
            }

        }
        else if (gameObject.name == "RacketSizeDown(Clone)")
        {
            //Play boost sound effect
            nerfAudio.Play();

            //set the timer of the boost
            racketRightManager.setSizeTimer(boostTimer);
            if (racketRightManager.getRacketSizeY() > 0.9f)
            {
                racketRightManager.setRacketSizeY(racketRightManager.getRacketSizeY() - 0.3f);
            }
        }
        else if (gameObject.name == "RacketSpeedUp(Clone)")
        {
            //Play boost sound effect
            boostAudio.Play();

            //set the timer of the boost
            racketRightManager.setSpeedTimer(boostTimer);
            if (racketRightManager.getRacketSpeed() < 60f)
            {
                racketRightManager.setRacketSpeed(racketRightManager.getRacketSpeed() + 10f);
            }
        }
        else if (gameObject.name == "RacketSpeedDown(Clone)")
        {
            //Play boost sound effect
            nerfAudio.Play();

            //set the timer of the boost
            racketRightManager.setSpeedTimer(boostTimer);
            if (racketRightManager.getRacketSpeed() > 10f)
            {
                racketRightManager.setRacketSpeed(racketRightManager.getRacketSpeed() - 10f);
            }
        }
        else if (gameObject.name == "SpawnExtraBall(Clone)")
        {
            //Play boost sound effect
            boostAudio.Play();
            GameObject ball = Instantiate((GameObject)Resources.Load("Prefabs/Ball", typeof(GameObject)), Vector3.zero, Quaternion.identity);

        }
        else if (gameObject.name == "BallSpeedIncr(Clone)")
        {
            //Play boost sound effect
            boostAudio.Play();
            ballMovement.setBallSpeed(ballMovement.getBallSpeed() + 10f);
        }
        else if (gameObject.name == "BallSpeedDecr(Clone)")
        {
            //Play boost sound effect
            nerfAudio.Play();
            ballMovement.setBallSpeed(ballMovement.getBallSpeed() - 10f);
        }
    }
}
