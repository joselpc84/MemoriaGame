﻿using UnityEngine;
using System.Collections;

public enum PowerDoor
{
    Any = 0, // Use this transition to represent a non-existing transition in your system
    Tati = 1,
    Tica = 2,
    Tico = 3,
    Timi = 4,
    Topi = 5,
}
public class PowerOff : MonoBehaviour {

    public PowerDoor character = PowerDoor.Any;


    bool Locked = true;
    [HideInInspector]
    public bool used = false;


    UIButton button;

    static  Door[] doors;
    void Awake(){
    
        button = GetComponent<UIButton> ();
        button.isEnabled = false;

        if (doors == null) {
        
            doors = GameObject.FindObjectsOfType<Door> ();
        }

        for (int i = 0; i < doors.Length; ++i) {
            if (character == doors [i].character) {
                doors[i].onCheckTruePair.Add (new Signal ("setOnPower", gameObject));

                break;
            }
        }


        ManagerPause.Instance.onGamePaused.Add (new Signal ("onPaused", gameObject));
        ManagerPause.Instance.onGameResumed.Add (new Signal ("onResume", gameObject));



        ManagerPowers.Instance.onPowerTrue.Add (new Signal ("onNotUse", gameObject));
        ManagerPowers.Instance.onPowerFalse.Add (new Signal ("onUse", gameObject));
    }
    void Start(){
        doors = null;
    }


    [Signal]
    public void setOnPower(){
        Locked = false;
        button.isEnabled = true;
    }
    public void setOffPower(){

        if (!isPaused) {
            button.isEnabled = false;
            used = true;
        }


    }

    #region Used
    [Signal]
    void onUse(){
        if(!Locked && !used)
            button.isEnabled = true;

    }
    [Signal]
    void onNotUse(){
        Debug.Log ("onNotUse");
        button.isEnabled = false;

    }
    #endregion

    #region Paused
    bool isPaused = false;
    [Signal]
    void onPaused(){
        isPaused = true;

    }
    [Signal]
    void onResume(){
        isPaused = false;

    }
    #endregion

}
