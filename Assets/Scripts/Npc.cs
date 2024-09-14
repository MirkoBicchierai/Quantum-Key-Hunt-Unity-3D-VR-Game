using Unity.VisualScripting;
using UnityEngine;

public class Npc : MonoBehaviour{
    public Object player;
    public Canvas textCanvas;
    private Transform playerTransform;
    private Transform headTransform;
    private Transform canvasTransform;

    void Start(){
        canvasTransform = textCanvas.transform;
        headTransform = this.transform;
        playerTransform = player.GetComponent<Transform>();
        
    }
    void Update(){
            Vector3 directionToPlayer = playerTransform.position - headTransform.position;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            Quaternion lookAwayRotation = lookRotation * Quaternion.Euler(0, 0, 0);
            headTransform.rotation = Quaternion.Slerp(headTransform.rotation, lookAwayRotation, Time.deltaTime * 5f);
            lookAwayRotation = lookRotation * Quaternion.Euler(0, 180f, 0);
            canvasTransform.rotation = Quaternion.Slerp(canvasTransform.rotation, lookAwayRotation, Time.deltaTime * 5f);
    }
}
