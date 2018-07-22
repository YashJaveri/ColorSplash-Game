using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MessageBox : MonoBehaviour {
    public static MessageBox Instance;
    public GameObject messageBox;
    public Text MessageText;
    public Button CloseButton;
    public float ClosingTime = 1;
    void Awake()
    {
        Instance = this;
    }
    public  void showMessage(string Message,string ButtonText)
    {
        messageBox.SetActive(true);
        MessageText.text = Message;
        CloseButton.gameObject.SetActive(true);
        CloseButton.GetComponentInChildren<Text>().text = ButtonText;
        CloseButton.onClick.RemoveAllListeners();
        CloseButton.onClick.AddListener(()=> Close());
        ClosingTime = 1;
    }
    public void showMessage(string Message)
    {
        messageBox.SetActive(true);
        MessageText.text = Message;
        CloseButton.gameObject.SetActive(false);
        ClosingTime = 1;
        StartCoroutine(CloseSlowly());
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Close()
    {
        messageBox.SetActive(false);
        CloseButton.image.CrossFadeAlpha(255, 0.1f, true);
    }
    IEnumerator CloseSlowly()
    {
        CloseButton.image.CrossFadeAlpha(0, 1, true);
        while(ClosingTime > 0)
        {
            ClosingTime -= Time.deltaTime;
            CloseButton.enabled = true;
            if(ClosingTime < 0)
            {
                Close();
            }
            yield return null;
        }
        
        yield return new WaitForFixedUpdate();
    }
}
