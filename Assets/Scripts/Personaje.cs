using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float fuerzaMovimiento;
    public float fuerzaSalto;
    public int tiempoSalto;


    private int tiempoSaltoAux;
    private int agarrado; // 1 izq   2 der

    private float alturaCollider;

    private bool puedeSaltar;
    private bool tiempoSaltando;
    private bool encajado;
    

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoSaltoAux = tiempoSalto;
        encajado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoSaltoAux!=tiempoSalto)
        {
            tiempoSaltoAux += 1;
            tiempoSaltando = false;
        }
        else
        {
            tiempoSaltando = true;
        }

        if(agarrado > 0 && !encajado)
        {
            if(rb.transform.position.y < alturaCollider)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 10,Space.World);

                if(rb.transform.position.y >= alturaCollider)
                {
                    encajado = true;
                }
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * 10,Space.World);

                if(rb.transform.position.y <= alturaCollider)
                {
                    encajado = true;
                }
            }
        }
        else if(encajado)
        {
            if((Input.GetKey("s") || Input.GetKey("down")))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                agarrado = 0;
                encajado = false;
            }
            else if((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")))
            {
                puedeSaltar = false;
                tiempoSaltando = false;
                tiempoSaltoAux = 0;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(new Vector2(0,fuerzaSalto * 2));
                agarrado = 0;
                encajado = false;
            }
        }
        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            if(!puedeSaltar)
            {
                rb.AddForce(new Vector2(-(fuerzaMovimiento / 2) * Time.deltaTime,0));
            }
            else
            {
                rb.AddForce(new Vector2(-fuerzaMovimiento * Time.deltaTime,0));
            }
        }
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            if(!puedeSaltar)
            {
                rb.AddForce(new Vector2((fuerzaMovimiento / 2) * Time.deltaTime,0));
            }
            else
            {
                rb.AddForce(new Vector2(fuerzaMovimiento * Time.deltaTime,0));
            }
        }
        if((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")) && puedeSaltar&&tiempoSaltando)
        {
            puedeSaltar = false;
            tiempoSaltando = false;
            tiempoSaltoAux = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(0,fuerzaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.transform.tag == "suelo"))
        {
            puedeSaltar = true;
        }
        else if(collision.transform.tag == "agarradera")
        {
            if(collision.transform.position.y + rb.transform.localScale.y > rb.transform.position.y)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                agarrado = 1;
            }
           alturaCollider = collision.transform.position.y;
        }
        else if(collision.transform.tag == "plataforma" && collision.transform.position.y + rb.transform.localScale.y < rb.transform.position.y)
        {
            puedeSaltar = true;
        }
    }

    
}
