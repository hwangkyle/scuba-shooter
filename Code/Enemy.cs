using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isDead = false;
    private int numAmmo = 2;

    public Sprite ammoSprite;

    public AudioClip shootEnemy;
    public AudioClip getAmmo;

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