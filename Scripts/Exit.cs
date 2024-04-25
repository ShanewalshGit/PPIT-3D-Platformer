using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") // If player reaches the exit, play win sound and set exit triggered to true
        {
            // play win sound
            FindObjectOfType<AudioManager>().PlayGameWin();

            // Set exit triggered to true
            FindAnyObjectByType<SessionController>().SetExit();
        }
    }
}
