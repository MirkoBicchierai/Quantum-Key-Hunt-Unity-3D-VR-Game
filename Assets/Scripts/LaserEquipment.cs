using UnityEngine;

public class LaserEquipment : MonoBehaviour{
    [SerializeField] public GameObject laserBeam;
    private bool activeLaser = false;

    public void Toggle(){
        activeLaser = !activeLaser;
        laserBeam.SetActive(activeLaser);
    }
}
