using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DiverMove diver;
    public AudioClip shotByEnemy;

    // Start is called before the first frame update
    void Start()
    {
        diver = GameObject.FindWithTag("Player").GetComponent<DiverMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform bullet = gameObject.GetComponent<Transform>();
        // Regarding the commented code below, the reason I set the velocity when instantiating was to make bullet multipurpose, so I redid what I implemented.
        // bullet.position += Vector3.down * speed;
        if (bullet.position.y < -5 || bullet.position.y > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(shotByEnemy, GetComponent<Transform>().position);
            diver.HitbyBullet();
            Destroy(gameObject);
        }
    }
}
