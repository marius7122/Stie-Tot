using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalButtonManager : MonoBehaviour {

    /*private void OnLevelWasLoaded(int level)
    {
        if(level == 0)  //main menu
        {
            //StartCoroutine(libInstanceManager.fixUnityBug("background"));

            //Debug.Log("level 0 la putere");

        }
    }*/

    public void loadMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void loadRecognitionScene()
    {
        Application.LoadLevel(1);
    }

    public void loadLibrary()
    {
        Application.LoadLevel(2);
    }

    public void LoadQuiz()
    {
        Application.LoadLevel(3);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void setScrollAtBeginning(RectTransform content)
    {
        content.position = Vector3.zero;
    }
}
