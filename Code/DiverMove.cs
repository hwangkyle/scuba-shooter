using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverMove : MonoBehaviour
{
    private float speed = 12f;
    private Rigidbody2D rb;

    public static float timer;
    private float airTimer;
    private float lowAirTimer;
    
    public static int ammoCount = 10;

    private int startAir = 100;
    public int currentAir;
    private float airLossTime = .7f;
    public AirBar airbar;
    private float lowAirTime = 2.5f;


    public GameObject bulletPrefab;
    private Vector2 bulletVelocity = new Vector2(0f, -12f);
    public AudioSource fireSound;
    public AudioClip hitByEnemy;

    public AudioSource lowAir;
    


    void Start()
    {
        Time.timeScale = 1;
        Screen.SetResolution(1280, 720, false);
        rb = GetComponent<Rigidbody2D> ();

        currentAir = startAir;
        airbar.SetStartHealth(startAir);

        ammoCount = 10;
        timer = 0;
        airTimer = 0;
    }

    public void HitBubble()
    {
        if (currentAir < 95)
        {
            currentAir += 5;
        }
        else
        {
            currentAir = 100;
        }
        airbar.SetHealth(currentAir);
    }

    public void HitEnemy(int damage)
    {
        currentAir -= damage;
        airbar.SetHealth(currentAir);
    }

    public void HitbyBullet()
    {
        currentAir -= 3;
        airbar.SetHealth(currentAir);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Anem" || other.tag == "AnemA" || other.tag == "AnemB" || other.tag == "AnemC")
        {
            AudioSource.PlayClipAtPoint(hitByEnemy, GetComponent<Transform>().position);
            Destroy(other.gameObject);
            if (other.tag == "Anem" || other.tag == "AnemB") HitEnemy(5);
            else if (other.tag == "AnemA") HitEnemy(3);
            else HitEnemy(8);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 vel = rb.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = vel;
        
        if (pos.x > 4)
            pos.x = 4;
        else if (pos.x < -4)
            pos.x = -4;
        transform.position = pos;

        timer += Time.deltaTime;
        airTimer += Time.deltaTime;
        lowAirTimer += Time.deltaTime;
        if (airTimer >= airLossTime && currentAir > 0)
        {
            currentAir--;
            airbar.SetHealth(currentAir);
            airTimer = 0;
        }

        if (lowAirTimer >= lowAirTime && currentAir <= 20 && currentAir > 0)
        {
            lowAir.Play();
            lowAirTimer = 0;
        }


        if ((Input.GetKeyDown(KeyCode.Space)) && ammoCount > 0 && currentAir > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, pos - new Vector2(0, 1.5f), Quaternion.identity);
            
            fireSound.Play();

            bullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity;

            AmmoText.LoseAmmo();
        }
    }
}
