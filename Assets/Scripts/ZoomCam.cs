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
            /*
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
            */
            StartCoroutine(zoomIn());
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(zoomIn());
    }

    private IEnumerator zoomIn()
    {
        if (!isZoomed)
        {
            for (float i = 0; i < maxSize; i += augmentionSpeed)
            {
                Camera.main.orthographicSize += augmentionSpeed;
                isZoomed = true;
                yield return null;
            }
        }
        else
        {
            for (float i = minSize; i > 0; i -= augmentionSpeed)
            {
                Camera.main.orthographicSize -= augmentionSpeed;
                isZoomed = false;
                yield return null;
            }
        }
    }
}
