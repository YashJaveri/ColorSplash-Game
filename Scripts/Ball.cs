using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Ball : MonoBehaviour {
    
    public bool HasSameColor;
    public Color ColorBall;
    public Color ColorPlate;
    public Splatter Splatter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit;
        Debug.DrawRay(transform.position, -transform.up * 200, Color.red);
        hit = Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y-1,transform.position.z), -transform.up, 200);
        
        if (hit)
        {
            var colorPlate = hit.transform.GetComponent<SpriteRenderer>().color;
            var color1 = new Color(colorPlate.r, colorPlate.g, colorPlate.b);
            var colorBall = transform.GetComponent<SpriteRenderer>().color;
            var color2 = new Color(ColorBall.r, ColorBall.g, ColorBall.b);
            ColorBall = colorBall;
            ColorPlate = colorPlate;
            if (colorPlate == ColorBall)
            {
                HasSameColor = true;
            }
            else
            {
                HasSameColor = false;
            }
            if(hit.transform.tag == "Plate" && HasSameColor == true)
            {
                Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), hit.collider);
                var dist = Vector2.Distance(transform.position, hit.transform.position);

                if(dist == 0)
                {
                    ScoreManager.Instance.AddScore(1);
                }
            }
        }
        
        //}
        
	}
    public void DestroyBall()
    {
        
            SplateColor();
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(1);
            SoundManager.Instance.PlaySound(SoundManager.Instance.Destroysound);
        if (HasSameColor)
        { PlayerController.Instance.GameOver(); }
    }
    public void SplateColor()
    {
        Splatter splatterObj = (Splatter)Instantiate(Splatter,transform.position, Quaternion.identity);
        splatterObj.GetComponent<Splatter>().splatColor = ColorBall;
        splatterObj.GetComponent<Splatter>().randomColor = false;
        splatterObj.GetComponent<Splatter>().ApplyStyle();
    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if (!HasSameColor)
        {
            PlayerController.Instance.GameOver();
        }
        
    }
   
}
