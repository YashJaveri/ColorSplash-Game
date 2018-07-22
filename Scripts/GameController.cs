using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public List<GameObject> SpawnPoints;
    public Ball Ball;
    public List<Color> Colours;
    public List<Plate> Plates;
    public float CurrentSpawnTime;
    public float NextSpawnTime;
    public static GameController Instance;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        CurrentSpawnTime += Time.deltaTime;
        CheckScore();
        if(CurrentSpawnTime > NextSpawnTime && PlayerController.Instance.HasGameStarted && PlayerController.Instance.IsGameOver == false)
        {
            CurrentSpawnTime = 0;
            Spawn();
        }
        
	}
    public void CheckScore()
    {
        if(ScoreManager.Instance.Score > 10 && ScoreManager.Instance.Score <= 20)
        {
            NextSpawnTime = 2.5f;
        }else if(ScoreManager.Instance.Score > 20 && ScoreManager.Instance.Score <= 40)
        {
            NextSpawnTime = 2f;
        }
        else if(ScoreManager.Instance.Score > 40 && ScoreManager.Instance.Score <= 60)
        {
            NextSpawnTime = 1.5f;
        }
        else if (ScoreManager.Instance.Score > 60 && ScoreManager.Instance.Score <= 85)
        {
            NextSpawnTime = 1f;
        }
        else if (ScoreManager.Instance.Score > 85)
        {
            NextSpawnTime = 0.4f;
        }

    } 
    public void SetPlateColors()
    {
        if (Colours.Count > 1)
        {
            ShuffleColour(Colours);
        }
        for (int i = 0; i < Colours.Count; i++)
        {
            Plates[i].GetComponent<Plate>().Color = Colours[i];
        }
    }
    public void Spawn()
    {
        var RandomSpawnPoint = Random.Range(0, SpawnPoints.Count);
        var RandomColour = Random.Range(0, Colours.Count);
        var InstantiatedBall = Instantiate(Ball.gameObject, SpawnPoints[RandomSpawnPoint].transform.position, Quaternion.identity) as GameObject;
        InstantiatedBall.GetComponent<SpriteRenderer>().color = new Color(Colours[RandomColour].r, Colours[RandomColour].g, Colours[RandomColour].b);
    }
    public static void ShuffleColour( List<Color> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
