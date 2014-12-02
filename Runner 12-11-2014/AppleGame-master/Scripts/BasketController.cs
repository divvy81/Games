using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	// Use this for initialization
	public int Score;
	public float Speed;
	//public GUIText scoreText;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("left"))
		{
			transform.position = Vector2.Lerp(transform.position, (new Vector2(-11.0f,this.transform.position.y)), Speed);
			//this.transform.position=  new Vector2(-11.0f,this.transform.position.y);
		}
		if(Input.GetKeyDown("right"))
			//this.transform.position= new Vector2(9.0f,this.transform.position.y);
			transform.position = Vector2.Lerp(transform.position, (new Vector2(9.0f,this.transform.position.y)), Speed);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if(Input.GetKeyDown("space"))
		{
			Destroy(other.gameObject);
			Score=Score + 2;
	//		scoreText.text = "Score: " + Score;
		}
		//Score--;

	}


}
