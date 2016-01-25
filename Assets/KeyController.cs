using UnityEngine;
using System.Collections;
//using System.IO.Ports;
using System.Threading;

public class KeyController : MonoBehaviour {

	//private SerialHandler serialHandler;
	//private BoxController boxController;
	private UDPReceiver udpReceiver;

	void Start () {
		//serialHandler = GetComponent<SerialHandler> ();
		//boxController = GetComponent<BoxController> ();
		udpReceiver	  = GetComponent<UDPReceiver> ();
	}
	
	void Update()
	{
		if ( Input.GetKeyDown(KeyCode.A) ) {
			//serialHandler.setCommand(0);
			//boxController.serialOpener();

		}
		if ( Input.GetKeyDown(KeyCode.S) ) {
			//serialHandler.setCommand(1);
		}
		if ( Input.GetKeyDown(KeyCode.D) ) {
			//serialHandler.setCommand(2);
		}
		if ( Input.GetKeyDown(KeyCode.F) ) {
			//serialHandler.setCommand(3);
		}

		//=== portSetter(Stimulus ,Target, Result, Experiment, Trial);
		//PORT 1: Stimulus 		(33025 ~ 33028) 	Default: 33024
		//PORT 2: Target		(33025 ~ 33028) 	Default: 33024
		//PORT 3: Result		(33025 ~ 33028) 	Default: 33024
		//PORT 4: Exp start(32769) stop(32770)	Default: 32770
		//PORT 5: Tri start(32773) stop(32774) 	Default: 0 

		if ( Input.GetKeyDown(KeyCode.Alpha1) ) { //EX: START TR: START (state == 11)
			udpReceiver.PORT1_valueSET(33025);
		}
		if ( Input.GetKeyDown(KeyCode.Alpha2) ) { //EX: START TR: START
			udpReceiver.PORT1_valueSET(33026);
		}
		if ( Input.GetKeyDown(KeyCode.Alpha3) ) { //EX: START TR: START
			udpReceiver.PORT1_valueSET(33027);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) { //EX: START TR: START
			udpReceiver.PORT1_valueSET (33028);
		}

		if (Input.GetKeyDown (KeyCode.Alpha9)) { //EX: START TR: START
			udpReceiver.PORT1_valueSET (33123);
		}

		//===

		if ( Input.GetKeyDown(KeyCode.V) ) { //EX: START TR: START and Visual:START(state == 12) 
			udpReceiver.PORT4_valueSET(32769);
			udpReceiver.PORT5_valueSET(32773);
			udpReceiver.PORT6_valueSET(32779); 
		}

		if ( Input.GetKeyDown(KeyCode.B) ) { //EX: START TR: START (state == 11) 
			udpReceiver.PORT4_valueSET(32769);
			udpReceiver.PORT5_valueSET(32773);
			udpReceiver.PORT6_valueSET(32780); 
		}

		if ( Input.GetKeyDown(KeyCode.N) ) { //EX: START TR: STOP (state == 10) 
			udpReceiver.PORT4_valueSET(32769);
			udpReceiver.PORT5_valueSET(32774);
		}

		if ( Input.GetKeyDown(KeyCode.M) ) { //EX: STOP TR: STOP (state == 00)
			udpReceiver.PORT4_valueSET(32770);
			udpReceiver.PORT5_valueSET(32774);
		}


		//Quit the application
		if ( Input.GetKeyDown(KeyCode.P) ) {
			udpReceiver.OnApplicationQuit();
			//serialHandler.OnDestroy();
		}


	}

}