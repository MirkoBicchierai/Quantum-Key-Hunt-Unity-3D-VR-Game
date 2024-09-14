using UnityEngine;

public class OnlyRotate : MonoBehaviour{
    private MeshRenderer _meshRenderer;
    private Vector3 _randomRotation;
    public LevelRegistry Registry;
    private void Awake(){
        _randomRotation = new Vector3(UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f));
    }
    private void Update() => Rotate();
    private void Rotate() => transform.Rotate(_randomRotation);

}
