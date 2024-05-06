using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rotation : MonoBehaviour
{
    private Rigidbody rb;
    public static float rotation = 2;    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.AddTorque(0,0,rotation);
    }

}
