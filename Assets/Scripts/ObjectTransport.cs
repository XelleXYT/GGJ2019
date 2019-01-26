using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransport : MonoBehaviour
{
    public float separacionConProta;
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
                posX = player.transform.position.x - player.transform.localScale.x / separacionConProta - gameObject.transform.localScale.x / separacionConProta;
            }
            else
            {
                posX = player.transform.position.x + player.transform.localScale.x / separacionConProta + gameObject.transform.localScale.x / separacionConProta;
            }
            float posY = gameObject.transform.position.y;
            gameObject.transform.position = new Vector3(posX, posY, 0);

            if ((Input.GetKey("s") || Input.GetKey("down") || Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")))
            {
                enganchado = false;
                player.GetComponent<Animator>().SetBool("pushing", false);
            }
            if ((!Input.GetKey("d") && !Input.GetKey("a") && !Input.GetKey("left") && !Input.GetKey("right")))
            {
                player.GetComponent<Animator>().SetBool("pushing", false);
            }
            else
            {
                if (enganchado)
                {
                    player.GetComponent<Animator>().SetBool("pushing", true);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            if (player.transform.position.y - player.transform.localScale.y /2 < gameObject.transform.position.y)
            {
                enganchado = true;
                //collision.gameObject.GetComponent<Animator>().SetBool("pushing", true);
            }
        }
    }
}
