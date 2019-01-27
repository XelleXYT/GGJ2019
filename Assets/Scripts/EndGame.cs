using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject soundManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(2);
    }
}
