using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBubbles : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float spawnTime = 3f;
    private Vector2 bounds;
    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(bub());
    }
    private void spawnBubble(){
        GameObject b = Instantiate(bubblePrefab) as GameObject;
        b.transform.position = new Vector2(Random.Range(-4, 4), bounds.y * -2);
    }

    IEnumerator bub(){
        while(true){
            yield return new WaitForSeconds(spawnTime);
            spawnBubble();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform b = bubblePrefab.GetComponent<Transform>();
        if (b.position.y > 5)
        {
            Destroy(bubblePrefab);
        }
    }
}
