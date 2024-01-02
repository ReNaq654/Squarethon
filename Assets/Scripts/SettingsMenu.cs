using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions; //Create array for resolutions

    public TMPro.TMP_Dropdown resolutionDropdown;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions(); //Clears out options in resolutionDropdown

        List<string> options = new List<string>(); //List of strings that will be options

        int currentResolutionIndex = 0; //int to help check resolution

        for (int i = 0; i < resolutions.Length; i++) //Loop through each element in resolutions array
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //Creates string that will be resolution.
            options.Add(option); //Adds resolutions to options list

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) //Comparing resolution width and height
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); //Adds options list  to the Resolution dropdown in game

        resolutionDropdown.value = currentResolutionIndex; 
        resolutionDropdown.RefreshShownValue(); //Refreshs value to display correct resolution
    }


    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
