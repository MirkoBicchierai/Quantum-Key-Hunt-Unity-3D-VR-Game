using UnityEngine;

public class Detonator : MonoBehaviour{
    public void Detonate(){
        C4[] explosives = FindObjectsOfType<C4>();
        foreach (C4 explosive in explosives){
            if (explosive.Armed)
                explosive.Explode();
        }
    }
}
