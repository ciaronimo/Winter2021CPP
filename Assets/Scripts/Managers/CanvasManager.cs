using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button quitToMenuButton;
    public Button returnToGameButton;
    public Button backButton;
    public Button settingsButton;

    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    [Header("Text")]
    public Text livesText;
    public Text volText;
    public Text muteText;

    [Header("Slider")]
    public Slider volSlider;
    public Toggle mute;

    [Header("Sprites")]
    public Image heart1;
    public Image heart2;
    public Image heart3;




    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());
        }

        if (quitButton)
        {
            quitButton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }

        if (returnToGameButton)
        {
            returnToGameButton.onClick.AddListener(() => ReturnToGame());
        }

        if (quitToMenuButton)
        {
            quitToMenuButton.onClick.AddListener(() => GameManager.instance.QuitToMenu());
        }

        if (backButton)
        {
            backButton.onClick.AddListener(() => ShowMainMenu());
        }

        if (settingsButton)
        {
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                Time.timeScale = 0;

            }
        }

        if (livesText)
        {
            livesText.text = GameManager.instance.score.ToString();
        }

        if (settingsMenu)
        {
            if (settingsMenu.activeSelf)
            {
                if (mute.isOn)
                {
                    volSlider.value = 0;
                    muteText.text = "Unmute";
                    volText.text = Mathf.Round(volSlider.value).ToString();
                }
                else
                {
                    muteText.text = "Mute";
                    volText.text = Mathf.Round(volSlider.value).ToString();
                }

               
            }
        }

        switch (GameManager.instance.lives)
        {
            case 3:
                Debug.Log("heart 3");
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                break;
            case 2:
                heart3.enabled = false;
                break;
            case 1:
                heart2.enabled = false;
                break;
            case 0:
                heart1.enabled = false;
                break;

        }




    }

    public void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
