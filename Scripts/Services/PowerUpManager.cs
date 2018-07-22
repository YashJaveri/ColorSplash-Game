using UnityEngine;
using System;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    public static int PowerUp { get; private set; }
    public static event Action<int> CoinsUpdated = delegate {};
    [SerializeField]
    int INITIAL_PowerUp = 0;
    const string Powerup = "POWERUP";   
    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Reset();
       
    }
    void Update()
    {
       
    }
    public void Reset()
    {
        // Initialize coins
        PowerUp = PlayerPrefs.GetInt(Powerup, INITIAL_PowerUp);
       
    }

    public void AddCoins(int amount)
    {
        PowerUp += amount;

//        Debug.Log("Coins: " + Coins + ", was increased by: " + amount);

        // Store new coin value
        PlayerPrefs.SetInt(Powerup, PowerUp);

        // Fire event
        CoinsUpdated(PowerUp);
    }
   
    public void RemoveCoins(int amount)
    {
        PowerUp -= amount;

//        Debug.Log("Coins: " + Coins + ", was decreased by: " + amount);

        // Store new coin value
        PlayerPrefs.SetInt(Powerup, PowerUp);

        // Fire event
        CoinsUpdated(PowerUp);
    }
   
}
