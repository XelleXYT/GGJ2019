using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransport : MonoBehaviour
{
    bool enganchado = false;
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (enganchado)
        {
            float posX;
            if (player.transform.localPosition.x > gameObject.transform.localPosition.x)
            {   
                posX = player.transform.position.x - player.transform.localScale.x / 2 - gameObject.transform.localScale.x / 2;
            }
            else
            {
                posX = player.transform.position.x + player.transform.localScale.x / 2 + gameObject.transform.localScale.x / 2;
            }
            float posY = gameObject.transform.position.y;
            gameObject.transform.position = new Vector3(posX, posY, 0);

            if ((Input.GetKey("s") || Input.GetKey("down") || Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")))
            {
                enganchado = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enganchado = true;
            player = collision.gameObject;
        }
    }
}
