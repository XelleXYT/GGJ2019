using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {
            gameObject.transform.Translate(-velocidad * Time.deltaTime,0,0);
        }
        if(Input.GetKey("d"))
        {
            gameObject.transform.Translate(velocidad * Time.deltaTime,0,0);
        }
    }
}
