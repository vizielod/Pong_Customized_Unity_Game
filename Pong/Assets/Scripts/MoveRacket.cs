﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float speed;
    public string axis = "Vertical";

    private RacketManager racketManager;
    private void Start()
    {
        racketManager = RacketManager.instance;
    }
    private void FixedUpdate()
    {
        speed = racketManager.getRacketSpeed();
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
