using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public AudioClip siguienteCancion;

    public void PlayGame()
    {
        GetComponent<SoundManager>().PlaySingle(siguienteCancion);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
