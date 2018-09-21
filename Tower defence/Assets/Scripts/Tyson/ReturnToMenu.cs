using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// by Tyson

public class ReturnToMenu : MonoBehaviour
{
    public void Menu()
    {
        // loads the menu
        SceneManager.LoadScene(0);
    }
}