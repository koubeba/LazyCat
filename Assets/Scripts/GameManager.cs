using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public enum state { menu, paused, score, ingame };

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public static int points, lives;
    public static bool scored;

    //public GameObject ScoreBG, Canvas, MenuButtons, PointsText, Lives;
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    List<Transform> UIElements;

    public Text ScoreText;

    public static float leftx, middlex, rightx;
    
    public static state gameState;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        

        //Assign left, middle and right positions relating to screen size.
        leftx = (Screen.width / 4f);
        middlex = Screen.width / 2f;
        rightx = 3f * (Screen.width / 4f);
    }

	void Start () {
        canvas = GetComponentInChildren<Canvas>();
        //Get children of canvas. We have to do it this way in order to get only children of first depth
        UIElements = canvas.GetComponentsInChildren<Transform>(true).Where(n => n.parent.name == "Canvas").ToList();
        
         
        points = 0;
        lives = 3;
    }

	void Update () {
        switch (GameManager.gameState)
        {
            case state.menu:
                Time.timeScale = 1f;
                lives = 3;
                points = 0;
                DisableAllExpect(new string[] { "MenuButtons"});
            //    //Canvas.SetActive(true);
            //    ScoreBG.SetActive(false);
            //    MenuButtons.SetActive(true);
            //    PointsText.SetActive(false);
            //    Lives.SetActive(false);
                break;
            case state.paused:
                Time.timeScale = 0f;
                DisableAllExpect(new string[] { "StartGamePopUp" });
            //    //Canvas.SetActive(true);
            //    ScoreBG.SetActive(false);
            //    MenuButtons.SetActive(false);
            //    PointsText.SetActive(false);
            //    Lives.SetActive(false);
                break;
            case state.score:
                Time.timeScale = 0f;
                DisableAllExpect(new string[] { "ScoreBG"});
            //    //Canvas.SetActive(true);
            //    ScoreBG.SetActive(true);
            //    MenuButtons.SetActive(false);
            //    PointsText.SetActive(false);
            //    Lives.SetActive(false);
                ScoreText.text = "Your Score: " + points;
                break;
            case state.ingame:
                Time.timeScale = 1f;
                DisableAllExpect(new string[] { "PointsCounter", "Lives"});
            //    //Canvas.SetActive(true);
            //    ScoreBG.SetActive(false);
            //    MenuButtons.SetActive(false);
            //    PointsText.SetActive(true);
            //    Lives.SetActive(true);
               break;
        }
        if ((gameState == state.ingame || gameState == state.paused) && Input.GetKeyDown(KeyCode.Escape)) gameState = (gameState == state.paused) ? state.ingame : state.paused;

        if (lives <= 0) gameState = state.score;
	}

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
        points = 0;
        lives = 3;
        //ScoreBG.SetActive(false);
        gameState = state.ingame;
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(2);
        gameState = state.menu;
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene(3);
        gameState = state.menu;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        gameState = state.menu;
    }
    public void Exit()
    {
        Application.Quit();
    }

    void DisableAllExpect(string[] names)
    {
        foreach(Transform o in UIElements)
        {
            bool isIn = false;
            foreach (string name in names)
                if (o.name == name) isIn = true;
            if (isIn) o.gameObject.SetActive(true);
            else o.gameObject.SetActive(false);
        }
    }

}
