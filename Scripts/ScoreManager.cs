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
        if(FindAnyObjectByType<SessionController> () == null) {
            Debug.Log("SessionController not found");
            InputScore.text = "0";
        } else {
            InputScore.text = FindAnyObjectByType<SessionController>().finalHealth.ToString();

            // Destroy the SessionController object
            Destroy(FindAnyObjectByType<SessionController>().gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitScore() {
        submitScoreEvent.Invoke(InputName.text, Int32.Parse(InputScore.text));
    }
}
