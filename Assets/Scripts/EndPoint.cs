using UnityEngine;

public class EndPoint : MonoBehaviour{
    public Transform plate;
    public Transform player;
    private bool check = true; 
    public LevelRegistry Registry;
    void Update(){
        float distance = Vector3.Distance(plate.position, player.position);
        if (distance < 0.8 && check){
            Registry.Win();
            check = false;
        }
    }

}
