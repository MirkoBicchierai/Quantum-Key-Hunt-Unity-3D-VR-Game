using UnityEngine;

public class ElectricTorchOnOff : MonoBehaviour{
	private Light _light;
    private AudioSource _audioSource;

    void Start(){
		_light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
	}
    public void LightOn(){
        _audioSource.Play();
        _light.enabled = true;
    }
    public void LighOff(){
        _audioSource.Play();
        _light.enabled = false;
        
    }
}
