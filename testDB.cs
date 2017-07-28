using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;

public class testDB : MonoBehaviour
{
    public string path;

    public DB cuv;

    public Text[] txt;

    private void Awake()
    {
        //readDB();

        if (Application.platform == RuntimePlatform.Android)
            path = Application.persistentDataPath + "/testDB";

        else
            path = Application.dataPath + "/StreamingAssets/_XML/testDB";

        txt[0].text = Application.persistentDataPath;
        txt[1].text = Application.dataPath;

        Debug.Log(Application.persistentDataPath);

        //afisCuv();
    }

    public void createDB()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DB));
        FileStream stream = new FileStream(path, FileMode.Create);

        serializer.Serialize(stream, cuv);

        stream.Close();

        Debug.Log("Fisier db test creeat!");
    }

    public void readDB()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DB));
        FileStream stream = new FileStream(path, FileMode.Open);

        cuv = serializer.Deserialize(stream) as DB;

        stream.Close();

        Debug.Log("Citire finalizata!");
    }


    public void afisCuv()
    {

        int i = 0;

        foreach(Text t in txt)
        {
            t.text = cuv.list[i].cuv1;
            i++;
        }
    }


}

[System.Serializable]
public class DBItem
{
    public string cuv1;
    public int nr1;
}

[System.Serializable]
public class DB
{
    public List<DBItem> list = new List<DBItem>();
}
