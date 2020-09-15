using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketRightManager : MonoBehaviour
{
    public static RacketRightManager instance;

    public float racketSizeY = 1.4f;
    public float racketSpeed = 30f;

    public float defaultRacketSizeY = 1.4f;
    public float defaultRacketSpeed = 30f;

    public float sizeTimer;
    public float speedTimer;

    // Start is called before the first frame update
    public Rigidbody2D racket;
    void Start()
    {
        instance = this;

        //racket = GetComponent<Rigidbody2D>();

        racketSizeY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        sizeTimer -= Time.deltaTime;
        speedTimer -= Time.deltaTime;
        //transform.localScale = new Vector3(transform.localScale.x, racketSizeY, transform.localScale.z);
        Debug.Log("Timer: " + sizeTimer);
        if (sizeTimer < 0)
        {
            racketSizeY = defaultRacketSizeY;
            transform.localScale = new Vector3(transform.localScale.x, racketSizeY, transform.localScale.z);
        }
        else if (sizeTimer > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, racketSizeY, transform.localScale.z);
        }
        if (speedTimer < 0)
        {
            racketSpeed = defaultRacketSpeed;
        }


    }

    public float getRacketSizeY()
    {
        return racketSizeY;
    }

    public void setRacketSizeY(float racketSizeY)
    {
        Debug.Log("Set rocket length to: " + racketSizeY);
        this.racketSizeY = racketSizeY;
    }

    public float getRacketSpeed()
    {
        return racketSpeed;
    }

    public void setRacketSpeed(float racketSpeed)
    {
        this.racketSpeed = racketSpeed;
    }

    public void setSizeTimer(float timer)
    {
        this.sizeTimer = timer;
    }

    public float getSizeTimer()
    {
        return sizeTimer;
    }

    public void setSpeedTimer(float timer)
    {
        this.speedTimer = timer;
    }

    public float getSpeedTimer()
    {
        return speedTimer;
    }
}
