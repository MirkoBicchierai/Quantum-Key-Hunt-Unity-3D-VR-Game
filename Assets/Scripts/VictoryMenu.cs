using UnityEngine;
using UnityEngine.UI;

public class VictoryMenu : MonoBehaviour{
    public GameObject mainMenu;
    public Button back;

    void Start(){
        EnableMainMenu();
        back.onClick.AddListener(StartMainMenu);
    }
    public void StartMainMenu(){
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }
    public void HideAll(){
        mainMenu.SetActive(false);
    }
    public void EnableMainMenu(){
        mainMenu.SetActive(true);
    }

}
