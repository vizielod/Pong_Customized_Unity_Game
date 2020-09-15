using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float speed;
    public string axis = "Vertical";

    private RacketLeftManager racketLeftManager;
    private RacketRightManager racketRightManager;

    private void Start()
    {
        if(gameObject.name == "RacketLeft")
        {
            racketLeftManager = RacketLeftManager.instance;
        }
        else if(gameObject.name == "RacketRight")
        {
            racketRightManager = RacketRightManager.instance;
        }
        
    }
    private void FixedUpdate()
    {
        if(gameObject.name == "RacketLeft")
        {
            speed = racketLeftManager.getRacketSpeed();
            float v = Input.GetAxisRaw(axis);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
        }
        else if (gameObject.name == "RacketRight")
        {
            speed = racketRightManager.getRacketSpeed();
            float v = Input.GetAxisRaw(axis);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
        }
        
    }
}
