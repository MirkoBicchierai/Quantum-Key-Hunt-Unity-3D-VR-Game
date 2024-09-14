using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Magazine currentMagazine;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float shootDelay = 0.2f;
    [SerializeField] private float bulletSpeed = 8200f;
    [Space, SerializeField] private AudioSource audiosource;
    [SerializeField] private Transform transformMagazine;
    private float lastShot;
    private Transform x;
    public LevelRegistry Registry;
    public bool backDirection = false;

    public void AttachMagazine(Magazine magazine){
        currentMagazine = magazine;
        currentMagazine.SetAttachedState(true);
        currentMagazine.GetComponent<Rigidbody>().isKinematic = true;
        x = currentMagazine.transform.parent;
        currentMagazine.transform.position = transformMagazine.position;
        currentMagazine.transform.rotation = transformMagazine.rotation;
        currentMagazine.transform.parent = transformMagazine;
    }
    public void DetachMagazine(){
        if (currentMagazine != null){   
            currentMagazine.transform.parent = x;
            currentMagazine.SetAttachedState(false);
            currentMagazine.GetComponent<Rigidbody>().isKinematic = false;
            currentMagazine = null;
            
        }
    }
    public bool IsMagazineAttached(){
        return currentMagazine != null;
    }
    public void Shoot(){
        if (currentMagazine != null && currentMagazine.ammoCount > 0){
            if(lastShot > Time.time) return;
            currentMagazine.Use();
            Registry.ShootAmmo();
            lastShot = Time.time + shootDelay;
            GunShootAudio();
            var bulletPrefab = Instantiate(bullet, bulletPosition.position,bulletPosition.rotation);
            var bulletRB = bulletPrefab.GetComponent<Rigidbody>();
            if(backDirection)
                bulletRB.AddForce(bulletPrefab.transform.TransformDirection(Vector3.right) * bulletSpeed);
            else
                bulletRB.AddForce(bulletPrefab.transform.TransformDirection(Vector3.forward) * bulletSpeed);
            Destroy(bulletPrefab, 5f); 
        }
    }
    private void GunShootAudio(){
        var random = Random.Range(08f, 1.2f);
        audiosource.pitch = random;
        audiosource.Play();
    }

}