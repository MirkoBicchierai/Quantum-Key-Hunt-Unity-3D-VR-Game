using System;
using TMPro;
using UnityEngine;

public class SummaryScore : MonoBehaviour{
    public int ammoUsed = 0;
    public int TotalAmmo = 0;
    public int TotalTarget = 0;
    public int TargetDestryed = 0;
    public float timeLevel = 0f;
    public String levelName = "";
    public GameObject title;
    public GameObject score;
    public GameObject precision;
    public GameObject Time;

    void Start(){
        getValue();
        title.GetComponent<TextMeshPro>().text = levelName;
        score.GetComponent<TextMeshProUGUI>().text = "Score: " + TargetDestryed + "/" + TotalTarget;
        float scale = Mathf.Pow(10, 2);
        float pre = 0f;
        if(ammoUsed != 0){
            pre = ((float)TargetDestryed/ammoUsed)*100;
            Debug.Log(""+pre);
            pre = Mathf.Floor(pre * scale) / scale;
            Debug.Log(""+pre);
        }
        precision.GetComponent<TextMeshProUGUI>().text = "Precision: " + pre + "%";
        int minutes = Mathf.FloorToInt(timeLevel/60);
        int seconds = Mathf.FloorToInt(timeLevel%60);
        Time.GetComponent<TextMeshProUGUI>().text = "Time: " + minutes+":"+seconds + " min";
        resetValue();
    }
    private void getValue(){
        ammoUsed = TransferDataStaticScene.ammoUsed;
        TotalAmmo = TransferDataStaticScene.TotalAmmo;
        TotalTarget = TransferDataStaticScene.TotalTarget;
        TargetDestryed = TransferDataStaticScene.TargetDestryed;
        timeLevel = TransferDataStaticScene.timeLevel;
        levelName = TransferDataStaticScene.levelName;
    }
    private void resetValue(){
            TransferDataStaticScene.ammoUsed = 0;
            TransferDataStaticScene.TotalAmmo = 0;
            TransferDataStaticScene.TotalTarget = 0;
            TransferDataStaticScene.TargetDestryed = 0;
            TransferDataStaticScene.timeLevel = 0f;
            TransferDataStaticScene.levelName = ""; 
    }

}
