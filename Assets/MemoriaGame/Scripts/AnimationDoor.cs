﻿//
// AnimationDoor.cs
//
// Author:
//       Luis Alejandro Vieira <lavz24@gmail.com>
//
// Copyright (c) 2014 
//
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]

class AnimationDoor : MonoBehaviour
{
    public Door door;
    Animator anim;
    void Awake(){
       // door = GetComponent<Door> ();

        anim = GetComponent<Animator> ();

        door.onOpen.Add (new Signal("onOpen",gameObject));
        door.onClose.Add (new Signal("onClose",gameObject));
        door.onShakeTrue.Add (new Signal("onShakeTrue",gameObject));
        door.onShakeFalse.Add (new Signal("onShakeFalse",gameObject));
        door.onCheckTruePair.Add (new Signal("onCheckTruePair",gameObject));

    }
    [Signal]
    void onOpen(){
        anim.SetBool("Open",true);
        anim.SetBool("Shake",false);

    }
    [Signal]
    void onClose(){
        anim.SetBool("Open",false);
    }

    [Signal]
    void onCheckTruePair(){
        //anim.SetBool("Open",false);
        TweenScale.Begin(door.gameObject,1.0f,new Vector3(0.01f,0.01f,0.01f)).AddOnFinished(new EventDelegate(this,"ReleaseDoor"));
        Invoke ("InvokeStar",0.7f);
    }
    [Signal]
    void onShakeTrue(){
        anim.SetBool("Shake",true);
    }
    [Signal]
    void onShakeFalse(){
        anim.SetBool("Shake",false);
    }

    public void ReleaseDoor(){
       // ManagerDoors.Instance.getStar ((int)door.posMaxtrix.x, (int)door.posMaxtrix.y).GetComponent<Animator> ().SetBool ("Changue", true);
        door.Recycle ();
    }

    void InvokeStar(){
        ManagerDoors.Instance.getStar((int)door.posMaxtrix.x,(int)door.posMaxtrix.y).SetActive(true);

    }
}

