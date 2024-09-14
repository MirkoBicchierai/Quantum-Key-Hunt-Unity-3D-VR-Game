using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftHandGUI : MonoBehaviour{
    [SerializeField] public XRDirectInteractor interactor;
    [SerializeField] public GameObject menu;
    public float delay = 0.5f;
    private float timeElapsed = 1.0f;
    private bool wasButtonPressed = false;
    private bool Using = false;
    private bool Opened = false;

    void Start(){   
        Using = false;
        CloseMenu();
        interactor.selectEntered.AddListener(OnSelectEntered);
        interactor.selectExited.AddListener(OnSelectExited);
    }
    void OnSelectEntered(SelectEnterEventArgs args){   
        Using = true;
        Debug.Log("Selection started with " + args.interactableObject.transform.name);
        if(Opened)
            CloseMenu();
    }
    void OnSelectExited(SelectExitEventArgs args){
        Using = false;
        Debug.Log("Selection ended with " + args.interactableObject.transform.name);
    }
    private void OpenMenu(){
        Opened = true;
        Debug.Log("Apri Menu");
        menu.SetActive(true);
    } 
    private void CloseMenu(){
        Opened = false;
        Debug.Log("Chiudi Menu");
        menu.SetActive(false);
    }   
    void Update(){
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= delay)  
            wasButtonPressed = false;

        bool ButtonPressed = false;
        if (!Using && InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.menuButton, out ButtonPressed) && ButtonPressed && !wasButtonPressed){   
            wasButtonPressed = ButtonPressed;
            Debug.Log(""+Opened);
            if(Opened)
                CloseMenu();
            else
                OpenMenu();
            timeElapsed = 0f;
        }
    }
}
