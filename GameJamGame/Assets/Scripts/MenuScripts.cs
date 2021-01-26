using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void instructionPage()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void toCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
