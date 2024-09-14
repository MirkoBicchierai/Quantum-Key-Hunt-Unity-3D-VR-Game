using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XRAlyxGrab : XRGrabInteractable{
    public float jumpAngleDegree = 0;
    public float velocityThreshold = 30;
    private XRRayInteractor rayInteractor;
    private Vector3 previousPos;
    private Rigidbody interactableRigidbody;

    protected override void Awake(){
        base.Awake();
        interactableRigidbody = GetComponent<Rigidbody>();
    }
    private void Update(){
        if (isSelected && firstInteractorSelecting is XRRayInteractor){
            Vector3 velocity = (rayInteractor.transform.position - previousPos) / Time.deltaTime;
            previousPos = rayInteractor.transform.position;
            if (velocity.magnitude > velocityThreshold){
                Drop();
                interactableRigidbody.velocity = ComputeVelocity();
            }
        }
    }

    public Vector3 ComputeVelocity(){
        Vector3 diff = rayInteractor.transform.position - transform.position;
        Vector3 diffXZ = new Vector3(diff.x, 0, diff.z);
        float diffXZLength = diffXZ.magnitude;
        float diffYLength = diff.y;
        float angleInRadian = Mathf.Clamp(diff.normalized.y * 90, jumpAngleDegree, 90) * Mathf.Deg2Rad;
        float jumpSpeed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(diffXZLength, 2)/ (2 * Mathf.Cos(angleInRadian)*Mathf.Cos(angleInRadian)*(diffXZ.magnitude * Mathf.Tan(angleInRadian) - diffYLength)));
        Vector3 jumpVelocityVector = diffXZ.normalized * Mathf.Cos(angleInRadian) * jumpSpeed + Vector3.up * Mathf.Sin(angleInRadian) * jumpSpeed;
        return jumpVelocityVector;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args){
        if (args.interactorObject is XRRayInteractor){
            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;
            rayInteractor = (XRRayInteractor)args.interactorObject;
            previousPos = rayInteractor.transform.position;
        }
        else{
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = false;
        }
        base.OnSelectEntered(args);
    }

}