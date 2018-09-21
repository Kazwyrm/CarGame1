using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// by Tyson

public class GameManager : MonoBehaviour
{
    // reference to the players' checkpoint script to access the lap count
    public PlayerCheckpoints[] m_players;
    // reference to player 1's movement script
    public Movement m_movement;
    // reference to player 2's movement script
    public P2Movement m_p2movement;
    // reference to the win text
    public Text m_winText;

    // deteremines if the game is over
    private bool m_bIsGameOver = false;
    // stores the player number of the winner
    private int m_iWinner;
    // used to wait after the game
    private WaitForSeconds m_endWait;

    private void Start()
    {
        // sets the wait time to 3 seconds
        m_endWait = new WaitForSeconds(3);
        // starts the game loop
        StartCoroutine(GameLoop());
    }

    private void Update()
    {
        // iterates through all of the players
        for (int i = 0; i < m_players.Length; i++)
        {
            // checks if the player has reached the 4th lap
            if (m_players[i].m_iLaps >= 4)
            {
                // sets the winner to the player number
                m_iWinner = i + 1;
                // disables player 1's controls
                m_movement.DisableControls();
                // disables player 2's controls
                m_p2movement.DisableControls();
                // sets the win text to the winning player
                m_winText.text = "Player " + m_iWinner + " Wins!";
                // checks if the winner was player 1
                if (m_iWinner == 1)
                {
                    // changes the text colour to red
                    m_winText.color = Color.red;
                }
                else
                {
                    // changes the text colour to blue
                    m_winText.color = Color.blue;
                }
                // sets the game over status to true
                m_bIsGameOver = true;
            }
        }
    }

    // runs the game while it's not over
    private IEnumerator Playing()
    {
        // loops while the game is not over
        while (!m_bIsGameOver)
        {
            yield return null;
        }
    }
    // waits for the end wait time
    private IEnumerator Wait()
    {
        yield return m_endWait;
    }
    // loops through the coroutines and resets the games
    private IEnumerator GameLoop()
    {
        // starts the game
        yield return StartCoroutine(Playing());
        // ends the game
        yield return StartCoroutine(Wait());
        // sets the winning player to 0
        m_iWinner = 0;
        // clears the win text
        m_winText.text = "";
        // sets the game status to not over
        m_bIsGameOver = false;
        // loads the menu
        SceneManager.LoadScene(0);
    }
}