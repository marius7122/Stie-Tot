using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;

public class historyManager : MonoBehaviour {

    public string path;

    public string buff;
    public bool[] gasit;        //gasit[i] == true daca am gasit targetul cu indexul i

    private int buffPoz;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
            path = Application.persistentDataPath + "/istoric";

        else
            path = Application.dataPath + "/data/istoric.txt";
    }


    void readFile()
    {
        StreamReader fin = new StreamReader(path, Encoding.Default);
        

        if(!File.Exists(path))
        {
            Debug.Log("se creeaza fisier");

            File.WriteAllText(path, " ");
        }

        else
        {
            buff = fin.ReadToEnd();

            Debug.Log("gasit in fisier: " + buff);

            while (parsare()) ;
        }

        fin.Close();
    }

    private int buff_poz = 0;
    bool parsare()
    {
        int x = 0;

        while (buff[buff_poz] != 0 && (buff[buff_poz] < '0' || buff[buff_poz] > '9'))
            buff_poz++;

        if (buff[buff_poz] == 0)
            return false;

        while(buff[buff_poz] <= '9' && buff[buff_poz] >= '0')
        {
            x = x * 10 + buff[buff_poz] - '0';
            buff_poz++;
        }

        Debug.Log(x);

        if (buff[buff_poz] == 0)
            return false;

        return true;
    }

}
