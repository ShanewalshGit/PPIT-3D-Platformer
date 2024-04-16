using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class LivesContainer : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image[] FilledLivesIcons;
    [SerializeField] private UnityEngine.UI.Image[] EmptyLivesIcons;


    int maxLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        UpdateIcons(FindAnyObjectByType<SessionController>().GetLives());

        // disable all the empty lives icons
        for(int i = 0; i < maxLives; i++)
        {
            EmptyLivesIcons[i].enabled = false;
        }
    }

    public void UpdateIcons(int currentLives)
    {
        if(currentLives < maxLives)
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
