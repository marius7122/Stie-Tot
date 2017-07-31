using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;

public class questionManager : MonoBehaviour {

    public Text intrebare;

    //UI pentru ecranul de sfarsit
    public GameObject end;
    //UI pentru intrebari
    public GameObject intrebari;

    //raspunsurile posibile
    [Header("Cele 4 variante de raspuns ariantele de raspunsuri")]
    public Text[] r;
    public Button[] b = new Button[4];
    public Image[] bImg = new Image[4];

    [Header("Butoanele verifica, next")]
    public GameObject verificaButon;
    public GameObject nextButon;

    //intrebarile
    [Header("Lista de intrebari")]
    public List<question> q = new List<question>();

    //[Header("Intrebarea Actuala")]
    private question actQ;

    private int selected = -1;  //care varianta de raspuns a fost selectata

    private int points;         //numarul de puncte acumulate
    //private bool[] viz = new bool[100];     //daca s-a pus intrebarea i => viz[i] = true
    private int nrIntrebari = 16;           //cate antrebari sunt
    private int nrIntrebariDePus = 10;
    private int nrIntrebariPuse = 0;         //cate intrebari s-au pus
    private int[] order;

    //culorile pentru butoane: apasat, liber, raspunsul corect, raspuns gresit
    [Header("Culorile pentru butoane")]
    public Color pressed;
    public Color relased;
    public Color corectCol;
    public Color gresitCol;
    public Color blinkColor;

    private void Awake()
    {
        readXmlFile();

        loadNext();

        setShuffleOrder();

    }


    //citeste fisierul XML cu intrebarile
    void readXmlFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<question>));

        TextAsset XmlText = (TextAsset)Resources.Load("intrebari");

        StringReader reader = new StringReader(XmlText.text);

        q = serializer.Deserialize(reader) as List<question>;

        //Debug.Log("numar de intrebari = " + q.Count);

    }

    public void verifica()
    {
        //Debug.Log("verifica!");

        StartCoroutine(blinkAndCheck());
    }

    IEnumerator blinkAndCheck()
    {
        if (selected != -1)
        {
            yield return StartCoroutine(blink());

            colorButton(actQ.corect - 1, corectCol);

            if (selected == actQ.corect - 1)
                points++;

            else
                colorButton(selected, gresitCol);

            verificaButon.SetActive(false);

            nextButon.SetActive(true);
        }


        selected = -1;
    }

    IEnumerator blink()
    {
        int selectedButton = selected;

        //Debug.Log("selected = " + selected);

        float blinkTime = 0.4f;

        for (int i = 0; i < 3; i++)
        {
            //Debug.Log("blink");

            bImg[selectedButton].color = blinkColor;
            yield return new WaitForSeconds(blinkTime);

            bImg[selectedButton].color = pressed;
            yield return new WaitForSeconds(blinkTime);
        }

        yield return new WaitForSeconds(blinkTime);

    }
    
    //cauta intrebarea urmatoare
    public void loadNext()
    {
        if (nrIntrebariPuse == 0)
            setShuffleOrder();
        
        if(nrIntrebariPuse == nrIntrebariDePus)
        {
            loadFinal();
            return;
        }

        nrIntrebariPuse++;


        int next = order[nrIntrebariPuse];


        actQ = q[next];

        loadQ();
    }
    
    void setShuffleOrder()
    {
        order = new int[nrIntrebari + 2];

        for (int i = 1; i <= nrIntrebari; i++)
            order[i] = i;

        for (int i = 1; i <= nrIntrebari; i++)
        {
            int sch = (int)Random.RandomRange(1, nrIntrebari - i + 1);

            int aux = order[sch];
            order[sch] = order[nrIntrebari - i + 1];
            order[nrIntrebari - i + 1] = aux;

        }
        
    }

    //incarca intrebarea urmatoare
    void loadQ()
    {
        ResetButtons();

        intrebare.text = actQ.q;

        r[0].text = actQ.r1;
        r[1].text = actQ.r2;
        r[2].text = actQ.r3;
        r[3].text = actQ.r4;
    }

    //incarca ecranul final (dupa ce toate intrebarile au fost puse)
    void loadFinal()
    {
        intrebari.SetActive(false);
        end.SetActive(true);

        GameObject.Find("text final").GetComponent<Text>().text = "Felicitari! Ai obtinut " + points + " puncte din " + nrIntrebariDePus;

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
