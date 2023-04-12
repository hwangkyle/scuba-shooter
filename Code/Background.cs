using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Color32 color1;
    private Color32 color2;

    //private float timer;
    
    public static float duration = 240f;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        color1 = new Color32(81, 226, 255, 1);
        color2 = new Color32(0, 0, 50, 1);

        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = color1;

    }

    // Update is called once per frame
    void Update()
    {
        if (DiverMove.timer == 0)
        {
            cam.backgroundColor = new Color32(81, 226, 255, 1);
            color1 = new Color32(81, 226, 255, 1);
        }
        if (DiverMove.timer < duration)
        {
            Color start = color1;
            Color end = color2;
            float t = Mathf.PingPong(DiverMove.timer, duration) / duration;
            cam.backgroundColor = Color.Lerp(start, end, t);
        }
    }
}
