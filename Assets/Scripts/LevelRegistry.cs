using System;
using UnityEngine;

public class LevelRegistry : MonoBehaviour{
    public int TotalTarget = 0;
    public int Score = 0;
    public int TotalAmmo = 0;
    public int AmmoCount = 0;
    private float elapsedTime = 0f;
    public bool stopTime = false;
    public String levelName = "";
    public int[] objective = new int[4] { 1, 2, 3, 4 };
    public float delayX = 5f;
    private float timechecklose = 0f;
    private bool controlLose = false;

    public void Win(){
        stopTime = true;
        TransferDataStaticScene.ammoUsed = AmmoCount;
        TransferDataStaticScene.TotalAmmo = TotalAmmo;
        TransferDataStaticScene.TotalTarget = TotalTarget;
        TransferDataStaticScene.TargetDestryed = Score;
        TransferDataStaticScene.timeLevel = elapsedTime;
        TransferDataStaticScene.levelName = levelName;
        SceneTransitionManager.singleton.GoToSceneAsync(5);
    }
    private void Lose(){
        stopTime = true;
        TransferDataStaticScene.ammoUsed = AmmoCount;
        TransferDataStaticScene.TotalAmmo = TotalAmmo;
        TransferDataStaticScene.TotalTarget = TotalTarget;
        TransferDataStaticScene.TargetDestryed = Score;
        TransferDataStaticScene.timeLevel = elapsedTime;
        TransferDataStaticScene.levelName = levelName;
        SceneTransitionManager.singleton.GoToSceneAsync(6);
    }
    private void CheckLose(){
        if(AmmoCount>=TotalAmmo && Score < objective[objective.Length-1])
            Lose();
    }
    void Update(){
        if(!stopTime)
            elapsedTime += Time.deltaTime;

        timechecklose += Time.deltaTime;
        if (timechecklose >= delayX && controlLose){  
            timechecklose=0f; 
            controlLose=false;
            CheckLose();
        }

    }
    public void AddAmmo(int x){
        TotalAmmo += x;
    }
    public void ShootAmmo(){
        AmmoCount++;
        controlLose=true;
        timechecklose = 0f;
    }
    public void AddTarget(){
        TotalTarget++;
    }
    public void TargetDestroy(){
        Score++;
    }
    
}
