using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
public class UnityAdHandler : MonoBehaviour {
    public static UnityAdHandler Instance;
    public int reward = 5;
    public string test = "";
    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1286596");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
 
   
   public void VideoAd()
    {
        ShowOptions option = new ShowOptions();
        option.resultCallback = VideoAdCallback;
        if (Advertisement.IsReady("rewardedVideo") && Advertisement.isShowing == false)
        {
            Advertisement.Show("rewardedVideo",option);
        }
        else
        {
            MessageBox.Instance.showMessage("Connection failed");
        }
    }
    void VideoAdCallback(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:

                MessageBox.Instance.showMessage("Failed to load Ad");
                break;
            case ShowResult.Skipped:
                test = "Skipped";
               
                break;
            case ShowResult.Finished:
                MessageBox.Instance.showMessage("+" + reward.ToString());
                PowerUpManager.Instance.AddCoins(reward);
                break;
        }
    }
   
}
