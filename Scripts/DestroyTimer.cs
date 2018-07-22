using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
   public float Time;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, Time);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
