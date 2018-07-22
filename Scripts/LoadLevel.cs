using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        SceneManager.LoadSceneAsync("Main");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
