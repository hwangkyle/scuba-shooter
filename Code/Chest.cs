using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject bubblePrefab;
    public AudioClip hitChest;

    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(hitChest, GetComponent<Transform>().position);
            Instantiate(bubblePrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}