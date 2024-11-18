using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [Header ("Menu Options")]
    public GameObject mainMenu;
    public GameObject subMenu;
    public GameObject betaGUI;
    public GameObject creditsMenu;
    public GameObject titleText;
    [Header ("Settings Manager")]
    public GameObject audioGUI;
    public GameObject displayGUI;
    public GameObject settingsGUI;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    [Header ("Scene Options")]
    public string baseSceneName = "Scene1";
    public GameObject prequelsDLCButton;
    public GameObject sequelsDLCButton;
    public string prequelsSceneName = "PrequelsDLC";
    public string sequelsSceneName = "SequelsDLC";
    [Header ("Scene Preview")]
    public GameObject level1Cam;
    public GameObject level2Cam;
    public GameObject level3Cam;
    public saveSystem SaveSystem;
    Resolution[] resolutions;

	// Use this for initialization
    void Start() {
        if(SaveSystem.sceneID == 0) {
            level1Cam.gameObject.SetActive(true);
            level2Cam.gameObject.SetActive(false);
            level3Cam.gameObject.SetActive(false);
        }

        if(SaveSystem.sceneID == 1) {
            level1Cam.gameObject.SetActive(false);
            level2Cam.gameObject.SetActive(true);
            level3Cam.gameObject.SetActive(false);
        }

        if(SaveSystem.sceneID == 2) {
            level1Cam.gameObject.SetActive(false);
            level2Cam.gameObject.SetActive(false);
            level3Cam.gameObject.SetActive(true);
        }
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i ++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void openSubMenu() {
        mainMenu.gameObject.SetActive(false);
        creditsMenu.gameObject.SetActive(false);
        subMenu.gameObject.SetActive(true);
    }

    public void backToMain() {
        mainMenu.gameObject.SetActive(true);
        creditsMenu.gameObject.SetActive(false);
        subMenu.gameObject.SetActive(false);
    }

    public void openCredits() {
        creditsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        subMenu.gameObject.SetActive(false);
    }

    public void agreeTerms() {
        mainMenu.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
        betaGUI.gameObject.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startBaseGame()
    {
        SceneManager.LoadScene(baseSceneName);
        Time.timeScale = 1;
    }

    public void startPrequelsDLC() {
        SceneManager.LoadScene(prequelsSceneName);
        Time.timeScale = 1;
    }

    public void startSequelsDLC() {
        SceneManager.LoadScene(sequelsSceneName);
        Time.timeScale = 1;
    }

    public void settings() {
        Debug.Log("Opened Settings");
        mainMenu.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        settingsGUI.gameObject.SetActive(true);
        displayGUI.gameObject.SetActive(true);
    }

    public void audioSettings() {
        Debug.Log("Opened Audio Settings");
        displayGUI.gameObject.SetActive(false);
        audioGUI.gameObject.SetActive(true);
    }

    public void SetMasterVolume(float volume) {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetEffectsVolume(float volume) {
        audioMixer.SetFloat("EffectsVolume", volume);
    }

    public void SetVoiceVolume(float volume) {
        audioMixer.SetFloat("VoicesVolume", volume);
    }

    public void SetQuality( int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen( bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void displaySettings() {
        Debug.Log("Opened Display Settings");
        displayGUI.gameObject.SetActive(true);
        audioGUI.gameObject.SetActive(false);
    }

    public void closeSettings() {
        Debug.Log("Closed Settings");
        mainMenu.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
        settingsGUI.gameObject.SetActive(false);
        displayGUI.gameObject.SetActive(true);
        audioGUI.gameObject.SetActive(false);
    }
} 