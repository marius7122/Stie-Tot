using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class libInstanceManager : MonoBehaviour {

    public GameObject FSInfo;

    public Items DB;
    public GameObject itemPrefab;

    private void Awake()
    {
        ReadXmlFile();
        instantiateItems();

        StartCoroutine(fixUnityBug("Viewport"));
    }


    void ReadXmlFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Items));

        TextAsset XmlText = (TextAsset)Resources.Load("infoDB");

        StringReader reader = new StringReader(XmlText.text);

        DB = serializer.Deserialize(reader) as Items;
    }

    void instantiateItems()
    {
        foreach(Item i in DB.list)
        {
            GameObject x = Instantiate(itemPrefab);

            x.transform.parent = gameObject.transform;

            itemButtonScript scr = x.GetComponent<itemButtonScript>();

            scr.myItem = i;
            scr.FSInfo = FSInfo;
        }
    }

    public static IEnumerator fixUnityBug(string toFind)
    {
        GameObject x = GameObject.Find(toFind);

        RectTransform R;
        R = x.GetComponent<RectTransform>();
        yield return new WaitForEndOfFrame();
        R.sizeDelta = new Vector2(R.sizeDelta.x - 0.1f, R.sizeDelta.y);
    }


}
