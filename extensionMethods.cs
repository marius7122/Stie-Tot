using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//metode ajutatoare
public static class extensionMethods
{

    //seteaza pozitia pentru UI
    public static void setPosition(Vector3 poz, Vector3 size, GameObject obj)
    {
        float dist = 0.2f;  //distanta dintre obiect si interfata grafica

        float lungime = size.x;

        Vector3 finalPosition;

        finalPosition = poz - new Vector3(lungime/2 + dist, 0f, 0f);  //pozitionam la marginea din stanga

        finalPosition -= new Vector3(0f, 0f, 5f); //scad inaltimea UI / 2 pentru a centra

        obj.transform.position = finalPosition;
    }

    //returneaza pozitia unde se gaseste item-ul cu titlul name
    public static int getIndexFromName(string name)
    {
        int sol = -1;

        switch (name)
        {
            case "Gioconda": sol = 0; break;
            case "Carul cu boi": sol = 1; break;
            case "Cina cea de taina": sol = 2; break;
            case "Noapte Instelata": sol = 3; break;
            case "Femeie Plangand": sol = 4; break;
        }

        return sol;
    }


}
