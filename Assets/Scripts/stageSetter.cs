using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageSetter : MonoBehaviour {

    [HideInInspector]
    public static GameStages currentStage;

    public enum GameStages
    {
        Start,//0
        Matches,//1
        Fire,//2
        DarkRoom//3
    }

    public static void setState(int Stage)
    {
        currentStage = (GameStages)Stage;
    }
}
