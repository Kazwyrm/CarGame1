using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// by Tyson

public class LapUpdate : MonoBehaviour
{
    // reference to the text component
    private Text m_text;
    // reference to the player's checkpoint script
    public PlayerCheckpoints m_player;

    private void Awake()
    {
        // gets the text component
        m_text = GetComponent<Text>();
    }

    private void Update()
    {
        // updates the text to the lap count
        m_text.text = "Lap: " + m_player.m_iLaps + " ";
    }
}