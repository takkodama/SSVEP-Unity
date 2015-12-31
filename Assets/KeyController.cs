using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class KeyController : MonoBehaviour {

	private SerialHandler serialHandler;
	private BoxController boxController;

	void Start () {
		serialHandler = GetComponent<SerialHandler> ();
		boxController = GetComponent<BoxController> ();
	}
	
	void Update()
	{
		if ( Input.GetKeyDown(KeyCode.A) ) {
			serialHandler.setCommand(0);
		}
		if ( Input.GetKeyDown(KeyCode.S) ) {
			serialHandler.setCommand(1);
		}
		if ( Input.GetKeyDown(KeyCode.D) ) {
			serialHandler.setCommand(2);
		}
		if ( Input.GetKeyDown(KeyCode.F) ) {
			serialHandler.setCommand(3);
		}

		//===

		if ( Input.GetKeyDown(KeyCode.Q) ) { //EX: START TR: START (state == 11)
			boxController.portSetter(33025, 33025, 33025, 32769, 32773);
		}
		if ( Input.GetKeyDown(KeyCode.W) ) { //EX: START TR: START
			boxController.portSetter(33026, 33026, 33026, 32769, 32773);
		}
		if ( Input.GetKeyDown(KeyCode.E) ) { //EX: START TR: START
			boxController.portSetter(33027, 33027, 33027, 32769, 32773);
		}
		if ( Input.GetKeyDown(KeyCode.R) ) { //EX: START TR: START
			boxController.portSetter(33028, 33028, 33028, 32769, 32773);
		}

		if ( Input.GetKeyDown(KeyCode.T) ) { //EX: STOP TR: STOP (state == 00)
			boxController.portSetter(33024, 33024, 33024, 32770, 32774);
		}

		if ( Input.GetKeyDown(KeyCode.Y) ) { //EX: START TR: STOP (state == 10) 
			boxController.portSetter(33024, 33025, 33024, 32769, 32774); //(* set target 1)
		}

	}

}