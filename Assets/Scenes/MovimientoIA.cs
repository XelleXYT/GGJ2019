using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoIA : MonoBehaviour
{
    float direccion;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limitador")
        {
            direccion *= -1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 0, 0));
    }
}
