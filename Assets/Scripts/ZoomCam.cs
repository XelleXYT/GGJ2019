using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public float maxSize;
    public float minSize;
    public float augmentionSpeed;

    private bool isZoomed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zoom")
        {
            StartCoroutine(zoomIn());
        }
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
