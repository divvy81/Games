using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class HardwareInput : MonoBehaviour {
	
	int Total_serial_ports=3;
	int move_front = 0; // 0 = movig front 
	//1 = trying to change movement  2 = moving back 
	
	int[] serialPort = new int[ 5 ]; // No. of consecutive input on this port, 5th one represents previous input. 
	public static bool[] give_output = new bool[5]; // wether/not to reject hardware input.
	/*
 * 		 Screen
 * 
 *       	1    
 * 
 * 		 2		3
 * 
 * 			4
 * 
 * 
 */
	
	
	public static SerialPort sp = new SerialPort("COM4", 38400);
	int ch;
	// Use this for initialization
	void Start () {
		ch = 0;
		int i;
		for (i=1; i<=Total_serial_ports; i++) {
			serialPort[i] = 0;
			give_output[i] = false;
		}
		serialPort[i] = 0;
		sp.Open();
		sp.ReadTimeout = 1;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		//sp.Write ("9");
		//Debug.Log ("heai");
	}
	public static void closeit()
	{
		HardwareInput.sp.Close ();
	}
	void FixedUpdate () {
		
		if (sp.IsOpen) 
		{
			
			try {
				
				ch = sp.ReadByte ();
				Debug.Log("ch= "+ch);
			} 
			catch (System.Exception) 
			{
				ch=serialPort[4];
				//Debug.Log("bad input from hardware");
			}
		}
		
		//check_move_direction();
		// which is pressed
		if (ch == 1 || ch == 2 || ch == 3) {
			Debug.Log ("ch=" + ch);
			if (give_output [ch] == false) {
				
				if ((serialPort [4] != ch)) {
					serialPort [serialPort [4]] = 0; //no. of input is 0
					give_output [serialPort [4]] = false;
				}
				serialPort [ch]++;
				serialPort [4] = ch;
				if (serialPort [ch] >= 1) {
					give_output [ch] = true;
				}
			}
			Debug.Log ("hardware="+give_output [1] + " " + give_output [2] + " " + give_output [3] + " " );
		}
	}
	/*void check_move_direction()
	{

		if ((move_front == 0) && ((give_output[3]) || (give_output[4])))
		{
			move_front = 1; // trying to move back
		}
		if ((move_front == 1) && ((give_output [3]) && (give_output [4]))) {
			move_front = 2;
			give_output [3] = false;
			give_output [4] = false;
		}

		if ((move_front == 3) && ((give_output[1]) || (give_output[2])))
		{
			move_front = 1; // trying to move back
		}
		if ((move_front == 1) && ((give_output [1]) && (give_output [2]))) {
				move_front =0; // now moving front
				give_output [1] = false;
				give_output [2] = false;
					
			}

	}*/
}
