using UnityEngine;

public class Lever : MonoBehaviour{
    public GameObject ParentAllLigthON_OFF;
    public bool status = false;
    public bool startL = false;

    void Start() {
        if(startL){
            foreach (Light l in ParentAllLigthON_OFF.GetComponentsInChildren<Light>())
                l.enabled = false;
        }
    }
    public void On(){
        Debug.Log("On");
        foreach (Light l in ParentAllLigthON_OFF.GetComponentsInChildren<Light>())
            l.enabled = !l.enabled;
        status = !status;
    }
    public void Off(){
        foreach (Light l in ParentAllLigthON_OFF.GetComponentsInChildren<Light>())
            l.enabled = !l.enabled;
        status = !status;
    }
}
