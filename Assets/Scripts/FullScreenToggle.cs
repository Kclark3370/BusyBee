using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScreenModeManager : MonoBehaviour
{
    public TMP_Dropdown dropdown; 

    void Start()
    {
        List<string> options = new List<string> { "Fullscreen", "Windowed" };
        dropdown.ClearOptions();
        dropdown.AddOptions(options);

        dropdown.onValueChanged.AddListener(SetScreenMode);
    }

    public void SetScreenMode(int index)
    {
        switch (index)
        {

            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
        }
    }
}