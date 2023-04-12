using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public static float speed;
    public const float MIN_SPEED = 1.5f;
    public const float MAX_SPEED = 8f;
    private float m = (MAX_SPEED - MIN_SPEED) / Background.duration; // `m` as in y = mx + b
    private Rigidbody2D rb;
    private Vector2 bounds;

    public AudioClip hitBubble;
    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Min(MAX_SPEED, m*DiverMove.timer + MIN_SPEED);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,speed);
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > bounds.y)
        {
            Destroy(this.gameObject);
        }
        
        speed = Mathf.Min(MAX_SPEED, m*DiverMove.timer + MIN_SPEED);
        rb.velocity = new Vector2(0,speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Bubble" && other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(hitBubble, GetComponent<Transform>().position);
            GameObject.FindWithTag("Player").GetComponent<DiverMove>().HitBubble();
            Destroy(gameObject);
        }
    }
}
