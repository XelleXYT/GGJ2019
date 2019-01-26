using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float fuerzaMovimiento;
    public float fuerzaSalto;

    private bool puedeSaltar;
    private int agarrado;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")) && puedeSaltar)
        {
            puedeSaltar = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(new Vector2(0,fuerzaSalto));
        }
        if(agarrado > 0)
        {
            if((Input.GetKey("a") || Input.GetKey("left")) && agarrado == 1)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(new Vector2(-(fuerzaMovimiento / 2) * Time.deltaTime,0));
                agarrado = 0;
            }
            if((Input.GetKey("d") || Input.GetKey("right") && agarrado == 2))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(new Vector2((fuerzaMovimiento / 2) * Time.deltaTime,0));
                agarrado = 0;      
            }
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
                if(collision.transform.position.x < rb.transform.position.y)
                {
                    agarrado = 1;
                }
                else
                {
                    agarrado = 2;
                }
            }
        }
        else if(collision.transform.tag == "plataforma" && collision.transform.position.y + rb.transform.localScale.y < rb.transform.position.y)
        {
            puedeSaltar = true;
        }
    }

    //private void agarrandose(Collision2D collision)
    //{
    //    bool ledgeOnLeft = gameObject.GetComponent<Rigidbody2D>().transform.position.x > collision.transform.position.x;
    //    bool ledgeOnRight = !ledgeOnLeft;

    //    if((Input.GetKey("down")|| Input.GetKey("s"))
    //        || (mInputs[(int)KeyInput.GoLeft] && ledgeOnRight)
    //        || (mInputs[(int)KeyInput.GoRight] && ledgeOnLeft))
    //    {
    //        if(ledgeOnLeft)
    //            mCannotGoLeftFrames = 3;
    //        else
    //            mCannotGoRightFrames = 3;

    //        mCurrentState = CharacterState.Jump;
    //    }
    //    else if(mInputs[(int)KeyInput.Jump])
    //    {
    //        mSpeed.y = mJumpSpeed;
    //        mCurrentState = CharacterState.Jump;
    //    }
    //}
}
