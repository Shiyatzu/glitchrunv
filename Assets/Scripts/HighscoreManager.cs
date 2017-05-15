using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour {
    Text text;
    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        text.text = ": " + PlayerPrefs.GetInt("Highscore");
    }
}
