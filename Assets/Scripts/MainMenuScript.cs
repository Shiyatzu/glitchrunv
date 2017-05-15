using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
    private GameManagerScript myGameManager;
	// Use this for initialization
   
	void Start () {
        myGameManager = GameObject.Find("GameManager").GetComponent <GameManagerScript> ();
    }
	
	// Update is called once per frame
	void Update () {
	}
    public void MenuSwitch() {
        myGameManager.MenuSwitch();
    }
    public void VrSwitch() {
        myGameManager.VrSwitch();
    }
}
