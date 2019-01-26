using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public float maxSize;
    public float minSize;
    public float augmentionSpeed;

    private bool isZoomed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zoom")
        {
            if (!isZoomed)
            {
                Camera.main.orthographicSize = Mathf.Lerp(maxSize, minSize, Time.deltaTime * augmentionSpeed);
                isZoomed = true;
            }
            else
            {
                Camera.main.orthographicSize = Mathf.Lerp(minSize, maxSize, Time.deltaTime * augmentionSpeed);
                isZoomed = false;
            }
            
        }
    }
}
