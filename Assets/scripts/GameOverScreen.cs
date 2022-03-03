using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class GameOverScreen : MonoBehaviour
{
    public DBManager db;
    public GameObject inputField;
    public Text pointText;
    public Answer ans;
        
    public void Setup(int score)
    {
        string test = ans.score.ToString();
        gameObject.SetActive(true);
        pointText.text = "Score: " + test;
        string name = inputField.GetComponent<Text>().text;
        Debug.Log(name);
        Debug.Log(test);
        db = GameObject.Find("DBManager").GetComponent<DBManager>();
        if (db)
        {
            db.writeNewUser(name, test);
        }
        else
        {
            Debug.Log("Error");
        }
    }

    public void btnRestart()
    {
        SceneManager.LoadScene("simple");
    }
    public void btnExit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
