using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGame() // Start the game from main menu
    {
        // Play audio
        FindObjectOfType<AudioManager>().PlayButtonClick();
        // Load the next scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() // Imitate quitting the game, unity editor will not quit
    {
        // Play audio
        FindObjectOfType<AudioManager>().PlayButtonClick();
        
        // Quit the game
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
