using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour
{
    private int numAmmo = 3;

    public int health = 2;
    public DiverMove diver; // it seems like we don't need this but I kept it just in case
    public Sprite ammoSprite;
    public AudioClip shootEnemy;
    public AudioClip getAmmo;

    // Start is called before the first frame update
    void Start()
    {
        diver = GameObject.FindWithTag("Player").GetComponent<DiverMove>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (health > 0 && other.tag == "Bullet") {
            health--;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(shootEnemy, GetComponent<Transform>().position);
            if (health == 0) {
                SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = ammoSprite;
                sr.color = new Color(255,255,255,1);
                transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                gameObject.tag = "Ammo";
            }
        }
        if (health == 0 && other.tag == "Player") {
            AudioSource.PlayClipAtPoint(getAmmo, GetComponent<Transform>().position);
            AmmoText.GainAmmo(numAmmo);
            Destroy(gameObject);
        }
    }
}
