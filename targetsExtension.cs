using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetsExtension : MonoBehaviour
{
    public GameObject infoWin;  //fereastra cu informatii

    public Animator anim;   //animatorul ferestrei cu informatii


    private void Awake()
    {
        //atribui componentele
        infoWin = GameObject.Find("Info window");

        anim = infoWin.GetComponentInChildren<Animator>();
    }

}
