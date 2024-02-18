using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    float playerMovementSensitivity;
    public Slider playerMovementSensitivitySlider;

    private void Awake()
    {
        runningGameForTheFirstTime();
        playerMovementSensitivity = PlayerPrefs.GetFloat(CommonConstants.playerMovementSensitivity);
        playerMovementSensitivitySlider.value = playerMovementSensitivity;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void changePlayerSensitivity(float value)
    {
        playerMovementSensitivity = value;
    }

    public void saveSettings()
    {
        PlayerPrefs.SetFloat(CommonConstants.playerMovementSensitivity, playerMovementSensitivity);
    }

    void runningGameForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey(CommonConstants.playerMovementSensitivity))
        {
            PlayerPrefs.SetFloat(CommonConstants.playerMovementSensitivity, 7.5f);
        }
        Debug.Log("PlayerPrefs.GetFloat(CommonConstants.playerMovementSensitivity):" + PlayerPrefs.GetFloat(CommonConstants.playerMovementSensitivity));
    }
}
