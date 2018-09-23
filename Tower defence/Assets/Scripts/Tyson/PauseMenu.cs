using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
// by Tyson

public class PauseMenu : MonoBehaviour
{
    // reference to the return button
    public Button m_returnButton;
    // reference to the menu button
    public Button m_menuButton;
    // reference to the pause game script
    public PauseGame m_return;
    // reference to the return to menu script
    public ReturnToMenu m_menu;

    // stores the normal colour of the button
    private Color m_normal;
    // stores the highlighted colour of the button
    private Color m_selected;
    // the amount required to surpass before an input is accepted
    private float m_fDeadZone = 0.9f;
    // used to delay movement between options
    private float m_fCoolDown = 0.3f;
    // used to reset the cool down
    private float m_fCDCopy = 0.3f;
    // refers to a button
    private int m_iButtonIndex = 1;

    private void Start()
    {
        // sets the normal colour to white
        m_normal = Color.white;
        // sets the selected colour to grey
        m_selected = Color.gray;
        // sets the return button colour to selected
        m_returnButton.image.color = m_selected;
    }

    // by Tim
    // edited by Tyson

    private void Update()
    {
        // decrements the cool down
        m_fCoolDown -= Time.deltaTime;
        // input from the vertical axis
        float fVertical = Input.GetAxis("VerticalP1");
        // input from the submit axis
        float fSubmit = Input.GetAxisRaw("Submit");

        // checks if any input is given
        if (fVertical == 0.0f && fSubmit == 0.0f)
        {
            return;
        }

        // button selection based on the current index
        switch (m_iButtonIndex)
        {
            // return button currently selected
            case 1:
                // checks if an input greater than the dead zone is given and the cool down has finished
                if (Mathf.Abs(fVertical) > m_fDeadZone && m_fCoolDown < 0.0f)
                {
                    m_iButtonIndex = 2;
                    m_fCoolDown = m_fCDCopy;

                    // sets the menu button colour to selected
                    m_menuButton.image.color = m_selected;
                    // sets the return button colour to normal
                    m_returnButton.image.color = m_normal;
                }
                else
                {
                    // ensures that the return button colour is the selected colour
                    m_returnButton.image.color = m_selected;
                    // ensures that the menu button colour is the normal colour
                    m_menuButton.image.color = m_normal;
                }
                // checks if a submit input was given
                if (fSubmit != 0.0f)
                {
                    // returns to the game
                    m_return.ReturnToGame();
                    // sets the pause menu to inactive
                    gameObject.SetActive(false);
                }
                break;
            // menu button currently selected
            case 2:
                // checks if an input greater than the dead zone is given and the cool down has finished
                if (Mathf.Abs(fVertical) > m_fDeadZone && m_fCoolDown < 0.0f)
                {
                    m_iButtonIndex = 1;
                    m_fCoolDown = m_fCDCopy;

                    // sets the return button colour to selected
                    m_returnButton.image.color = m_selected;
                    // sets the menu button colour to normal
                    m_menuButton.image.color = m_normal;
                }
                else
                {
                    // ensures that the menu button colour is the selected colour
                    m_menuButton.image.color = m_selected;
                    // ensures that the return button colour is the normal colour
                    m_returnButton.image.color = m_normal;
                }
                // checks if a submit input was given
                if (fSubmit != 0.0f)
                {
                    // returns to the menu
                    m_menu.Menu();
                }
                break;
            default:
                break;
        }
    }
}