using UnityEngine;

public class ToggleDoor : MonoBehaviour{
    public Animator animator;
    public Transform door;
    public Transform player;
    public GameObject lever;
    public float minDist = 4f;

    void Update(){
        Lever leverComponent = lever.GetComponent<Lever>();
        if (leverComponent != null && leverComponent.status){
            float distance = Vector3.Distance(door.position, player.position);
            if (distance < minDist)
                animator.SetBool("Pass", true);
            else
                animator.SetBool("Pass", false);
        }
        else
            animator.SetBool("Pass", false);  // Ensure door stays closed if lever is off or missing
    }
}
