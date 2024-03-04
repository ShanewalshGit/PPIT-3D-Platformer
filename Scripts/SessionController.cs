using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SessionController : MonoBehaviour
{
    [SerializeField] int points = 0;
    [SerializeField] int lives = 3;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = points.ToString();
        livesText.text = lives.ToString();
    }

    public void RemoveLife()
    {
        lives--;
        Debug.Log("Lives: " + lives);
        livesText.text = lives.ToString();
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        Debug.Log("Points: " + points);
        scoreText.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0)
        {
            Debug.Log("Game Over");
            ResetGameSession();
        }

        // If the player presses the "R" key, reload the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    private void Awake()
    {
        int numSessionControllers = FindObjectsOfType<SessionController>().Length;
        if (numSessionControllers> 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
