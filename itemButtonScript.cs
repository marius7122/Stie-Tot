using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemButtonScript : MonoBehaviour {

    public Item myItem;

    public Text titlu;
    public Text autor;

    public GameObject scrollview;
    public GameObject FSInfo;
    public fullScreenInfoController FSController;

    private void Start()
    {
        scrollview = GameObject.Find("Canvas");

        FSController = FSInfo.GetComponent<fullScreenInfoController>();


        //aflam legaturile cu titlu si autor(UI)
        Text[] txts = gameObject.GetComponentsInChildren<Text>();

        foreach(Text i in txts)
        {
            if (i.name == "autor")
                autor = i;

            if (i.name == "titlu")
                titlu = i;
        }


        setText();
    }


    void setText()
    {
        titlu.text = myItem.titlu;
        autor.text = myItem.autor;
    }

    public void showInfo()
    {
        //activam tabloul cu informatii fullscreen
        FSInfo.SetActive(true);

        //atribuim valori tabloului cu informatii
        StartCoroutine(FSController.setText(myItem.titlu, myItem.autor, myItem.an, myItem.detalii));
    }

}
