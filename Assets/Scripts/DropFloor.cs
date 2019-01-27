using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFloor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "caja")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.AddComponent<Rigidbody2D>();
            Destroy(gameObject);
        }
    }
}
