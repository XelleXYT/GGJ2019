using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float fuerzaMovimiento;
    public float fuerzaSalto;
    private bool puedeSaltar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            if(!puedeSaltar)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(fuerzaMovimiento / 2) * Time.deltaTime,0));
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fuerzaMovimiento * Time.deltaTime,0));
            }
        }
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            if(!puedeSaltar)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((fuerzaMovimiento / 2) * Time.deltaTime,0));
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaMovimiento * Time.deltaTime,0));
            }
        }
        if((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")) && puedeSaltar)
        {
            puedeSaltar = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,fuerzaSalto));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "suelo" || collision.transform.tag == "plataforma")
        {
            puedeSaltar = true;
        }
        if(collision.transform.tag == "agarradera" && !puedeSaltar)
        {
           
        }
    }
}
