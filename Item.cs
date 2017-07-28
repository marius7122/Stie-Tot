using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//clasa pentru informatiile despre fiecare opera detectabila
[System.Serializable]
public class Item
{
    public string titlu;

    public string an;

    public string autor;

    public string detalii;
}

[System.Serializable]
public class Items
{
    public List<Item> list = new List<Item>();
}
