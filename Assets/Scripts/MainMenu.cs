using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pivotPoint; //For camera
    public float rotationSpeed;
    public float creditsSpeed;

    bool isCreditsWindowOpen;

    public Scene mainMenuScene;
    public GameObject confirmationWindow;
    public GameObject creditsWindow;
    public GameObject backCreditsButton;
    public GameObject settingsWindow;
    public GameObject buttonsInMenu;
    
    Vector3 creditsStartPos = new Vector3();
    void Start()
    {
        creditsStartPos = new Vector3(creditsWindow.transform.position.x, creditsWindow.transform.position.y, creditsWindow.transform.position.z);
        buttonsInMenu.active = true;
        settingsWindow.active = false;
        creditsWindow.active = false;
        backCreditsButton.active = false;
        isCreditsWindowOpen = false;
        confirmationWindow.active = false;
        mainMenuScene = SceneManager.GetActiveScene();
        pivotPoint.transform.rotation = new Quaternion(0, 0, 0, 0);
    }


    void Update()
    {
        OnLoadMenuScene();
    }

    public void OnLoadMenuScene()
    {
        if (mainMenuScene.name.Equals("MainMenu"))
        {
            pivotPoint.transform.Rotate(Vector3.down * rotationSpeed);
        }
        
        if(isCreditsWindowOpen)
        {
            creditsWindow.transform.position += new Vector3(0, creditsSpeed, 0);
        }
    }


    //Buttons 
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Settings()
    {
        buttonsInMenu.active = false;
        settingsWindow.active = true;
    }

    public void Credits()
    {
        buttonsInMenu.active = false;
        backCreditsButton.active = true;
        creditsWindow.active = true;
        isCreditsWindowOpen = true;
    }

    public void QuitGame()
    {
        confirmationWindow.active = true;
    }
    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        confirmationWindow.active = false;
    }
    
    public void Back()
    {
        buttonsInMenu.active = true;
        settingsWindow.active = false;
        creditsWindow.active = false;
        backCreditsButton.active = false;
        isCreditsWindowOpen = false;
        creditsWindow.transform.position = new Vector3(creditsStartPos.x, creditsStartPos.y, creditsStartPos.z);
    }
    
    
}
