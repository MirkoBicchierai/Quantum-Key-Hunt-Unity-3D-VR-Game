using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazineSocket : MonoBehaviour{
    public XRSocketInteractor socketInteractor;
    private Weapon weapon;

    void Start(){
        if (socketInteractor == null)
            socketInteractor = GetComponent<XRSocketInteractor>();
        weapon = GetComponentInParent<Weapon>();
        socketInteractor.selectEntered.AddListener(OnMagazineAttached);
        socketInteractor.selectExited.AddListener(OnMagazineDetached);
    }
    void OnDestroy(){
        socketInteractor.selectEntered.RemoveListener(OnMagazineAttached);
        socketInteractor.selectExited.RemoveListener(OnMagazineDetached);
    }
    private void OnMagazineAttached(SelectEnterEventArgs args){
        Magazine magazine = args.interactableObject.transform.GetComponent<Magazine>();
        if (magazine != null){   
            magazine.SetCollider(true);
            weapon.AttachMagazine(magazine);
        }
    }
    private void OnMagazineDetached(SelectExitEventArgs args){
        Magazine magazine = args.interactableObject.transform.GetComponent<Magazine>();
        if (magazine != null){   
            magazine.SetCollider(false);
            weapon.DetachMagazine();
        }
    }
}