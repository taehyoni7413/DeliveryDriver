using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    public void Quit()
    {      
            Application.Quit();
    }
    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Title");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
}
