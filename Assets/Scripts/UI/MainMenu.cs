using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
  public string mainMenuScene = "MainMenu";
  public string gameScene = "Game";
  public GameObject transitionFadeObject;

  public AudioMixer audioMixer;

  public RenderPipelineAsset[] qualityLevels;
  public TMP_Dropdown dropdownQuality;
  public TMP_Dropdown dropdownResolution;
  public Toggle toggleFullScreen;
  public Slider sliderVolume;
  Resolution[] resolutions;

  void Start() {
    //Sets the quality
    dropdownQuality.value = QualitySettings.GetQualityLevel();

    //Creates the resolutions and reads the native resolution of the player
    resolutions = Screen.resolutions;
    dropdownResolution.ClearOptions();
    List<string> optionsRes = new List<string>();
    int currentResolutionIndex = 0;
    for (int i = 0; i < resolutions.Length; i++) {
      string option = resolutions[i].width +  " X " + resolutions[i].height;
      optionsRes.Add(option);
      if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
        currentResolutionIndex = i;
      }
    }
    dropdownResolution.AddOptions(optionsRes);
    dropdownResolution.value = currentResolutionIndex;
    dropdownResolution.RefreshShownValue();

  }

  public void ContinueGame() {
    //SceneManager.LoadScene(gameScene, LoadSceneMode.Additive);
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(gameScene));
  }

  public void PlayGame() {

    StartCoroutine(LoadAsyncScene());

  }
  IEnumerator LoadAsyncScene() {
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameScene);

    transitionFadeObject.SetActive(true);
    while (!asyncLoad.isDone) {
      yield return null;
    }

    SceneManager.SetActiveScene(SceneManager.GetSceneByName(gameScene));

  }

  public void QuitGame() {
    Application.Quit();
  }

  public void ChangeQuality() {
    QualitySettings.SetQualityLevel(dropdownQuality.value);
  }

  public void SetVolume () {
    audioMixer.SetFloat("volume",sliderVolume.value);
  }

  public void SetFullScreen () {
    Screen.fullScreen = toggleFullScreen.isOn;
    if (toggleFullScreen.isOn) {
       Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }else {
      Screen.fullScreenMode = FullScreenMode.Windowed;
    }
    Debug.Log("fullscreen "+Screen.fullScreenMode+", Toggle "+toggleFullScreen.isOn);
  }

  public void SetResolution() {
    Resolution resolution = resolutions[dropdownResolution.value];
    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
  }
}
