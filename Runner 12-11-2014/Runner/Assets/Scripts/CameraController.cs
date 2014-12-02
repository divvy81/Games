using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject[] PlayerModels;
	void Start () 
	{
		if (DelegateMenu.AvatarIndex == 1) 
		{
			Debug.Log(DelegateMenu.AvatarIndex);
			PlayerModels[0].SetActive(true);
			this.gameObject.transform.parent = PlayerModels [0].transform;
			PlayerModels[1].SetActive(false);
		}
		else if (DelegateMenu.AvatarIndex == 0) 
		{
			Debug.Log(DelegateMenu.AvatarIndex);

			PlayerModels[1].SetActive(true);
			this.gameObject.transform.parent = PlayerModels [1].transform;
			PlayerModels[0].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
