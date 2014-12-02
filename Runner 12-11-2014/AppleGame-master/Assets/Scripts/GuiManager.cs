using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {


	GUIStyle ScoreFont;
	public float Timer;
	float CurrentTime;
	void Start () 
	{
		ScoreFont= new GUIStyle();
		ScoreFont.fontSize=22;

		//guiText.fontStyle= FontStyle.Bold;
		CurrentTime=Timer;
	}

	void OnGUI()
	{
		string ScoreStr = GameObject.Find("Basket").GetComponent<BasketController>().Score.ToString();
		//GUI.Label(new Rect(10, 10, Screen.width, Screen.height), "Hello World!");
		GUI.Label(new Rect (Screen.width * 0.22f, Screen.height * 0.22f, Screen.width * 0.5f, Screen.height * 0.2f), "Score:"+ ScoreStr, ScoreFont);

		//if paused
		if(Time.timeScale==0)
		{
			if (GUI.Button (new Rect (Screen.width/2,Screen.height/2,80,40), "Restart"))
			{
				Application.LoadLevel(0);
				Time.timeScale=1;
			}
			if (GUI.Button (new Rect (Screen.width/2,Screen.height/2 - 40,80,40), "Quit"))
				Application.Quit();
		}

		//Screen CountDown Timer
		GUI.Label(new Rect (Screen.width * 0.5f, Screen.height * 0.2f, Screen.width * 0.5f, Screen.height * 0.2f), "Time Left :"+ CurrentTime.ToString("F0"), ScoreFont);
	}
	void Update () 
	{
	
		Debug.Log(CurrentTime);
		//Countdown Timer
		CurrentTime-=Time.deltaTime;
		if(CurrentTime<=0)
		{
			Time.timeScale=0;
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}
}
