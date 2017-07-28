using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour
{
    //linkul catre locatia fisierului xml
    public string XmlPath;

    //lista cu informatii pentru fiecare din obiectele detectabile
    public Items infoDB;


    private void Awake()
    {
        //atribui locatia fisierului xml
        XmlPath = "Assets/Resources/XML/infoDB";    //in fisierul de resurse

        /*
        if (Application.platform == RuntimePlatform.Android)
            XmlPath = Application.persistentDataPath + "/infoDB";
        else
            XmlPath = Application.dataPath + "/StreamingAssets/_XML/infoDB";*/

        ReadXmlFile();
    }

    //creeaza fisier 
    public void createXmlFile ()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Items));
        FileStream stream = new FileStream(XmlPath, FileMode.Open);

        serializer.Serialize(stream , infoDB);

        stream.Close();

        Debug.Log("fisier XML creeat!");
    }

    //citeste fisierul XML
    public void ReadXmlFile()
    {
        /*{      Citire veche
        XmlSerializer serializer = new XmlSerializer(typeof(Items));
        FileStream stream = new FileStream(XmlPath, FileMode.Open);

        infoDB = serializer.Deserialize(stream) as Items;

        stream.Close();

        Debug.Log("Citire finalizata!");
        */
        
        XmlSerializer serializer = new XmlSerializer(typeof(Items));

        TextAsset XmlText = (TextAsset) Resources.Load("infoDB");

        StringReader reader = new StringReader(XmlText.text);

        infoDB = serializer.Deserialize(reader) as Items;


        foreach (Item i in infoDB.list)
        {
            Debug.Log(i.titlu + "\n" + i.autor);
        }
    }
	
}
