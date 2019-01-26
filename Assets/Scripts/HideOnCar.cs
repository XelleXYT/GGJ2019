using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnCar : MonoBehaviour
{
    public  bool isHidden = false;
    bool canHide = false;
    SpriteRenderer sr;

    private void Update()
    {
        if (canHide)
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
            if (!isHidden)
            {
                if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
                {
                    isHidden = true;
                    sr.sortingOrder = 0;
                    //print("oculto");
                }
            }
            else
            {
                if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
                {
                    isHidden = false;
                    sr.sortingOrder = 2;
                    //print("visible");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coche")
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coche")
        {
            canHide = false;
            isHidden = false;
            sr.sortingOrder = 2;
            //print("visible");
        }
    }
}
