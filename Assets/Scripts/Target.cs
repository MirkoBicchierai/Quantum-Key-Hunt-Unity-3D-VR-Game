using UnityEngine;

public class Target : MonoBehaviour{
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;
    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;
    private Vector3 _randomRotation;
    private Vector3 _initialPosition;
    private Vector3 _targetPosition;  // Target position for random movement
    private bool _isDisabled;
    public LevelRegistry Registry;
    public bool useRotation = true;  // Toggle to decide between rotation and random movement
    public float movementRange = 1f; // Range for random movement
    public float speed = 1f;         // Speed of movement

    void Start(){
        Registry.AddTarget();
    }
    private void Awake(){
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _randomRotation = new Vector3(UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f));
        _initialPosition = transform.position;  // Store the initial position of the target
        SetNewTargetPosition();  // Set an initial target position
    }
    private void Update() {
        if (useRotation)
            Rotate();
        else
            MoveRandomly();
    }
    private void Rotate() {
        transform.Rotate(_randomRotation);
    }
    private void MoveRandomly() {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
            SetNewTargetPosition();
    }
    private void SetNewTargetPosition() {
        float newX = _initialPosition.x + UnityEngine.Random.Range(-movementRange, movementRange);
        float newZ = _initialPosition.z + UnityEngine.Random.Range(-movementRange, movementRange);
        _targetPosition = new Vector3(newX, _initialPosition.y, newZ);
    }
    private void OnCollisionEnter(Collision other) {
        if (!_isDisabled && other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            TargetDestroyEffect();
            ToggleTarget();
            Registry.TargetDestroy();
        }
    }
    private void TargetDestroyEffect() {
        var random = UnityEngine.Random.Range(0.8f, 1.2f);
        _audioSource.pitch = random;
        _audioSource.Play();
        _particleSystem.Play();
    }
    private void ToggleTarget() {
        _meshRenderer.enabled = _isDisabled;
        _boxCollider.enabled = _isDisabled;
        _isDisabled = !_isDisabled;
    }
}
