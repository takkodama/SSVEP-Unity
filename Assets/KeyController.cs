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
			serialHandler.Write("0");
		}
		if ( Input.GetKeyDown(KeyCode.S) ) {
			serialHandler.Write("1");
		}
		if ( Input.GetKeyDown(KeyCode.D) ) {
			serialHandler.Write("2");
		}
		if ( Input.GetKeyDown(KeyCode.F) ) {
			serialHandler.Write("3");
		}
		if ( Input.GetKeyDown(KeyCode.G) ) {
			serialHandler.Write("4");
		}
		if ( Input.GetKeyDown(KeyCode.H) ) {
			serialHandler.Write("5");
		}

		//===

		if ( Input.GetKeyDown(KeyCode.Q) ) {
			boxController.portSetter(33025, 33025, 33025, 32769, 32773);
		}
		if ( Input.GetKeyDown(KeyCode.W) ) {
			boxController.portSetter(33026, 33026, 33026, 32769, 32773);
		}
		if ( Input.GetKeyDown(KeyCode.E) ) {
			boxController.portSetter(33027, 33027, 33027, 32769, 32773);
		}
		if ( Input.GetKeyDown(KeyCode.R) ) {
			boxController.portSetter(33028, 33028, 33028, 32769, 32773);
		}
		if ( Input.GetKeyDown(KeyCode.R) ) {
			serialHandler.Write("4");
		}
		if ( Input.GetKeyDown(KeyCode.T) ) {
			serialHandler.Write("5");
		}


	}
}