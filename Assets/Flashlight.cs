using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public float brightness = 1f;
    static bool on = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Flashlight")) {
            toggleLight();
        }
    }

    void toggleLight() {
        if (on) {
            gameObject.GetComponent<Light>().intensity = 0;
            on = false;
        } else {
            gameObject.GetComponent<Light>().intensity = brightness;
            on = true;
        }
    }
}
