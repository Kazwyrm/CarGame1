using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Tyson

public class PlayerCheckpoints : MonoBehaviour
{
    // stores a reference to all the checkpoint triggers
    public Collider[] m_checkpoints;

    // the next checkpoint
    private int m_iNextCheckpoint = 0;
    [HideInInspector]
    // counts the laps
    public int m_iLaps = 0;

    // checks if the object being collided with is the next checkpoint
    private void OnTriggerEnter(Collider other)
    {
        // checks if the collider is the next checkpoint
        if (m_checkpoints[m_iNextCheckpoint] == other)
        {
            // increments the checkpoint
            switch (m_iNextCheckpoint)
            {
                case 0:
                    // increments the total laps
                    m_iLaps++;
                    m_iNextCheckpoint = 1;
                    break;
                case 1:
                    m_iNextCheckpoint = 2;
                    break;
                case 2:
                    m_iNextCheckpoint = 3;
                    break;
                case 3:
                    m_iNextCheckpoint = 4;
                    break;
                case 4:
                    m_iNextCheckpoint = 5;
                    break;
                case 5:
                    m_iNextCheckpoint = 6;
                    break;
                case 6:
                    m_iNextCheckpoint = 7;
                    break;
                case 7:
                    m_iNextCheckpoint = 8;
                    break;
                case 8:
                    m_iNextCheckpoint = 9;
                    break;
                case 9:
                    m_iNextCheckpoint = 0;
                    break;
            }
        }
    }
}