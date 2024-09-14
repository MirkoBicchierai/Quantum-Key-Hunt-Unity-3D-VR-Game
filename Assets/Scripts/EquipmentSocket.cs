using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EquipmentSocket : MonoBehaviour{
    public XRSocketInteractor socketInteractor;
    private AREquipmentMount weapon;
    void Start(){
        if (socketInteractor == null)
            socketInteractor = GetComponent<XRSocketInteractor>();
        weapon = GetComponentInParent<AREquipmentMount>();
        socketInteractor.selectEntered.AddListener(OnEquipmentAttached);
        socketInteractor.selectExited.AddListener(OnEquipmentDetached);
    }
    void OnDestroy(){
        socketInteractor.selectEntered.RemoveListener(OnEquipmentAttached);
        socketInteractor.selectExited.RemoveListener(OnEquipmentDetached);
    }
    private void OnEquipmentAttached(SelectEnterEventArgs args){
        Equipment eq = args.interactableObject.transform.GetComponent<Equipment>();
        if(eq.getSelectedType()=="Scope" && eq != null)
            weapon.AttachScope(eq);
        if(eq.getSelectedType()=="Laser" && eq != null)
            weapon.AttachLaser(eq);
        if(eq.getSelectedType()=="Torch" && eq != null)
            weapon.AttachTorch(eq);
    }
    private void OnEquipmentDetached(SelectExitEventArgs args){
        Equipment eq = args.interactableObject.transform.GetComponent<Equipment>();
        if (eq.getSelectedType()=="Scope" && eq != null)
            weapon.DetachScope(eq);
        if (eq.getSelectedType()=="Laser" && eq != null)
            weapon.DetachLaser(eq);
        if (eq.getSelectedType()=="Torch" && eq != null)
            weapon.DetachTorch(eq);
    }
}
