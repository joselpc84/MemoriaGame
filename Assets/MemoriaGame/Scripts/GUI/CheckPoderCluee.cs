﻿//
//  CheckPoderCluee.cs
//
//  Author:
//       Luis Alejandro Vieira <lavz24@gmail.com>
//
using System.Collections;
using UnityEngine;


public class CheckPoderCluee : MonoBehaviour
{
    UIButton button;
    bool check = false;
    void Awake(){

        button = GetComponent<UIButton> ();
    }

    public void CheckEnable(){
        check = true;
        if (!ManagerCluesPower.Instance.isPowerUsed) {
            button.isEnabled = true;
        }
    }

    void  LateUpdate(){
        if (check) {
            if (!ManagerCluesPower.Instance.isPowerUsed) {
                button.isEnabled = true;
                check = false;
                enabled = false;
            }
        }
        
    }
       
}

