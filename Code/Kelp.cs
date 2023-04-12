using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kelp : MonoBehaviour
{
    private float speed = 10f;
    private float kspeed = .5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        rb.velocity = transform.up * kspeed;

        if (rb.position.y >= 6){
            //position.x = -5;
            transform.position = new Vector3(transform.position.x, -6, transform.position.z);
        }
      
        
    }
}
