using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    public AnimationCurve fadeCurve;
    public string colorPropertyName = "_Color";
    private Renderer rend;

    void Start(){
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn(){
        Fade(1, 0);
    }
    
    public void FadeOut(){
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut){
        StartCoroutine(FadeRoutine(alphaIn,alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn,float alphaOut){
        rend.enabled = true;
        float timer = 0;
        while(timer <= fadeDuration){
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, fadeCurve.Evaluate(timer / fadeDuration));
            rend.material.SetColor(colorPropertyName, newColor);
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor(colorPropertyName, newColor2);
        if(alphaOut == 0)
            rend.enabled = false;
    }
}
