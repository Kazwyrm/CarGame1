using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// by Sam

public class MainMenu : MonoBehaviour {

    // by Tyson
    public GameObject m_controlsCanvas;
    public GameObject m_panelCanvas;
    public Button m_playButton;
    public Button m_controlsButton;
    public Button m_quitButton;
    public Button m_backButton;

    private Color m_normal;
    private Color m_selected;

    // by Tim
    private float deadZone = 0.9f;
    private float coolDown = 0.3f;
    private float cDCopy = 0.3f;
    private int buttonIndex = 1;

    private void Start()
    {
        m_normal = new Color(255.0f, 75.0f, 75.0f);
        m_selected = Color.red;
        m_playButton.image.color = m_selected;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        coolDown -= Time.deltaTime;
        float vertical = Input.GetAxis("VerticalP1");
        float submit = Input.GetAxisRaw("Submit");

        switch (buttonIndex)
        {
            case 1:
                if (vertical > deadZone && coolDown < 0.0f)
                {
                    buttonIndex = 3;
                    coolDown = cDCopy;

                    m_quitButton.image.color = m_selected;
                    m_playButton.image.color = m_normal;
                }
                else if (vertical < -deadZone && coolDown < 0.0f)
                {
                    buttonIndex = 2;
                    coolDown = cDCopy;

                    m_controlsButton.image.color = m_selected;
                    m_playButton.image.color = m_normal;
                }
                if (submit != 0.0f)
                {
                    PlayGame();
                }
                break;
            case 2:
                if (vertical > deadZone && coolDown < 0.0f)
                {
                    buttonIndex = 1;
                    coolDown = cDCopy;

                    m_playButton.image.color = m_selected;
                    m_controlsButton.image.color = m_normal;
                }
                else if (vertical < -deadZone && coolDown < 0.0f)
                {
                    buttonIndex = 3;
                    coolDown = cDCopy;

                    m_quitButton.image.color = m_selected;
                    m_controlsButton.image.color = m_normal;
                }
                if (submit != 0.0f && coolDown < 0.0f)
                {
                    m_controlsCanvas.SetActive(true);
                    m_panelCanvas.SetActive(false);
                    buttonIndex = 4;
                    coolDown = cDCopy;
                }
                break;
            case 3:
                if (vertical > deadZone && coolDown < 0.0f)
                {
                    buttonIndex = 2;
                    coolDown = cDCopy;

                    m_controlsButton.image.color = m_selected;
                    m_quitButton.image.color = m_normal;
                }
                else if (vertical < -deadZone && coolDown < 0.0f)
                {
                    buttonIndex = 1;
                    coolDown = cDCopy;

                    m_playButton.image.color = m_selected;
                    m_quitButton.image.color = m_normal;
                }
                if (submit != 0.0f)
                {
                    QuitGame();
                }
                break;
            case 4:
                if (submit != 0.0f && coolDown < 0.0f)
                {
                    m_controlsCanvas.SetActive(false);
                    m_panelCanvas.SetActive(true);
                    buttonIndex = 2;
                    coolDown = cDCopy;
                }
                break;
            default:
                break;
        }
    }
}