using UnityEngine;

/*
    ENEMY BEHAVIOUR:
    Moves like the "original" enemy, but shoots every `waitTime` seconds.
*/
public class EnemyB : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float bulletSpeed = 2f * Bubble.speed;
    private float waitTime; // seconds between each shot (2 -> .75)
    private const float START_WAIT = 2f;
    private const float END_WAIT = .75f;
    private float timer; // to count how long has passed, and it's not 0f to account for the initial time it takes for the enemy to appear from below
    private bool isDead = false;
    private int numAmmo = 3;

    public AudioClip enemyFire;
    public AudioClip shootEnemy;
    public AudioClip getAmmo;

    public Sprite ammoSprite;

    void Start()
    {
        float mWait = (END_WAIT - START_WAIT) / Bubble.MAX_SPEED;
        waitTime = mWait * Bubble.speed + START_WAIT;

        timer = waitTime; // shoot upon appearance(*)
    }

    void Update()
    {
        if (!isDead) {
            if (transform.position.y > -4.5) // (*)the bottom of screen is -5, -4.5 to account for reaction time
            {
                timer += Time.deltaTime;
                if (timer >= waitTime) {
                    timer = 0;
                    AudioSource.PlayClipAtPoint(enemyFire, GetComponent<Transform>().position);
                    GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1f), Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                    bullet.GetComponent<SpriteRenderer>().color = new Color(0,123,0,1);
                }
            }
        }
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
                transform.localScale = new Vector3(0.35f, 0.35f, 1f);
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