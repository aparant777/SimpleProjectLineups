using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public AudioSource aud; 

    private void Start() {
        aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);      
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            aud.Play();
        }
    }
}
