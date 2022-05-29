using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlScreen : MonoBehaviour
{
    private Resolution[] resolutionAvaliable;
    public TMP_Dropdown dropDownList;
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        controlScreenSize();
    }

    public void controlFullScreen(bool toggleIsOn)
    {
        Screen.fullScreen = toggleIsOn;
    }

    public void controlScreenSize()
    {
        resolutionAvaliable = Screen.resolutions;
        dropDownList.ClearOptions();
        List<string> options = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < resolutionAvaliable.Length; i++)
        {
            string option = resolutionAvaliable[i].width + " x " + resolutionAvaliable[i].height + " " +
                            resolutionAvaliable[i].refreshRate + "Hz";
            options.Add(option);

            if (Screen.fullScreen && resolutionAvaliable[i].width == Screen.currentResolution.width &&
                resolutionAvaliable[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }

        dropDownList.AddOptions(options);
        dropDownList.value = actualResolution;
        dropDownList.RefreshShownValue();
        dropDownList.value = PlayerPrefs.GetInt("numberResolution", 0);
    }

    public void changeResolution(int indexdOptionDropDown)
    {
        PlayerPrefs.SetInt("numberResolution", dropDownList.value);
        Resolution resolution = resolutionAvaliable[indexdOptionDropDown];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}