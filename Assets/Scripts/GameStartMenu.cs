using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject about;
    [Header("Main Menu Buttons")]
    public Button tutorial;
    public Button sandbox;
    public Button level1;
    public Button level2;
    public Button aboutButton;
    public Button quitButton;
    public List<Button> returnButtons;

    void Start(){
        EnableMainMenu();
        tutorial.onClick.AddListener(StartTutorial);
        sandbox.onClick.AddListener(StartSandBox);
        level1.onClick.AddListener(StartLevel1);
        level2.onClick.AddListener(StartLevel2);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);
        foreach (var item in returnButtons)
            item.onClick.AddListener(EnableMainMenu);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void StartTutorial(){
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }
    public void StartSandBox(){
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(2);
    }
    public void StartLevel1(){
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(3);
    }
    public void StartLevel2(){
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(4);
    }
    public void HideAll(){
        mainMenu.SetActive(false);
        about.SetActive(false);
    }
    public void EnableMainMenu(){
        mainMenu.SetActive(true);
        about.SetActive(false);
    }
    public void EnableAbout(){
        mainMenu.SetActive(false);
        about.SetActive(true);
    }
}
