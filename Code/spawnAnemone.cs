using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAnemone : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyAPrefab;
    public GameObject enemyBPrefab;
    public GameObject enemyCPrefab;

    private float spawnTime;
    private Vector2 bounds;
    
    // bc for some reason c#/unity likes to repeat the same number when "randomly" choosing
    private int prev = -1;
    private int numTimes = 0;

    // rates of spawning
    private const float NORMAL_START = 2f;
    private const float NORMAL_END = .8f;
    private const float NO_AMMO_START = 1.25f;
    private const float NO_AMMO_END = .4f;
    // m for mx+b
    private float mNorm;
    private float mAmmo;

    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemy());
        mNorm = (NORMAL_END - NORMAL_START) / Bubble.MAX_SPEED;
        mAmmo = (NO_AMMO_END - NO_AMMO_START) / Bubble.MAX_SPEED;

    }
    private void spawnEnemy(){
        // spreads out enemies types
        int maxRange;
        if (DiverMove.timer < 20f) maxRange = 1;
        else if (DiverMove.timer < 40f) maxRange = 2;
        else if (DiverMove.timer < 60f) maxRange = 3;
        else maxRange = 4;
        
        int rand = Random.Range(0, maxRange);
        // this makes shooting enemies spawn more when 0 ammo (less likely when longer in the game)
        if (DiverMove.ammoCount == 0)
        {
            int weightedRand = Random.Range(0, 4 + maxRange);
            if (weightedRand <= 3) rand = 2;
            else rand = (3 + maxRange) - weightedRand;
        }
        
        // this makes so enemies don't repeat too much
        else if (maxRange > 1) {
            if (prev != rand) numTimes = 0;
            else if (prev == rand && numTimes == 2){
                while (prev == rand)
                    rand = Random.Range(0, maxRange);
                numTimes = 0;
            }
        }
        prev = rand;
        numTimes++;

        GameObject e;
        if (rand == 0) e = Instantiate(enemyPrefab) as GameObject;
        else if (rand == 1) e = Instantiate(enemyAPrefab) as GameObject;
        else if (rand == 2) e = Instantiate(enemyBPrefab) as GameObject;
        else e = Instantiate(enemyCPrefab) as GameObject;

        e.transform.position = new Vector2(Random.Range(-4, 4), bounds.y * -2);
    }

    IEnumerator enemy(){
        while(true){
            if (DiverMove.ammoCount == 0) spawnTime = mAmmo * Bubble.speed + NO_AMMO_START; // 1.25 -> 0.5
            else spawnTime = mNorm * Bubble.speed + NORMAL_START; // 3.125 -> 1.25
            yield return new WaitForSeconds(spawnTime);
            spawnEnemy();
        }
    }

}
