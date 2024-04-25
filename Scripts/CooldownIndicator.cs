using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownIndicator : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image FilledCooldownIcon;
    [SerializeField] private UnityEngine.UI.Image EmptyCooldownIcon;
    // Start is called before the first frame update
    void Start()
    {
        FilledCooldownIcon.enabled = true;
    }

    public void UpdateCooldownIcons(float currentCooldown, float maxCooldown)
    {
        if(currentCooldown < maxCooldown)
        {
            Debug.Log("Current cooldown: " + currentCooldown);
            // Hide the icons that are not needed
            FilledCooldownIcon.enabled = false;

            // Show the icons that are needed
            EmptyCooldownIcon.enabled = true;
        }
        else {
            FilledCooldownIcon.enabled = true;
            EmptyCooldownIcon.enabled = false;
        }
    }
}
