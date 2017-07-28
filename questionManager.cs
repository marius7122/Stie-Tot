using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;

public class questionManager : MonoBehaviour {

    public Text intrebare;

    public GameObject end;

    //raspunsurile posibile
    public Text[] r;
    public Button[] b = new Button[4];
    public Image[] bImg = new Image[4];

    public GameObject verificaButon;
    public GameObject nextButon;

    //intrebarile
    public List<question> q = new List<question>();

    public question actQ;

    public int selected = -1;

    public int points;
    private bool[] viz = new bool[100];
    private int nrIntrebari = 15;
    public int nrIntrebariPuse = 0;
    public Color pressed;
    public Color relased;

    private void Awake()
    {
        readXmlFile();

        loadNext();

    }

    void readXmlFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<question>));

        TextAsset XmlText = (TextAsset)Resources.Load("intrebari");

        StringReader reader = new StringReader(XmlText.text);

        q = serializer.Deserialize(reader) as List<question>;
    }

    public void verifica()
    {

        if(selected != -1)
        {
            colorButton(actQ.corect - 1, Color.green);

            if (selected == actQ.corect - 1)
                points++;

            else
                colorButton(selected, Color.red);

            verificaButon.SetActive(false);

            nextButon.SetActive(true);
        }


        selected = -1;
    }

    public void loadNext()
    {
        Debug.Log("urmatorul!!!");

        nrIntrebariPuse++;

        if(nrIntrebariPuse == 11)
        {
            loadFinal();
            return;
        }

        int next = (int)Random.Range(0, nrIntrebari);

        while (viz[next] == true)
            next = (int)Random.Range(0, nrIntrebari);

        Debug.Log(next);

        actQ = q[next];

        viz[next] = true;

        loadQ();
    }

    void loadQ()
    {
        ResetButtons();

        intrebare.text = actQ.q;

        r[0].text = actQ.r1;
        r[1].text = actQ.r2;
        r[2].text = actQ.r3;
        r[3].text = actQ.r4;
    }

    void loadFinal()
    {

        end.SetActive(true);

        GameObject.Find("text final").GetComponent<Text>().text = "Felicitari! Ai obtinut " + points + " puncte din 10";

        gameObject.SetActive(false);
    }

    public void markButtonAsPressed(int but)
    {
        ResetButtons();

        bImg[but].color = pressed;

    }

    public void ResetButtons()
    {
        for (int i = 0; i < 4; i++)
            bImg[i].color = relased;
    }

    void colorButton(int index, Color col)
    {
        bImg[index].color = col;
    }

    public void setSelected(int i)
    {
        selected = i;
    }

}

[System.Serializable]
public class question
{
    public string q;

    public string r1, r2, r3, r4;

    public int corect;
}
