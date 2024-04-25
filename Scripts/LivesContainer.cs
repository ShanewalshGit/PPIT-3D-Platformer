using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class LivesContainer : MonoBehaviour
{
    // UI elements for lives
    [SerializeField] private UnityEngine.UI.Image[] FilledLivesIcons;
    [SerializeField] private UnityEngine.UI.Image[] EmptyLivesIcons;

    int maxLives = 3; // Maximum number of lives

    // Start is called before the first frame update
    void Start()
    {
        // Update icons to show the current number of lives
        UpdateIcons(FindAnyObjectByType<SessionController>().GetLives());

        // disable all the empty lives icons
        for(int i = 0; i < maxLives; i++)
        {
            EmptyLivesIcons[i].enabled = false;
        }
    }

    public void UpdateIcons(int currentLives)
    {
        if(currentLives < maxLives) // If current lives are less than the maximum lives, update the icons
        {
            Debug.Log("Current lives: " + currentLives);
            // Hide the icons that are not needed
            for(int i = currentLives; i < maxLives; i++)
            {
                FilledLivesIcons[i].sprite = EmptyLivesIcons[i].sprite;
            }
        }
    }
}
