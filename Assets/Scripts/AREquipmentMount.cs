using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class AREquipmentMount : MonoBehaviour{
    public float delayX = 0.5f;
    public float delayY = 0.5f;
    [SerializeField] private Transform transformTorch;
    [SerializeField] private Transform transformScope;
    [SerializeField] private Transform transformLaser;
    private Equipment laser;
    private Equipment torch;
    private Equipment scope;
    private XRGrabInteractable grabInteractable;
    private XRBaseInteractor leftHandInteractor;
    private XRBaseInteractor rightHandInteractor;
    private bool isLeftHandAttached = false;
    private bool isRightHandAttached = false;
    private bool wasXButtonPressed = false;
    private bool wasYButtonPressed = false;
    private float timeElapsedY = 1.0f;
    private Transform ScopeParent;
    private Transform LaserParent;
    private Transform TorchParent;
    private float timeElapsedX = 1.0f;

    void Start(){
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }
    private void OnSelectEntered(SelectEnterEventArgs args){   
        if (args.interactorObject is XRBaseInteractor interactor){
            if (interactor.CompareTag("LeftHandFake")){
                isLeftHandAttached = true;
                leftHandInteractor = interactor;
            }
            else if (interactor.CompareTag("RightHand")){
                isRightHandAttached = true;
                rightHandInteractor = interactor;
            }
        }
    }
    private void OnSelectExited(SelectExitEventArgs args){
        if (args.interactorObject is XRBaseInteractor interactor){
            if (interactor == leftHandInteractor){
                isLeftHandAttached = false;
                leftHandInteractor = null;
            }
            else if (interactor == rightHandInteractor){
                isRightHandAttached = false;
                rightHandInteractor = null;
            }
        }
    }
    void Update(){   
        Debug.Log(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand));
        timeElapsedX += Time.deltaTime;
        if (timeElapsedX >= delayX)
            wasXButtonPressed = false;

        timeElapsedY += Time.deltaTime;

        if (timeElapsedY >= delayY) 
            wasYButtonPressed = false;
        bool xButtonPressed = false;
        if (laser != null && isLeftHandAttached && isRightHandAttached && 
            InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primaryButton, out xButtonPressed) && 
            xButtonPressed && !wasXButtonPressed){   
            Debug.Log("Toggle Laser");
            laser.le.Toggle();
            wasXButtonPressed = xButtonPressed;
            timeElapsedX = 0f;
        }
        bool yButtonPressed = false;
        if (torch != null && isLeftHandAttached && isRightHandAttached && 
            InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.secondaryButton, out yButtonPressed) && 
            yButtonPressed && !wasYButtonPressed){   
            Debug.Log("Toggle Torch");
            torch.te.Toggle();
            wasYButtonPressed = yButtonPressed;
            timeElapsedY = 0f;
        }  
    }
    public void AttachScope(Equipment eq){
        scope = eq;
        ScopeParent = eq.transform.parent;
        eq.SetAttachedState(true);
        eq.GetComponent<Rigidbody>().isKinematic = true;
        eq.transform.position = transformScope.position;
        eq.transform.rotation = transformScope.rotation;
        eq.transform.parent = transformScope;
    }
    public void DetachScope(Equipment eq){
        eq.transform.parent = ScopeParent;
        eq.SetAttachedState(false);
        eq.GetComponent<Rigidbody>().isKinematic = false;
        scope = null;
    }
    public void AttachLaser(Equipment eq){
        laser = eq;
        LaserParent = eq.transform.parent;
        eq.SetAttachedState(true);
        eq.GetComponent<Rigidbody>().isKinematic = true;
        eq.transform.position = transformLaser.position;
        eq.transform.rotation = transformLaser.rotation;
        eq.transform.parent = transformLaser;
    }
    public void DetachLaser(Equipment eq){
        eq.transform.parent = LaserParent;
        eq.SetAttachedState(false);
        eq.GetComponent<Rigidbody>().isKinematic = false;
        laser = null;
    }
    public void AttachTorch(Equipment eq){
        torch = eq;
        TorchParent = eq.transform.parent;
        eq.SetAttachedState(true);
        eq.GetComponent<Rigidbody>().isKinematic = true;
        eq.transform.position = transformLaser.position;
        eq.transform.rotation = transformLaser.rotation;
        eq.transform.parent = transformLaser;
    }
    public void DetachTorch(Equipment eq){
        eq.transform.parent = TorchParent;
        eq.SetAttachedState(false);
        eq.GetComponent<Rigidbody>().isKinematic = false;
        torch = null;
    }
}
