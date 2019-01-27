using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad;

    public GameObject pj = null;

    private void Update()
    {
        gameObject.transform.Translate(new Vector3(velocidad, 0, 0));
        gameObject.GetComponent<Animator>().SetBool("moving",true);
        if(velocidad<0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limitador")
        {
            velocidad *= -1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coche")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), pj.GetComponent<CapsuleCollider2D>(), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pj = collision.gameObject;
            if (!collision.gameObject.GetComponent<HideOnCar>().isHidden)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), pj.GetComponent<CapsuleCollider2D>(), true);
            }
        }
        if(collision.gameObject.tag == "caja")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
        }
    }

}
