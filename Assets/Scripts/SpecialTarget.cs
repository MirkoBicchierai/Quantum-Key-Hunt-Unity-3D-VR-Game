using UnityEngine;

public class SpecialTarget : MonoBehaviour{
    private Vector3 _randomRotation;

    private void Awake(){
        _randomRotation = new Vector3(UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f));
    }
    private void Update() => Rotate();
    private void Rotate() => transform.Rotate(_randomRotation);

}
