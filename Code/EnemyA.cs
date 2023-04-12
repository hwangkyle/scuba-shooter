using UnityEngine;

/*
    ENEMY BEHAVIOUR:
    EnemyA just moves left and right.
*/
public class EnemyA : MonoBehaviour
{
    private float prevTime;
    private float range = 1.5f; // not a good name but can't think of anything else; +/- distance to travel from start
    private float speed = 4f; // how fast to move back and forth
    private float x0; // initial x position
    private float t0; // initial time
    private bool isDead = false;
    private int numAmmo = 3;
    public AudioClip shootEnemy;
    public AudioClip getAmmo;

    public Sprite ammoSprite;
    
    void Start()
    {
        prevTime = Time.time;
        x0 = transform.position.x;
        t0 = Time.time;

        /*
            This is so that the position of the enemy does not exceed the bounds
            Reminder: bounds are from -4 to 4. By Update(), the enemy will move +/- `range` units.
        */
        float bound = 4-range;
        if (x0 >= bound)
        {
            transform.position = new Vector2(bound, transform.position.y);
            x0 = bound;
        }
        else if (x0 <= -bound)
        {
            transform.position = new Vector2(-bound, transform.position.y);
            x0 = -bound;
        }
    }
    
    void Update()
    {
        // `range` acts of the amplitude and `speed` acts as the frequency
        /* 
            The reason I did `Time.time - t` instead of just Time.time or something is so that all EnemyA's start with the
            same movement. If I did just `Time.time`, it would result in all EnemyA's moving in the same direction at the
            same time.
        */
        if (!isDead)
            transform.position = new Vector2(x0 + range*Mathf.Sin(speed*(Time.time - t0)), transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead) {
            if (other.tag == "Bullet") {
                AudioSource.PlayClipAtPoint(shootEnemy, GetComponent<Transform>().position);
                Destroy(other.gameObject);
                SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = ammoSprite;
                sr.color = new Color(255,255,255,1);
                gameObject.tag = "Ammo";
                isDead = true;
            }
        }
        else {
            if (other.tag == "Player") {
                AudioSource.PlayClipAtPoint(getAmmo, GetComponent<Transform>().position);
                AmmoText.GainAmmo(numAmmo);
                Destroy(gameObject);
            }
        }
    }
}