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

    private Scene mainMenuScene;
    [SerializeField] private GameObject confirmationWindow;
    [SerializeField] private GameObject creditsWindow;
    [SerializeField] private GameObject backCreditsButton;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject buttonsInMenu;
    
    Vector3 creditsStartPos = new Vector3();
    void Start()
    {
        creditsStartPos = new Vector3(creditsWindow.transform.position.x, creditsWindow.transform.position.y, creditsWindow.transform.position.z);
        MainMenuSetActive(true);
        mainMenuScene = SceneManager.GetActiveScene();
        pivotPoint.transform.rotation = new Quaternion(0, 0, 0, 0);
    }


    void Update()
    {
        OnLoadMenuScene();
    }

    private void OnLoadMenuScene()
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
    private void StartGameButton()
    {
        SceneManager.LoadScene("Level1");
    }
    private void SettingsButton()
    {
        MainMenuSetActive(false);
        settingsWindow.SetActive(true);
    }

    private void CreditsButton()
    {
        MainMenuSetActive(false);
        backCreditsButton.SetActive(true);
        creditsWindow.SetActive(true);
        isCreditsWindowOpen = true;
    }

    private void QuitGameButton()
    {
        confirmationWindow.SetActive(true);
    }
    private void QuitConfirmYesButton()
    {
        Application.Quit();
    }

    private void QuitConfirmNoButton()
    {
        confirmationWindow.SetActive(false);
    }
    
    private void BackButton()
    {
        MainMenuSetActive(true);
        creditsWindow.transform.position = new Vector3(creditsStartPos.x, creditsStartPos.y, creditsStartPos.z);
    }
    
    private void MainMenuSetActive(bool isActive)
    {
        if(isActive)
        {
            buttonsInMenu.SetActive(true);
            settingsWindow.SetActive(false);
            creditsWindow.SetActive(false);
            backCreditsButton.SetActive(false);
            isCreditsWindowOpen = false;
            confirmationWindow.SetActive(false);
        }
        else if(!isActive)
        {
            buttonsInMenu.SetActive(false);
        }
    }
}
