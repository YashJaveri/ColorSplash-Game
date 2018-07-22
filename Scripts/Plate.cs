using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Plate : MonoBehaviour {
    public Color Color;
	// Use this for initialization
	void Start () {
        transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        transform.GetComponent<SpriteRenderer>().color = new Color(Color.r,Color.g,Color.b);
        
	}
}
