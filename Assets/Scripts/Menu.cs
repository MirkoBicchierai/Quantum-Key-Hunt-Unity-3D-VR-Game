using TMPro;
using UnityEngine;
using System;
using NavKeypad;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public GameObject textScore;
    public GameObject textKey;
    public LevelRegistry Registry;
    public GameObject pad;
    private TextMeshProUGUI _RealTextScore;
    private TextMeshProUGUI _RealTextKey;
    private String keypadCombo;
    private int[] objective;
    private String actualKeyShow="";

    private void Awake(){
        _RealTextScore = textScore.GetComponent<TextMeshProUGUI>();
        _RealTextKey = textKey.GetComponent<TextMeshProUGUI>();
        keypadCombo = pad.GetComponent<Keypad>().keypadCombo.ToString();
        objective = Registry.objective;
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
        _RealTextScore.text = s + "/" + t;
        actualKeyShow = "";
        int k = 0;
        foreach (var minScore in objective){
            if(Registry.Score>=minScore){
                actualKeyShow += int.Parse(keypadCombo[k].ToString());
            }
            else
                actualKeyShow += "*";
            k++;
            
        }
        _RealTextKey.text = "Key: " + actualKeyShow;
    }
    
}
