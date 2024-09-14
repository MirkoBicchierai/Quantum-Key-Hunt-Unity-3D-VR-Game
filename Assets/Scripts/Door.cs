using UnityEngine;

public class Door : MonoBehaviour{
    public Animator animator;
    public Transform door;
    public Transform player;
    public float minDist = 4f;
    void Update(){
        float distance = Vector3.Distance(door.position, player.position);
        if (distance < minDist)
            animator.SetBool("Pass", true);
        else
            animator.SetBool("Pass", false);
    }
}
