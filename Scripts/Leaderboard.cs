using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    // UI elements
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    // Leaderboard access keys
    //private String publicLeaderboardkey = "d02b838fb6169e024daaeea1a3d9a5837affbf63fc4dd1812b6cd63a2e7ccb27";
    private String publicLeaderboardkey = "07d92f5e68c0c8a86fe32ab69b187c984000d659f67998d766edb4006c6ff89a";
    // Start is called before the first frame update
    void Start()
    {
        GetLeaderboard();

        // Set cursor to visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GetLeaderboard() // Get the leaderboard from the server
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardkey, ((msg) => { 
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count; // Get the minimum of the two
            for (int i = 0; i < loopLength; ++i) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(String username, int score) // Set the leaderboard entry on the server with given username and score
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardkey, username, score, ((msg) => {
            GetLeaderboard();
        }));
    }
}
