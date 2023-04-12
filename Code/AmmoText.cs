using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    private Text a;
    
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a.text = "Ammo: ";
    }

    public static void LoseAmmo()
    {
        DiverMove.ammoCount--;
    }

    public static void GainAmmo(int amount)
    {
        DiverMove.ammoCount += amount;
        if (DiverMove.ammoCount > 25)
        {
            DiverMove.ammoCount = 25;
        }
    }
}
