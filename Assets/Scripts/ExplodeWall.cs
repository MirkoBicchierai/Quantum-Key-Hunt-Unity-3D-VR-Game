using UnityEngine;

public class ExplodeWall : MonoBehaviour{
    public GameObject fractured;

    public void BreakWall(float explosionForce, Transform x, float radius){
        GameObject fract = Instantiate(fractured,transform.position,transform.rotation);
        foreach(Rigidbody rb in fract.GetComponentsInChildren<Rigidbody>()){
            rb.AddExplosionForce(explosionForce,x.position, radius, 1f, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }

}
