using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public static CameraShake Instance;

	private float _amplitude = 0.2f;
	private bool isShaking =false;
	private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		Instance = this;
		initialPosition = transform.localPosition;
	}
	public void Shake(float amplitude,float duration)
	{
		_amplitude = amplitude;
		isShaking = true;
		CancelInvoke ();
		Invoke ("StopShaking", duration);
	}
	public void StopShaking()
	{
		isShaking = false;
	}
	// Update is called once per frame
	void Update () {
		if (isShaking)
		{
			//transform.localPosition = initialPosition + Random.insideUnitCircle* _amplitude;
		}
	
	}
}
