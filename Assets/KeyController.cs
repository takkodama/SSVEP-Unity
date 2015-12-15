using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class KeyController : MonoBehaviour {

	private SerialHandler serialHandler;
	
	void Start () {
		serialHandler = GetComponent<SerialHandler> ();
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
	}
}