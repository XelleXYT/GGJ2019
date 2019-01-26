using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float zoom;

    private void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);

        if (player.transform.position.x > gameObject.transform.position.x + 5)
        {
            gameObject.transform.position = new Vector3(x - 5, y, gameObject.transform.position.z);
        }
        if (player.transform.position.x < gameObject.transform.position.x - 5)
        {
            gameObject.transform.position = new Vector3(x + 5, y, gameObject.transform.position.z);
        }


        /*
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        */
    }
}