using UnityEngine;

public class C4 : MonoBehaviour{
    public GameObject explosionEffect;
    public bool Armed;
    private float explosionForce = 4f;
    private float radius = 3f;
    private Light _light;
    Rigidbody rig;
    private AudioSource _audioSource;

    void Start(){
        Armed = false;
        _audioSource = GetComponent<AudioSource>();
        _light = GetComponentInChildren<Light>();
    }
    public void ArmingSwitch(){
        Armed = !Armed;
        _light.enabled = Armed;
        _audioSource.Play();
    }
    public void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach (Collider near in colliders){
            ExplodeWall explodeWall = near.GetComponent<ExplodeWall>();
            if (explodeWall != null)
                explodeWall.BreakWall(explosionForce,transform,radius); 
        }
        Instantiate(explosionEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }

}
