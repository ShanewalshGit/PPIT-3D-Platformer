using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using MimicSpace;
using UnityEngine.Events;
using System;

public class SessionController : MonoBehaviour
{

    // Variables for player lives, health and parts
    [SerializeField] int lives = 3;
    [SerializeField] int health = 0;
    public int finalHealth = 0;
    public int partsNeeded = 3;
    public int parts = 0;

    // UI elements for lives and health
    //[SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI partsText;

    public Boolean exitTriggered = false; // Boolean to check if the exit has been triggered

    GameObject mimicBody; // Mimic's body reference

    public static SessionController instance = null; // Singleton pattern for the session controller

    
    private void Awake() // Singleton pattern for the session controller
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        // Set leaderboard to inactive
        GameObject leaderboard = GameObject.Find("Leaderboard");
        GameObject leaderboardManager = GameObject.Find("LeaderboardManager");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //livesText.text = lives.ToString();
        //healthText.text = health.ToString();
        partsText.text = parts + "/" + partsNeeded;

        // Set the progress bar to the current health
        FindAnyObjectByType<ProgressBar>().SetCurrent(health);
    }

    //On hit, reduce health and reduce scale of player object
    public void ReduceHealth(int damage)
    {
        health -= damage;
        //healthText.text = health.ToString();

        // Subtract from progress bar
        FindAnyObjectByType<ProgressBar>().SetCurrent(health);

        // Get the mimicbody
        mimicBody = GameObject.Find("Sphere");

        // Get the mimicbody current scale
        Vector3 currentScale = mimicBody.transform.localScale;

        // Decrease the scale by a certain factor
        float scaleReductionFactor = 0.4f; // Change this to whatever factor you want
        Vector3 newScale = currentScale * (1 - scaleReductionFactor);

        // decrease the collider size
        mimicBody.GetComponent<SphereCollider>().radius -= 0.4f;

        //Play player hurt sound
        FindObjectOfType<AudioManager>().PlayPlayerHurt();

        // Set the mimics new scale
        mimicBody.transform.localScale = newScale;
        if (health < 10)
        {
            RemoveLife(); // Remove a life
        }
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;
        //healthText.text = health.ToString();

        // Add to progress bar
        FindAnyObjectByType<ProgressBar>().SetCurrent(health);

        // Get the mimicbody
        mimicBody = GameObject.Find("Sphere");

        // Get the mimics's current scale
        Vector3 currentScale = mimicBody.transform.localScale;

        // Increase the scale by a certain factor
        float scaleIncreaseFactor = 0.1f; // Change this to whatever factor you want
        Vector3 newScale = currentScale * (1 + scaleIncreaseFactor);

        // Set the mimics new scale
        mimicBody.transform.localScale = newScale;

        // Increase the collider size
        mimicBody.GetComponent<SphereCollider>().radius += 0.1f;
    }

    public void RemoveLife()
    {
        lives--;
        //Debug.Log("Lives: " + lives);
        //livesText.text = lives.ToString();
        FindAnyObjectByType<LivesContainer>().UpdateIcons(lives);

        // Play the player death sound
        FindObjectOfType<AudioManager>().PlayPlayerDeath();

        // Reload the scene if the player loses a life
        if(lives >= 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            health = 0; // Reset the player's health
            //healthText.text = health.ToString();

            parts = 0; // Reset the parts collected
            partsText.text = parts + "/" + partsNeeded;

            // Reset the progress bar
            FindAnyObjectByType<ProgressBar>().SetCurrent(health);

            // Get the mimicbody
            mimicBody = GameObject.Find("Sphere");

            mimicBody.transform.localScale = new Vector3(1, 1, 1); // Reset the player's scale
            mimicBody.GetComponent<SphereCollider>().radius = 0.5f; // Reset the collider size
        }
    }

    public void AddPart()
    {
        parts++;
        partsText.text = parts + "/" + partsNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has no more lives, reset the game
        if(lives == 0)
        {
            Debug.Log("Game Over");

            // Play the game over sound
            FindObjectOfType<AudioManager>().PlayGameOver();

            // Set the final health
            finalHealth = health;

            // Load the game over scene
            SceneManager.LoadSceneAsync(4);
        }
        if(exitTriggered == true && parts == partsNeeded)
        {
            // if current scene is scene 3, load scene 5
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                Debug.Log("You Win");

                // Play the game win sound
                FindObjectOfType<AudioManager>().PlayGameWin();

                // Set the final health
                finalHealth = health;
                // Load the game win scene
                SceneManager.LoadSceneAsync(5);            
            }
            else {
                // load next scene
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

                // Reset the player's health and scale
                health = 0;
                //healthText.text = health.ToString();

                parts = 0;
                partsText.text = parts + "/" + partsNeeded;

                // Reset the progress bar
                FindAnyObjectByType<ProgressBar>().SetCurrent(health);

                // Get the mimicbody
                mimicBody = GameObject.Find("Sphere");
                mimicBody.GetComponent<SphereCollider>().radius = 0.5f; // Reset the collider size
            }

        }
        else
        {
            Debug.Log("Not enough parts collected");
            exitTriggered = false;
        }

        // If the player presses the "R" key, reload the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

            // Reset the player's health and scale
            health = 0;
            //healthText.text = health.ToString();

            parts = 0;
            partsText.text = parts + "/" + partsNeeded;

            // Reset the progress bar
            FindAnyObjectByType<ProgressBar>().SetCurrent(health);

            // Get the mimicbody
            mimicBody = GameObject.Find("Sphere");
            
            // Reset the mimicbody's scale
            mimicBody.transform.localScale = new Vector3(1, 1, 1);

            // Reset the collider size
            mimicBody.GetComponent<SphereCollider>().radius = 0.5f;

            // Reset the player's lives
            lives = 3;
            //livesText.text = lives.ToString();
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            // Kill the player
            RemoveLife();
        }
    }

    public void ResetGameSession()
    {
        SceneManager.LoadSceneAsync(0);
        Destroy(gameObject);

        Cursor.visible = true; // Make the cursor visible
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor if it was locked
    }

    public int GetHealth()
    {
        return finalHealth;
    }

    public int GetLives()
    {
        return lives;
    }

    public void setLives(int newLives)
    {
        lives = newLives;
    }

    public void SetExit()
    {
        exitTriggered = true;
    }
    
}
