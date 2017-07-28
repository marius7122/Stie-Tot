using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugScript : MonoBehaviour {

    XMLManager mng;
    public TextAsset T;

    private void Start()
    {
        //path
        mng = GameObject.Find("XML Manager").GetComponent<XMLManager>();

        gameObject.GetComponent<Text>().text = mng.XmlPath;

        //incarca resurse
        //T = Resources.Load("fisier text important") as TextAsset;

        //gameObject.GetComponent<Text>().text = T.text;

    }

    private void Useless()
    {
        //this function does nothing, is just for testing github
    }
}
