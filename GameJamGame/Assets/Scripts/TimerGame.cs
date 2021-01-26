using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerGame : MonoBehaviour
{
    private float timeLeft = 15f;
    public GameObject timeRemainingUI;
    // Start is called before the first frame update
    void Start()
    {
        timeRemainingUI = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //timeRemainingUI.gameObject.GetComponent<Text>().text = ("Time Left : " + (int)timeLeft);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Passive");
        }
    }
}
