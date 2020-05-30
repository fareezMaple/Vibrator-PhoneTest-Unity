using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject warningPredefinedPanel;
    public GameObject warningAmplitudePanel;
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("exited game");
    }

    public void showAndHideInfoPanel()
    {
        bool isOpen = InfoPanel.activeSelf;

        if (!isOpen) //if not open
        {
            InfoPanel.SetActive(true);
        } else
        {
            InfoPanel.SetActive(false);
        }
    }

    public void ShowingAd()
    {
        AdController.instance.showVideoAd();
    }

    public void ViewThreadSource()
    {
        //open web browser view github
        Application.OpenURL("https://gist.github.com/ruzrobert/d98220a3b7f71ccc90403e041967c46b"); //updated one
    }

    public void OpenSupportEmail()
    {
        //open email
        Application.OpenURL("mailto:foxtrotiqmal3@gmail.com");
    }

    public void ignoreWarning()
    {
        warningPredefinedPanel.SetActive(false);
    }

    public void ignoreWarningAmplitude()
    {
        warningAmplitudePanel.SetActive(false);
    }
}
