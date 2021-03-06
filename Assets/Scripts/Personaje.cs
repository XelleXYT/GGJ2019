﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float fuerzaMovimiento;
    public float fuerzaSalto;
    public int tiempoSalto;
    public float velocMaxima;

    public AudioClip moveSound1;
    public AudioClip moveSound2;

    public AudioClip jumpSound1;
    public AudioClip jumpSound2;
    public AudioClip jumpSound3;

    public AudioClip gameOver;


    private int tiempoSaltoAux;
    private int agarrado; // 1 izq   2 der

    private float alturaCollider;
    private float anguloRampa;

    private bool puedeSaltar;
    private bool tiempoSaltando;
    private bool encajado;
    private bool rampa;


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
       
        if(tiempoSaltoAux != tiempoSalto)
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
                rb.AddForce(new Vector2(0,fuerzaSalto*1.5f));
                agarrado = 0;
                encajado = false;
                gameObject.GetComponent<Animator>().SetBool("jumping",true);
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
                if(!rampa)
                {
                    rb.AddForce(new Vector2(-fuerzaMovimiento * Time.deltaTime,0));
                }
                else
                {
                    if(anguloRampa <= 45 && anguloRampa >= 0)
                    {
                        rb.AddForce(new Vector2(-fuerzaMovimiento * Time.deltaTime,0));
                    }
                    else
                    {
                        rb.AddForce(new Vector2(-(fuerzaMovimiento / 2) * Time.deltaTime,(fuerzaMovimiento * 1.7f) * Time.deltaTime));
                    }
                }
                gameObject.GetComponent<Animator>().SetBool("moving",true);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
                if(!rampa)
                {
                    rb.AddForce(new Vector2(fuerzaMovimiento * Time.deltaTime,0));
                }
                else
                {
                    if(anguloRampa >= -45 && anguloRampa <= 0)
                    {
                        rb.AddForce(new Vector2((fuerzaMovimiento / 2) * Time.deltaTime,0));
                    }
                    else
                    {
                        rb.AddForce(new Vector2((fuerzaMovimiento / 2) * Time.deltaTime,(fuerzaMovimiento * 1.7f) * Time.deltaTime));
                    }

                }
                gameObject.GetComponent<Animator>().SetBool("moving",true);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if(!Input.GetKey("d") && !Input.GetKey("right") && !Input.GetKey("a") && !Input.GetKey("left"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving",false);
            if(rampa)
            {
                if(anguloRampa >= -45 && anguloRampa <= 0)
                {
                    rb.AddForce(new Vector2(-fuerzaMovimiento * Time.deltaTime, 0));
                }
                else
                {
                    rb.AddForce(new Vector2(fuerzaMovimiento * Time.deltaTime,0));
                }
            }

        }
        if((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")) && puedeSaltar && tiempoSaltando)
        {
            SoundManager.instance.RandomizeSfx(jumpSound1,jumpSound2,jumpSound3);
            puedeSaltar = false;
            tiempoSaltando = false;
            tiempoSaltoAux = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(0,fuerzaSalto));
            gameObject.GetComponent<Animator>().SetBool("jumping",true);
        }
    }

    void FixedUpdate()
    {
        // -1 to 1 value for horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        // A Vector gives you simply a value x,y,z, ex  1,0,0 for
        // max right input, 0,1,0 for max up.
        // Keep the current Y value, which increases 
        // for each interval because of gravity.
        var movement = new Vector3(moveHorizontal *
          velocMaxima,rb.velocity.y,0);
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "suelo")
        {
            puedeSaltar = true;
            rampa = false;
            gameObject.GetComponent<Animator>().SetBool("jumping",false);
        }
        if(collision.transform.tag == "caja")
        {
            puedeSaltar = true;
            gameObject.GetComponent<Animator>().SetBool("jumping",false);
        }
        if(collision.transform.tag == "rampa")
        {
            puedeSaltar = true;
            rampa = true;
            anguloRampa = collision.transform.rotation.z;
            gameObject.GetComponent<Animator>().SetBool("jumping",false);
        }
        else if(collision.transform.tag == "agarradera")
        {
            if(collision.transform.position.y + rb.transform.localScale.y > rb.transform.position.y)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                agarrado = 1;
            }
            alturaCollider = collision.transform.position.y;
            gameObject.GetComponent<Animator>().SetBool("jumping",false);
        }
        else if(collision.transform.tag == "plataforma" && collision.transform.position.y + rb.transform.localScale.y < rb.transform.position.y)
        {
            puedeSaltar = true;
            gameObject.GetComponent<Animator>().SetBool("jumping",false);
        }
    }


}
