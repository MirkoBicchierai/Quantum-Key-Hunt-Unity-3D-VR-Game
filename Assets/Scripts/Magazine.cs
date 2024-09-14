using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Magazine : MonoBehaviour
{
    public int ammoCount = 30;
    public bool isAttached = false;
    public XRGrabInteractable interactableGrab;
    public LevelRegistry Registry;
    [SerializeField] public GameObject topBullet;
    private SphereCollider sphereC;
    private BoxCollider boxC;

    void Start(){
        Registry.AddAmmo(ammoCount);
        sphereC = GetComponent<SphereCollider>();
        boxC = GetComponent<BoxCollider>();
        sphereC.isTrigger = true;
        interactableGrab.colliders.Clear();
        interactableGrab.colliders.Add(boxC);
    }
    public void SetAttachedState(bool attached){
        isAttached = attached;
    }
    public void SetCollider(bool ty){
        if(ty){
            interactableGrab.colliders.Clear();
            sphereC.isTrigger = false;
            interactableGrab.colliders.Add(sphereC);
        }else{
            interactableGrab.colliders.Clear();
            sphereC.isTrigger = true;
            interactableGrab.colliders.Add(boxC);
        }
    }
    public void Use(){
        ammoCount--;
        if (ammoCount == 0)
            topBullet.SetActive(false);
    }
}