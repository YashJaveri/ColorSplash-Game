using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public  bool IsGameOver;
    public  bool HasGameStarted;
    private GameObject CurrentMenu;
    public GameObject GameOverScreen;
    public GameObject StartMenu;
    public GameObject InGameMenu;
    private Vector2 pos;
    public float PowerUpTime = 2.0f;
    // Use this for initialization
    void Awake()
    {
        SetMenu(StartMenu);
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Application.isEditor == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                var ht = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(pos),0.6f);
                if (ht)
                {
                    if (ht.GetComponent<Ball>() != null)
                    {

                        ht.GetComponent<Ball>().DestroyBall();

                    }

                }
            }
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                pos = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
                var ht = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
                if (ht)
                {
                    if (ht.GetComponent<Ball>() != null)
                    {

                        ht.GetComponent<Ball>().DestroyBall();

                    }

                }
            }
        }
           

           
        
    }
    public void StartGame()
    {
        HasGameStarted = true;
        SetMenu(InGameMenu);
        GameController.Instance.SetPlateColors();
        AdTimer.GamesPlayed += 1;
    }
  public void GameOver()
    {
        IsGameOver = true;
        SetMenu(GameOverScreen);
        Time.timeScale = 1f;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreManager.Instance.Reset();
    }
    public void SetMenu(GameObject menu)
    {
        if(CurrentMenu == null)
        {
            CurrentMenu = menu;
        }
        else
        {
            CurrentMenu.SetActive(false);
            CurrentMenu = menu;
        }
        menu.SetActive(true);
    }
    public void UsePower()
    {
        if (PowerUpManager.PowerUp > 0)
        {
            StartCoroutine(PowerI());
            PowerUpManager.Instance.RemoveCoins(1);
        }
    }
    public IEnumerator PowerI()
    {
        if (!IsGameOver)
        {
            Time.timeScale = 0.5f;

            yield return new WaitForSeconds(PowerUpTime);
            Time.timeScale = 1f;
        }
    }
}
