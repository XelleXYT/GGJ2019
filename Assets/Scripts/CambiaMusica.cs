using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaMusica : MonoBehaviour
{

    public GameObject soundManager;
    public AudioClip audioClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            soundManager.GetComponent<SoundManager>().musicSource.clip = audioClip;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundManager.GetComponent<SoundManager>().musicSource.clip = audioClip;
            soundManager.GetComponent<SoundManager>().musicSource.Play();
            Destroy(gameObject);
        }
    }
}
