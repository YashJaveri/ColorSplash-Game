using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Text HighestScore;
    public Text ScoreTextIngame;
    public Text ScoreTextGameOver;
    public Text PowerUpsStartScreen;
    public Text PowerUpInGameScreen;
    public Text PowerUpGameOverScreen;
    public Button SoundOn;
    public Button SoundOff;
    public Button MusicOn;
    public Button MusicOff;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HighestScore.text = "Highest Score:" + "\n\r" + ScoreManager.Instance.HighScore.ToString();
        ScoreTextIngame.text =   ScoreManager.Instance.Score.ToString();
        ScoreTextGameOver.text = "Score:" + "\n\r" + ScoreManager.Instance.Score.ToString();
        PowerUpsStartScreen.text =  PowerUpManager.PowerUp.ToString();
        PowerUpInGameScreen.text =  PowerUpManager.PowerUp.ToString();
        PowerUpGameOverScreen.text = PowerUpManager.PowerUp.ToString();
        
        if(SoundManager.Instance.GetSoundMutestatus() == true)
        {
            SoundOn.gameObject.SetActive(false);
            SoundOff.gameObject.SetActive(true);
        }
        else
        {
            SoundOn.gameObject.SetActive(true);
            SoundOff.gameObject.SetActive(false);
        }
        if (SoundManager.Instance.GetMusicStatus() == true)
        {
            MusicOn.gameObject.SetActive(false);
            MusicOff.gameObject.SetActive(true);
        }
        else
        {
            MusicOn.gameObject.SetActive(true);
            MusicOff.gameObject.SetActive(false);
        }
    }
   public void SetMuteSound()
    {
        SoundManager.Instance.ToggleSound();
    }
   public void SetMuteMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }
   public void PlayClickSound()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.ClickSound);
    }
    public void ShowRewardedAd()
    {
        UnityAdHandler.Instance.VideoAd();
    }
}
