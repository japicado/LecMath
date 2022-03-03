using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    [SerializeField] GameObject gameOverScreen;

    public GameOverScreen GameOverScreen;

    public GameObject[] hearts;
    private int life;
    private bool dead;

    GameObject wrong = null;
    GameObject right = null;
    float second = 0;
    bool correct = false;

    public int score;
    public Text TXTscore;

    // Use this for initialization
    void Start()
    {
        life = hearts.Length;
        wrong = (GameObject)Instantiate(Resources.Load("Wrong"));
        wrong.SetActive(false);
        right = (GameObject)Instantiate(Resources.Load("Right"));
        right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            Debug.Log("Muerto");

            gameOverScreen.SetActive(true);
        }

        second -= Time.deltaTime;

        TXTscore.text = "Score: " + score;

        if (second <= 0)
        {
            right.SetActive(false);
            wrong.SetActive(false);

            if (correct)
            {
                GameObject g = GameObject.Find("New");
                g.GetComponent<NewQuestion>().getNewQuestion();
                correct = false;
            }
        }
    }


    public void AnswerThis(int whichAnswer)
    {

        Debug.Log("Hit a button " + whichAnswer);

        GameObject g = GameObject.Find("New");
        int correctAnswer = g.GetComponent<NewQuestion>().whichAnswer;

        if (whichAnswer == correctAnswer)
        {
            Debug.Log("Correct");
            wrong.SetActive(false);
            right.SetActive(true);
            second = 2;
            correct = true;
            score++;
        }
        else
        {
            Debug.Log("Incorrect ");
            right.SetActive(false);
            wrong.SetActive(true);
            second = 2;
            correct = false;
        }

    }

    public void AnswerThis2(int f)
    {

        Debug.Log(correct);

        if (correct == false)
        {
            if (life >= 1)
            {
                life -= f;
                Destroy(hearts[life].gameObject);
                if (life < 1)
                {
                    dead = true;
                }
            }
        }


    }
}
