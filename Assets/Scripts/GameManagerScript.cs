using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject VrStart;
    [SerializeField]
    private GameObject MainMenuButtons;
    [SerializeField]
    private GameObject LeaderboardButtons;
    [SerializeField]
    private GameObject GameOverScreen;

    public PlayerController playercontroller;
    
    public int currentScore;
    private float startTime;
    //Vr variables
    private bool isVr = false;
    [SerializeField]
    private string targetVrDevice;

    void Awake() {
        PlayerPrefs.DeleteAll();
        playercontroller.enabled = false;
    }
    
    void Update() {
        currentScore = (int)CalculateScore();
    }

    public void MenuSwitch() {
        MainMenu.SetActive(false);
        Gamestart();
    }

    public void VrSwitch() {
        MainMenu.SetActive(false);
        VrStartStart();
    }

    private void VrStartStart() {
        VrStart.SetActive(true);
        Invoke("VrStartEnd", 5f);
    }

    private void VrStartEnd() {
        VrStart.SetActive(false);
        isVr = true;
        VROn();
        Gamestart();
    }

    public void Leaderbord() {
        MainMenuButtons.SetActive(false);
        LeaderboardButtons.SetActive(true);
    }

    public void BackToMenu() {
        playercontroller.enabled = false;
        LeaderboardButtons.SetActive(false);
        MainMenu.SetActive(true);
        MainMenuButtons.SetActive(true);
    }

    public void Gamestart() {
        startTime = Time.time;
        playercontroller.enabled = true;
        GameOverScreen.SetActive(false);
        startTime = Time.time;
    }

    public void Gameover() {
        //Check score and reposition player
        if (currentScore > PlayerPrefs.GetInt("Highscore"))
            PlayerPrefs.SetInt("Highscore", currentScore);
        playercontroller.transform.position = new Vector3(0, 5, 65);
        playercontroller.transform.localRotation = new Quaternion(0, 0, 0, 0);

        //ShowGameOverScreen();
        Gamestart();
    }

    private float CalculateScore() {
        return (Time.time - startTime)*10;
    }

    private void ShowGameOverScreen() {
        GameOverScreen.SetActive(true);
    }

    private void VROn() {
        StartCoroutine(LoadDevice(targetVrDevice));
    }

    private void VROff() {
        StartCoroutine(UnloadDevice(string.Empty));
    }

    IEnumerator LoadDevice(string newDevice) {
        VRSettings.LoadDeviceByName(newDevice);
        yield return null;
        VRSettings.enabled = true;
    }

    IEnumerator UnloadDevice(string newDevice) {
        VRSettings.LoadDeviceByName(newDevice);
        yield return null;
        VRSettings.enabled = false;
    }

}
