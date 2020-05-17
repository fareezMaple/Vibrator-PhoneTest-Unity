using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject warningPredefinedPanel;
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
        Application.OpenURL("https://gist.github.com/aVolpe/707c8cf46b1bb8dfb363");
    }

    public void ignoreWarning()
    {
        warningPredefinedPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
