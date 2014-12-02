using UnityEngine;
using System.Collections;

public class gameov : MonoBehaviour {
	
	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	public Texture2D back;
	public Font font;
	public GUISkin mystyle;
	string score1,LeftCount,RightCount,DownCount,UpCount,score,time;
	float average;
	float totalPlayedTime = 1.0f;
	public Texture gameover;
	public GUIStyle style;
	string scoreSetURL = "http://localhost/setscore.php";
	string label ="Second Scene";
	private bool showLabel = true;
	public GameObject[] OldValues;
	
	string fetch_url= "http://127.0.0.1/previousscore.php";
	public static int[] previous_score = new int[ 6 ];
	//string label = "";
	
	
	void Start () {
		LeftCount=playermovement1.LeftCount.ToString();
		RightCount=playermovement1.RightCount.ToString();
		UpCount=playermovement1.UpCount.ToString();
		DownCount=playermovement1.DownCount.ToString();
		score = PickUpScript.count.ToString ();
		totalPlayedTime = playermovement1.hrs*60 + playermovement1.min;
		average = (playermovement1.LeftCount + playermovement1.RightCount + playermovement1.UpCount + playermovement1.DownCount)/(totalPlayedTime+1);
		
		StartCoroutine( HandleFetch ());
		StartCoroutine(SetScore());
		//HandleFetch ();
		//SetScore ();
		//Histogram ();
		
	}
	void Histogram()
	{
		
		float val,pl,pr,pu,pd,ps,pt;
		pl = System.Convert.ToSingle (playermovement1.LeftCount);
		pr = System.Convert.ToSingle (playermovement1.RightCount);
		pu = System.Convert.ToSingle (playermovement1.UpCount);
		pd = System.Convert.ToSingle (playermovement1.DownCount);
		ps = System.Convert.ToSingle (PickUpScript.count);
		float Prev0, Prev1, Prev2, Prev3, Prev4, Prev5;
		Prev0 = System.Convert.ToSingle (previous_score [0]);
		Prev1 = System.Convert.ToSingle (previous_score [1]);
		Prev2 = System.Convert.ToSingle (previous_score [2]);
		Prev3 = System.Convert.ToSingle (previous_score [3]);
		Prev4 = System.Convert.ToSingle (previous_score [4]);
		Prev5 = System.Convert.ToSingle (previous_score [5]);
		
		//pt = System.Convert.ToSingle (playermovement1.LeftCount);
		for(int i=0;i<6;i++)
		{
			
			Debug.Log(" histogran score i=" + previous_score[i]);
		}
		
		val=(Prev0/(Prev0+pl+1))*8.0f;
		Debug.Log (playermovement1.LeftCount);
		//Debug.Log (playermovement1.LeftCount);
		//val = 2;
		Debug.Log ("left" + val);
		OldValues [0].gameObject.transform.position = new Vector3 (OldValues [0].gameObject.transform.position.x, OldValues [0].gameObject.transform.position.y + val, OldValues [0].gameObject.transform.position.z);
		
		val=(Prev1/(Prev1+pr+1))*8;
		Debug.Log ("right" + val);
		OldValues [1].gameObject.transform.position = new Vector3 (OldValues [1].gameObject.transform.position.x, OldValues [1].gameObject.transform.position.y + val, OldValues [1].gameObject.transform.position.z);
		
		val=(Prev2/(Prev2+pu+1))*8;
		Debug.Log ("up" + val);
		OldValues [2].gameObject.transform.position = new Vector3 (OldValues [2].gameObject.transform.position.x, OldValues [2].gameObject.transform.position.y + val, OldValues [2].gameObject.transform.position.z);
		
		val=(Prev3/(Prev3+pd+1))*8;
		Debug.Log ("down" + val);
		OldValues [3].gameObject.transform.position = new Vector3 (OldValues [3].gameObject.transform.position.x, OldValues [3].gameObject.transform.position.y + val, OldValues [3].gameObject.transform.position.z);
		
		val=(Prev4/(Prev4+ps+1))*8;
		Debug.Log ("score" + val);
		OldValues [4].gameObject.transform.position = new Vector3 (OldValues [4].gameObject.transform.position.x, OldValues [4].gameObject.transform.position.y + val, OldValues [4].gameObject.transform.position.z);
		
	}
	
	
	public static void call()
	{
		//StartCoroutine( HandleFetch ());
		//StartCoroutine(SetScore());
		
	}
	public void ToggleLabel() {
		showLabel = !showLabel;
	}
	
	void Update()
	{
		
		//	Debug.Log(DelegateMenu.lev);
		if (DelegateMenu.lev == 1){
			score1 = playermovement.score.ToString ();
		} else if (DelegateMenu.lev == 2) {
			LeftCount=playermovement1.LeftCount.ToString();
			RightCount=playermovement1.RightCount.ToString();
			UpCount=playermovement1.UpCount.ToString();
			DownCount=playermovement1.DownCount.ToString();
			score = PickUpScript.count.ToString ();
			totalPlayedTime = playermovement1.hrs*60 + playermovement1.min;
			average = (playermovement1.LeftCount + playermovement1.RightCount + playermovement1.UpCount + playermovement1.DownCount)/totalPlayedTime;
		} else if (DelegateMenu.lev == 3) {
			score1 = playermovement2.score.ToString ();
		} else if (DelegateMenu.lev == 4) {
			score1 = playermovement3.score.ToString ();
		}
	}
	
