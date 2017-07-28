using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoWindowController : MonoBehaviour {


    public Text Titlu;
    public Text Autor;
    public Text An;

    public int index;
    public string lastDiscover;
    public bool isDiscovered;

    public fullScreenInfoController FSController;
    public XMLManager DB;

    private void Awake()
    {
        DB = GameObject.Find("XML Manager").GetComponent<XMLManager>();
    }


    public void assignValues(string titlu,string autor,string an)
    {
        Titlu.text = titlu;
        Autor.text = "Autor:\n" + autor;
        An.text = "An:\n" + an;
    }

    private void OnMouseDown()
    {
        if (isDiscovered == false)
            return;

        //indexul ne este dat din DefaultTrackableEventHandler
        Item toShow = DB.infoDB.list[index];    //itemul care trebuie afisat

        //atriuim valorile ferestrei full screen
        StartCoroutine(FSController.setText(toShow.titlu, toShow.autor, toShow.an, toShow.detalii));

        //deschidem fereastra full screen
        FSController.appear();

        //dezactivam butonul "inapoi la meniul principal"
        GameObject.Find("Canvas").SetActive(false);
    }
}
