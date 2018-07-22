using UnityEngine;
using System.Collections;
using System.IO;

public class SocialFollow : MonoBehaviour {
    
    private string Facebook = "https://www.facebook.com/clockpulsegames";
    private string Instagram= "https://www.instagram.com/clockpulsegames";
    private string Twitter = "https://twitter.com/clockpulsegames";
    private string Rate = "https://play.google.com/store/apps/details?id=com.ingenious.infiniteturns";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void FollowFacebook()
    {
        Application.OpenURL(Facebook);
    }
   public void FollowInstagram()
    {
        Application.OpenURL(Instagram);
    }
   public void FollowTwitter()
    {
        Application.OpenURL(Twitter);
    }
    public void RateApp()
    {

        Application.OpenURL(Rate);
       
        
    }
}
