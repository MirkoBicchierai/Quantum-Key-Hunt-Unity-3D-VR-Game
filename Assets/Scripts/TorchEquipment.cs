using UnityEngine;

public class TorchEquipment : MonoBehaviour{
    private bool activeTorch = false;
    private Light _light;

    void Start(){
		_light = GetComponentInChildren<Light>();
	}
    public void Toggle(){
        activeTorch = !activeTorch;
        _light.enabled = activeTorch;
    }
}
