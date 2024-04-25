using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    // Progress bar variables
    public int maximum;
    public int current;
    public UnityEngine.UI.Image mask; // Image mask to show progress

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    public void GetCurrentFill() // Get current fill amount of the progress bar
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    public void SetCurrent(int current) // Set current progress of the bar
    {
        if (current <= maximum)
        {
            this.current = current;
        }
        else
        {
            this.current = maximum;
        }
        GetCurrentFill();
    }
}
