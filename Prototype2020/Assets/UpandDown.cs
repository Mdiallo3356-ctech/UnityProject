using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpandDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // object forward along z axis
        transform.Translate(Vector3.forward * Time.deltaTime);

        // object down along z axis
        transform.Translate(Vector3.down * Time.deltaTime);
    }
}
