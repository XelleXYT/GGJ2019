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
            float posX = player.transform.position.x + player.transform.localScale.x / 2 + gameObject.transform.localScale.x / 2;
            float posY = player.transform.position.y - player.transform.localScale.y / 2 + gameObject.transform.localScale.y / 2;
            gameObject.transform.position = new Vector3(posX, posY, 0);
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
