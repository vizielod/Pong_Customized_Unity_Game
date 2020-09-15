using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketRightManager : MonoBehaviour
{
    public static RacketRightManager instance;

    public float racketSizeY = 1.4f;
    public float racketSpeed = 30f;

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
        transform.localScale = new Vector3(transform.localScale.x, racketSizeY, transform.localScale.z);
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
}
