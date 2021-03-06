﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpandDown : MonoBehaviour
{
    public float min;
    public float max;
    public bool increasing;
    // Start is called before the first frame update
    void Start()
    {
        min = UnityEngine.Random.Range(-10.0f, -1.0f);
        max = UnityEngine.Random.Range(00.0f, 15.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (increasing == true)
        {
            // object forward along z axis
            transform.Translate(Vector3.left * Time.deltaTime);
            if (this.transform.position.x <= min)
            {
                increasing = false;
            }
        }

        if (increasing == false)
        {
            // object down along z axis
            transform.Translate(Vector3.right * Time.deltaTime);

            if (this.transform.position.x >= max)
            {
                increasing = true;
            }
        }
    }
}
