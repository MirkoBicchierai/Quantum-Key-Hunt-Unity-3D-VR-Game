using UnityEngine;

public class Equipment : MonoBehaviour{
    public enum EqType{
        Scope,
        Laser,
        Torch
    }
    public bool isAttached = false;
    [SerializeField] public LaserEquipment le; 
    [SerializeField] public TorchEquipment te; 
    [SerializeField] private EqType type;
    private string selectedType;
    
    void Start(){
         selectedType = type.ToString();
    }

    public string getSelectedType(){
        return selectedType;
    }

    public void SetAttachedState(bool attached){
        isAttached = attached;
    }

}