	IEnumerator HandleFetch()
		
	{
		string username = hscontroller.username;
		string fetch_URL = fetch_url + "?username=" + username;
		
		//string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;
		//Debug.Log (register_URL);
		WWW fetchReader = new WWW(fetch_URL);
		yield return fetchReader;
		
		
		if(fetchReader.error != null)
		{
			Debug.Log (fetchReader.error);
			label = "could not locate page";
			
		}else {
			
			Debug.Log(fetchReader.text);
			IList temp = fetchReader.text.Split(' ');
			for(int i=0;i<6;i++)
			{
				previous_score[i] = System.Convert.ToInt32(temp[i]);
				Debug.Log(" previoius score i=" + previous_score[i]);
			}
			//previous_score[4] = System.Convert.ToInt32(temp[4]); // converting avergae
		}
		Histogram ();
	}
	
	
	IEnumerator SetScore()
	{
		
		string username = hscontroller.username;
		//int left = ParamScript.left;
		//int right = ParamScript.right;
		//int top = ParamScript.top;
		//int bottom = ParamScript.bottom;
		//float average = (left + right + top + bottom) / 4;
		scoreSetURL = scoreSetURL + "?username=" + username + "&left=" + LeftCount + "&right="+ RightCount
			+"&up="+ UpCount + "&down="+ DownCount + "&average="+average + "&score=" +score + "&timeplayed="
				+totalPlayedTime;
		
		//string register_URL = register_url + "?username=" + userNamez + "&password=" + passWordz;
		Debug.Log (scoreSetURL);
		WWW ScoreReader = new WWW(scoreSetURL);
		yield return ScoreReader;
		
		
		if(ScoreReader.error != null)
		{
			label = "could not locate page";
			Debug.Log (ScoreReader.error);
		}else {
			if(ScoreReader.text == "updated")
			{
				label ="Score Updated to database";
				Invoke("ToggleLabel", 2);
			}else 
			{
				label = "didnotupdate";
			}
			
		}
	}
	
	
	
	void OnGUI(){
		
		//GUI.Label (new Rect (100, 10, 100, 20), label);
		Invoke("ToggleLabel", 2);
		if (showLabel) {
			GUI.Label (new Rect (10, 10, 100, 20), label);
		}
		
		//GUI.Label (new Rect(150, -200, screenWidth, screenHeight),gameover);
		GUI.skin = mystyle;
		GUI.skin.box.normal.background = back;
		GUI.skin.font = font;
		//	GUI.Box (new Rect (0, 0, 1400, 700), "");
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		buttonHeight = screenHeight * 0.3f;
		buttonWidth = screenWidth * 0.4f;
		
		//GUI.Label (new Rect (screenWidth * 0.35f, screenHeight * 0.25f, screenWidth * 0.5f, screenHeight * 0.2f), "GAME OVER");
		GUI.Label(new Rect (screenWidth * 0.68f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f), "Score:",style);
		GUI.Label(new Rect(screenWidth * 0.75f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f),score,style);
		
		//junaid
		GUI.Label(new Rect (screenWidth * 0.22f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f), "Left:",style);
		GUI.Label(new Rect(screenWidth * 0.27f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f),LeftCount,style);
		
		GUI.Label(new Rect (screenWidth * 0.33f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f), "Right:",style);
		GUI.Label(new Rect(screenWidth * 0.4f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f),RightCount,style);
		
		GUI.Label(new Rect (screenWidth * 0.45f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f), "Up:",style);
		GUI.Label(new Rect(screenWidth * 0.49f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f),UpCount,style);
		
		GUI.Label(new Rect (screenWidth * 0.54f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f), "Down:",style);
		GUI.Label(new Rect(screenWidth * 0.61f, screenHeight * 0.2f, screenWidth * 0.5f, screenHeight * 0.2f),DownCount,style);
		
		
		//junaid
		
		if (GUI.Button (new Rect (screenWidth * 0.85f, screenHeight * 0.05f, screenWidth * 0.11f, screenHeight * 0.05f), "Play Again")) {
			Application.LoadLevel ("start");
		}
		if (GUI.Button (new Rect (screenWidth * 0.85f, screenHeight * 0.1f, screenWidth * 0.11f, screenHeight * 0.05f), "High Score")) {
			Application.LoadLevel("HS");
		}
		if (GUI.Button (new Rect (screenWidth * 0.85f, screenHeight * 0.15f, screenWidth * 0.11f, screenHeight * 0.05f), "QUIT")) {
			Application.Quit ();
		}
		//GUI.Button (new Rect (120, 120, 80, 40), "S.NO.");
		//GUI.Button (new Rect (210, 120, 150, 40), "Playername");
	}
}
