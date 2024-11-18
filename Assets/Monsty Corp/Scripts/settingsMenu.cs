using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DialogueEditor;

public class settingsMenu : MonoBehaviour {

    [Header ("Pause Manager") ]
    public GameObject pauseCanvas;
    public GameObject minimap;

    [Header ("Settings Manager")]
    public GameObject audioGUI;
    public GameObject displayGUI;
    public GameObject settingsGUI;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start() {
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
    }

    public void settings() {
        Debug.Log("Opened Settings");
        pauseCanvas.gameObject.SetActive(false);
        minimap.gameObject.SetActive(false);
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
        pauseCanvas.gameObject.SetActive(true);
        settingsGUI.gameObject.SetActive(false);
        displayGUI.gameObject.SetActive(true);
        audioGUI.gameObject.SetActive(false);
    }
}