using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoGrid : MonoBehaviour
{
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject a5;
    public GameObject a6;
    public GameObject a7;
    public GameObject a8;
    public GameObject a9;
    public GameObject a10;
    public GameObject a11;
    public GameObject a12;
    public GameObject a13;
    public GameObject a14;
    public GameObject a15;
    public GameObject a16;
    public GameObject a17;
    public GameObject a18;
    public GameObject a19;
    public GameObject a20;
    public GameObject a21;
    public GameObject a22;
    public GameObject a23;
    public GameObject a24;
    public GameObject a25;
    
    private int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = DiverMove.ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmo = DiverMove.ammoCount;
        if (currentAmmo < 1)
        {
            a1.SetActive(false);
        }
        else
        {
            a1.SetActive(true);
        }
        if (currentAmmo < 2)
        {
            a2.SetActive(false);
        }
        else
        {
            a2.SetActive(true);
        }
        if (currentAmmo < 3)
        {
            a3.SetActive(false);
        }
        else
        {
            a3.SetActive(true);
        }
        if (currentAmmo < 4)
        {
            a4.SetActive(false);
        }
        else
        {
            a4.SetActive(true);
        }
        if (currentAmmo < 5)
        {
            a5.SetActive(false);
        }
        else
        {
            a5.SetActive(true);
        }
        if (currentAmmo < 6)
        {
            a6.SetActive(false);
        }
        else
        {
            a6.SetActive(true);
        }
        if (currentAmmo < 7)
        {
            a7.SetActive(false);
        }
        else
        {
            a7.SetActive(true);
        }
        if (currentAmmo < 8)
        {
            a8.SetActive(false);
        }
        else
        {
            a8.SetActive(true);
        }
        if (currentAmmo < 9)
        {
            a9.SetActive(false);
        }
        else
        {
            a9.SetActive(true);
        }
        if (currentAmmo < 10)
        {
            a10.SetActive(false);
        }
        else
        {
            a10.SetActive(true);
        }
        if (currentAmmo < 11)
        {
            a11.SetActive(false);
        }
        else
        {
            a11.SetActive(true);
        }
        if (currentAmmo < 12)
        {
            a12.SetActive(false);
        }
        else
        {
            a12.SetActive(true);
        }
        if (currentAmmo < 13)
        {
            a13.SetActive(false);
        }
        else
        {
            a13.SetActive(true);
        }
        if (currentAmmo < 14)
        {
            a14.SetActive(false);
        }
        else
        {
            a14.SetActive(true);
        }
        if (currentAmmo < 15)
        {
            a15.SetActive(false);
        }
        else
        {
            a15.SetActive(true);
        }
        if (currentAmmo < 16)
        {
            a16.SetActive(false);
        }
        else
        {
            a16.SetActive(true);
        }
        if (currentAmmo < 17)
        {
            a17.SetActive(false);
        }
        else
        {
            a17.SetActive(true);
        }
        if (currentAmmo < 18)
        {
            a18.SetActive(false);
        }
        else
        {
            a18.SetActive(true);
        }
        if (currentAmmo < 19)
        {
            a19.SetActive(false);
        }
        else
        {
            a19.SetActive(true);
        }
        if (currentAmmo < 20)
        {
            a20.SetActive(false);
        }
        else
        {
            a20.SetActive(true);
        }
        if (currentAmmo < 21)
        {
            a21.SetActive(false);
        }
        else
        {
            a21.SetActive(true);
        }
        if (currentAmmo < 22)
        {
            a22.SetActive(false);
        }
        else
        {
            a22.SetActive(true);
        }
        if (currentAmmo < 23)
        {
            a23.SetActive(false);
        }
        else
        {
            a23.SetActive(true);
        }
        if (currentAmmo < 24)
        {
            a24.SetActive(false);
        }
        else
        {
            a24.SetActive(true);
        }
        if (currentAmmo < 25)
        {
            a25.SetActive(false);
        }
        else
        {
            a25.SetActive(true);
        }
        
    }
}
