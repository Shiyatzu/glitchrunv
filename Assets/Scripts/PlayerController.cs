using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    void Start() {
        PlayerPrefs.SetInt("Highscore", 0);
    }
    void FixedUpdate() {
        float tilt = Input.acceleration.x;
        transform.Rotate(0, 0, -tilt * Time.deltaTime * speed);
        transform.Translate(tilt * speed * Time.deltaTime, 0, 0,Space.World);
    }
}
