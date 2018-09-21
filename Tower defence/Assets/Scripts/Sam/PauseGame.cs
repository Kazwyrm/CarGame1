using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Sam

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    // reference to player 1
    public GameObject m_player1;
    // reference to player 2
    public GameObject m_player2;

    // reference to player 1's movement script
    private Movement m_movement;
    // reference to player 2's movement script
    private P2Movement m_p2Movement;

    private void Start()
    {
        // gets the relevant component from the corresponding player
        m_movement = m_player1.GetComponent<Movement>();
        m_p2Movement = m_player2.GetComponent<P2Movement>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Pause") != 0)
        {
            pauseMenu.SetActive(true);

            // by Tyson
            // stops time
            Time.timeScale = 0;
            // disables the controls
            m_movement.DisableControls();
            m_p2Movement.DisableControls();
        }
    }

    // by Tyson

    // enables the controls when the pause is stopped
    public void ReturnToGame()
    {
        // sets the time back to normal
        Time.timeScale = 1;
        // enables the controls
        m_movement.EnableControls();
        m_p2Movement.EnableControls();
    }
}