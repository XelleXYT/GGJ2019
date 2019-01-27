using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public GameObject player;
    public float movimientoFondo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Animator>().GetBool("moving"))
        {
            if(Input.GetKey("d") || Input.GetKey("right"))
            {
               
            }
            if(Input.GetKey("a") || Input.GetKey("left"))
            {
                gameObject.transform.Translate(movimientoFondo,0,0);
            }
            
        }
    }
}
