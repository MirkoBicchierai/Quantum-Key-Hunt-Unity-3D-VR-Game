using System;
using TMPro;
using UnityEngine;

public class OracleTarget : MonoBehaviour{
    
    public float amplitude = 0.1f;
    public float frequency = 3f;
    private float _initialY;
    public GameObject text;
    public LevelRegistry Registry;
    private Vector3 _randomRotation;
    private TextMeshProUGUI _realText;

    private void Awake(){
        _realText = text.GetComponent<TextMeshProUGUI>();
        _initialY = transform.position.y;
        _randomRotation = new Vector3(UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f), UnityEngine.Random.Range(1f,1f));
    }
    private void Update(){   
        String s = "0";
        if(Registry.Score<10)
            s += Registry.Score;
        else
            s = "" + Registry.Score;
        String t = "0";
        if(Registry.TotalTarget<10)
           t += Registry.TotalTarget;
        else
            t = "" + Registry.TotalTarget;
        _realText.text = s + "/" + t;
        Rotate();
        Oscillate();
    }
    private void Rotate(){
        transform.Rotate(_randomRotation);
    }
    private void Oscillate(){
        float newY = _initialY + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
