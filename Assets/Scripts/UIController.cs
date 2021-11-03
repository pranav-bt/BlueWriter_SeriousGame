using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("1_MainScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
