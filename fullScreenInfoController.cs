using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fullScreenInfoController : MonoBehaviour
{

    public Text titlu;
    public Text autor;
    public Text an;
    public Text informatii;

    public GameObject backToMainMenuCanvas;
    public GameObject content;          //contentul de la scroll view

    private Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    //atribuie valori campurilor text
    public IEnumerator setText(string Titlu, string Autor, string An, string Informatii)
    {
        titlu.text = Titlu;
        autor.text = "Autor: " + Autor;
        an.text = "Anul aparitiei: " + An;
        informatii.text = Informatii;


        //pentru a fixa un bug din Unity
        RectTransform R;
        R = informatii.GetComponent<RectTransform>();
        yield return new WaitForEndOfFrame();
        R.sizeDelta = new Vector2(R.sizeDelta.x - 0.1f, R.sizeDelta.y);
    }

    //pentru butonul "inapoi"
    public void goBack()
    {
        anim.SetBool("visible", false);



        //activam din nou butonul pentru intoarcere la meniul principal
        backToMainMenuCanvas.SetActive(true);
    }

    //pentru ca fereastra sa apara
    public void appear()
    {
        anim.SetBool("visible", true);
    }

    //pentru ca ferastra sa dispara
    public void dissapear()
    {
        anim.SetBool("visible", false);
    }

    public void setScrollAtBeginning()
    {
        content.GetComponent<RectTransform>().position = Vector3.zero;
    }

}
