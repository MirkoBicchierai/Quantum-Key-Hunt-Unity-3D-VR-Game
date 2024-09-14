using UnityEngine;

public class FinalDoor : MonoBehaviour{
    public GameObject door;
    public void open(){
        Animator animator = door.GetComponent<Animator>();
        animator.SetBool("Pass", true);
    }
}
