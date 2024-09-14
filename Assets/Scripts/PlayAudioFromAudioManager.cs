using UnityEngine;

public class PlayAudioFromAudioManager : MonoBehaviour{
    public string target;
    public void Play(){
        AudioManager.instance.Play(target);
    }
    public void Play(string audioName){
        AudioManager.instance.Play(audioName);
    }
}
