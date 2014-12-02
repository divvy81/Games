using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float TimeInterval, InitTime;
	public GameObject Apple;
	float CurrentTime;
	// Use this for initialization
	void Start () 
	{
		CurrentTime=InitTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CurrentTime +=Time.deltaTime;
		if(CurrentTime >= TimeInterval)
		{
			CurrentTime=0;
			Instantiate( Apple,this.transform.position,Quaternion.identity);
			Debug.Log("CHANGED");
		}
		Debug.Log(CurrentTime);
		Debug.Log(TimeInterval);
	}
}
