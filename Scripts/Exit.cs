using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                Debug.Log("You win!");
                SceneManager.LoadScene(0);
            }
            else {
                Debug.Log("You win!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
