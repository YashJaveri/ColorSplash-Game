using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AdTimer : MonoBehaviour {
    public static int GamesPlayed;
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	if(GamesPlayed == 5 && PlayerController.Instance.IsGameOver == true && SceneManager.GetActiveScene().name == "Main")
        {
            AdvertisementAdmob.Instance.ShowInterstitial();
            GamesPlayed = 0;
        }
	}
}
