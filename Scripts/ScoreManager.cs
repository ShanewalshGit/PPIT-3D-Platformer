using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI InputScore;
    [SerializeField] private TMP_InputField InputName;
    public UnityEvent<String, int> submitScoreEvent;

    // Start is called before the first frame update
    void Start()
    {
        if(FindAnyObjectByType<SessionController> () == null) { // If the SessionController object is not found, log an error
            Debug.Log("SessionController not found");
            Debug.Log("Final health = "+ InputScore.text);
        } else { // If the SessionController object is found, set the final health to the current health
            InputScore.text = FindAnyObjectByType<SessionController>().GetHealth().ToString();
            Debug.Log("Final health = " + InputScore.text);

            // Destroy the SessionController object
            //Destroy(FindAnyObjectByType<SessionController>().gameObject);
        }
    }

    // Submit the score to the leaderboard
    public void SubmitScore() {
        submitScoreEvent.Invoke(InputName.text, Int32.Parse(InputScore.text));
    }
}
