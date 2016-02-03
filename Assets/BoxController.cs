using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxController : MonoBehaviour {

	//Declare Classes
	private UDPReceiver udprcv;
	private SerialHandler serialHandler;
	private IndicatorSetter indicatorSetter;
	private PatternArray patternArray;
	private StateMachine stateMachine;

	//Boxes
	public GameObject systemObj1;
	public GameObject systemObj2;
	public GameObject systemObj3;
	public GameObject systemObj4;

	//Boxes & Flicker instances
	public Image box1;
	public Image box2;
	public Image box3;
	public Image box4;
	private BoxFlicker box_A;
	private BoxFlicker box_B;
	private BoxFlicker box_C;
	private BoxFlicker box_D;

	//Indicator in pics
	public GameObject systemObj_I1;
	public GameObject systemObj_I2;
	public GameObject systemObj_I3;
	public GameObject systemObj_I4;
	public GameObject systemObj_boxI1;
	public GameObject systemObj_boxI2;
	public GameObject systemObj_boxI3;
	public GameObject systemObj_boxI4;
	public GameObject systemObj_MessageLog;

	//Frame counter (NOT debug)
	//private int TrialFlag = 0;
	//private int RestFlag = 0;

	//GET UDP signals
	private int tmpInt_p1, tmpInt_p2, tmpInt_p3, tmpInt_p4, tmpInt_p5, tmpInt_p6, tmpInt_previous;
	
	//(For debug) Each boxes counter
	public GameObject systemObj5;
	//public GameObject systemObj6;
	public GameObject systemObj7;
	public GameObject systemObj8;
	public GameObject systemObj9;
	public GameObject systemObj10;
	public Text text1;
	//public Text text2;
	public Text textA;
	public Text textB;
	public Text textC;
	public Text textD;
	public Text text_Indicator1;
	public Text text_Indicator2;
	public Text text_Indicator3;
	public Text text_Indicator4;
	public Text box_Indicator1;
	public Text box_Indicator2;
	public Text box_Indicator3;
	public Text box_Indicator4;
	public Text text_MessageLog;
	private float Debug_Before, Debug_After, Debug_Duration;

	//(For debug) Received PORT number
	public GameObject systemObj11, systemObj12, systemObj13, systemObj14, systemObj15;
	public Text text_PORT1, text_PORT2, text_PORT3, text_PORT4;

	//(For debug) Frame Counter and Elapsed Time
	private float updateDuration = 0.0f;
	private int updateFrameCounter = 0;

	//Stimulus Frame Counter (activate only 6 frame == 0.1 sec)
	private int stimulusFrameCounter = 0;

	//Flicker pattern arrays
	private int[] patA = new int[60];
	private int[] patB = new int[60];
	private int[] patC = new int[60];
	private int[] patD = new int[60];
	//private int[] pat30;

	// Use this for initialization
	void Start () {
		//Define frame rate
		Application.targetFrameRate = 60;

		//Set UDPReceiver instance & Port number set
		udprcv = GetComponent<UDPReceiver> ();
		udprcv.PORT_SET_INIT (20321, 20322, 20323, 20324, 20326, 20327);

		//Set serialHandler
		serialHandler = GetComponent<SerialHandler> ();

		//Set indicatorSetter
		indicatorSetter = GetComponent<IndicatorSetter> ();

		//Set indicatorSetter
		stateMachine = GetComponent<StateMachine> ();

		//Set GetComponents (must be put here, or Start() function)
		box1 = systemObj1.GetComponent<Image>(); 
		box2 = systemObj2.GetComponent<Image>();
		box3 = systemObj3.GetComponent<Image>();
		box4 = systemObj4.GetComponent<Image>();

		//Indicators in pic
		text_Indicator1 = systemObj_I1.GetComponent<Text> ();
		text_Indicator2 = systemObj_I2.GetComponent<Text> ();
		text_Indicator3 = systemObj_I3.GetComponent<Text> ();
		text_Indicator4 = systemObj_I4.GetComponent<Text> ();
		box_Indicator1 = systemObj_boxI1.GetComponent<Text> ();
		box_Indicator2 = systemObj_boxI2.GetComponent<Text> ();
		box_Indicator3 = systemObj_boxI3.GetComponent<Text> ();
		box_Indicator4 = systemObj_boxI4.GetComponent<Text> ();
		text_MessageLog = systemObj_MessageLog.GetComponent<Text> ();

		//(For debug)
		text1 = systemObj5.GetComponent<Text> ();
		//text2 = systemObj6.GetComponent<Text> ();
		textA = systemObj7.GetComponent<Text> ();
		textB = systemObj8.GetComponent<Text> ();
		textC = systemObj9.GetComponent<Text> ();
		textD = systemObj10.GetComponent<Text> ();
		text_PORT1 = systemObj11.GetComponent<Text> ();
		text_PORT2 = systemObj12.GetComponent<Text> ();
		text_PORT3 = systemObj13.GetComponent<Text> ();
		text_PORT4 = systemObj14.GetComponent<Text> ();
		//text_PORT5 = systemObj15.GetComponent<Text> ();

		//Set BoxFlicker instance
		box_A = systemObj1.AddComponent<BoxFlicker>(); 
		box_B = systemObj2.AddComponent<BoxFlicker>(); 
		box_C = systemObj3.AddComponent<BoxFlicker>(); 
		box_D = systemObj4.AddComponent<BoxFlicker>(); 

		//Set patternArray
		patternArray = GetComponent<PatternArray> ();
		patA = patternArray.getPat7_sin_plus1();
		patB = patternArray.getPat15();
		patC = patternArray.getPat12_sin_plus1();
		patD = patternArray.getPat20_sin_plus1();

		//pat30 = patternArray.getPat30();

		box_A.Setting (patA, box1);
		box_B.Setting (patB, box2);
		box_C.Setting (patC, box3);
		box_D.Setting (patD, box4);
	}

	//For debug
	//will not need soon
	/*
	public void portSetter (int p1, int p2, int p3, int p4, int p5){
		text_MessageLog.text = "port set";
		tmpInt_p1 = p1 - 33024;
		tmpInt_p2 = p2 - 33024;
		tmpInt_p3 = p3 - 33024;
		tmpInt_p4 = p4;
		tmpInt_p5 = p5;
	}
	*/

	//For debug
	public void serialOpener () {
		serialHandler.Open ();
	}
	
	// Update is called once per frame
	void Update () {

		//Yellow depict OFF (Only 180 frames)
		if (stateMachine.getRestFlag () > 1 && stateMachine.getRestFlag () < 180) {
			tmpInt_p2 = 0;

			/*
			text_Indicator1.color = indicatorSetter.Indicator1(0);
			text_Indicator2.color = indicatorSetter.Indicator2(0);
			text_Indicator3.color = indicatorSetter.Indicator3(0);
			text_Indicator4.color = indicatorSetter.Indicator4(0);
			*/
			box_A.resetCounter ();
			box_B.resetCounter ();
			box_C.resetCounter ();
			box_D.resetCounter ();
			stateMachine.resetTrialFlag ();

			textA.text = box_A.getCounter ();
			textB.text = box_B.getCounter ();
			textC.text = box_C.getCounter ();
			textD.text = box_D.getCounter ();
		} 

		//Debug.Log ("========= For Debug =========");

		//GET UDP signals
		tmpInt_p1 = udprcv.PORT1_valueGET () - 33024; //Stimulus
		tmpInt_p2 = udprcv.PORT2_valueGET () - 33024; //Target 

		if (stateMachine.getStatement () == 10) {
			tmpInt_p3 = udprcv.PORT3_valueGET () - 33024; //Result ;
		} else {
			tmpInt_p3 = 0;
			udprcv.PORT3_valueRESET ();
		}

		tmpInt_p4 = udprcv.PORT4_valueGET (); //Experiment start(32769) Default: stop(32770)  
		tmpInt_p5 = udprcv.PORT5_valueGET (); //Trial start(32773) stop(32774)  Default:0 
		tmpInt_p6 = udprcv.PORT6_valueGET (); //32779 == OVTK_StimulationId_VisualStimulationStart, 32780 == OVTK_StimulationId_VisualStimulationStop, Default:0

		//Put them screen texts
		text_PORT1.text = tmpInt_p1.ToString (); //will not need (For debug)
		text_PORT2.text = tmpInt_p2.ToString (); //Target
		text_PORT3.text = tmpInt_p3.ToString (); //Result
		//text_MessageLog.text = tmpInt_p4.ToString ();
		//text_MessageLog.text = tmpInt_p5.ToString ();
		//text_PORT4.text = tmpInt_p4.ToString (); //will not need (For debug)
		//text_PORT5.text = tmpInt_p5.ToString (); //will not need (For debug)

		//(For Debug) Call UDPReceiver 
		//Debug.Log ("PORT1_udprcv(20321):" + tmpInt_p1);
		//Debug.Log ("PORT2_udprcv(20322):" + tmpInt_p2);
		//Debug.Log ("PORT3_udprcv(20323):" + tmpInt_p3);
		//Debug.Log ("PORT4_udprcv(20324):" + tmpInt_p4);
		//Debug.Log ("PORT5_udprcv(20326):" + tmpInt_p5);

		//Experiment start(32769) Default: stop(32770)
		//Reset Target and Result texts and picture circle
		/*
		if (tmpInt_p4 == 32770) {
			TrialFlag = 0;
			RestFlag = 0;
			text_PORT4.text = "Ex:STOP";
		} else if (tmpInt_p4 == 32769) {
			text_PORT4.text = "Ex:START";
		}
		*/
		//text_PORT4.text = stateMachine.ExperimentStatement (tmpInt_p4);

		//Trial start(32773) Default: stop(32774)
		//Switch TrialFlag
		//Reset Target and Result texts and picture circle
		/*
		if (tmpInt_p5 == 32774 || tmpInt_p5 == 32780) { //32780 == OVTK_StimulationId_VisualStimulationStop
			TrialFlag = 0;
			RestFlag++;
			text_PORT5.text = "Tr:STOP";
		} else if (tmpInt_p5 == 32773 || tmpInt_p5 == 32779) { //32779 == OVTK_StimulationId_VisualStimulationStart 
			TrialFlag++;
			RestFlag = 0;
			text_PORT5.text = "Tr:START";
		}
		*/
		//text_PORT5.text = stateMachine.TrialStatement (tmpInt_p5);
		text_PORT4.text = stateMachine.Statement (tmpInt_p4, tmpInt_p5, tmpInt_p6);

		//Depict TARGET and stimulus position on pic
		// -- depict1 ~ 4
		text_Indicator1.color = indicatorSetter.Indicator1 (tmpInt_p2);
		text_Indicator2.color = indicatorSetter.Indicator2 (tmpInt_p2);
		text_Indicator3.color = indicatorSetter.Indicator3 (tmpInt_p2);
		text_Indicator4.color = indicatorSetter.Indicator4 (tmpInt_p2);
		box_Indicator1.color = indicatorSetter.boxIndicator1 (tmpInt_p2);
		box_Indicator2.color = indicatorSetter.boxIndicator2 (tmpInt_p2);
		box_Indicator3.color = indicatorSetter.boxIndicator3 (tmpInt_p2);
		box_Indicator4.color = indicatorSetter.boxIndicator4 (tmpInt_p2);

		//==============================

		//(For Debug) Frame Counter and Elapsed Time
		updateDuration += Time.deltaTime;
		++updateFrameCounter;

		//(For Debug)
		if (updateFrameCounter % 60 == 0) {
			text1.text = updateDuration.ToString ();
			//text2.text = updateFrameCounter.ToString ();
		}

		//if new value has input to stimulus
		if (tmpInt_p1 != tmpInt_previous && tmpInt_p1 != 99) {
			//Debug.Log ("===== Before : " + Time.time);
			// === Debug ===
			Debug_Before = Time.time;
			Debug.Log ("tmpInt_p1 " + tmpInt_p1.ToString ());
			// === Debug ===

			stimulusFrameCounter = 1;
			//serialHandler.Write (tmpInt_p1.ToString ());
			serialHandler.setCommand (tmpInt_p1);
			//Debug.Log ("stimulusFrameCounter " + stimulusFrameCounter);
		}

//		Debug.Log ("=== stimulusFrameCounter ===: " + stimulusFrameCounter);

		if (stimulusFrameCounter == 7) {
			// === Debug ===
			Debug_Duration = Time.time - Debug_Before;
			Debug.Log ("===== Duration : " + Debug_Duration.ToString ());
			text_MessageLog.text = Debug_Duration.ToString ();
			// === Debug ===

			stimulusFrameCounter = 0;
			udprcv.PORT1_valueRESET ();
		} else if (stimulusFrameCounter > 0) {
			++stimulusFrameCounter;
		}

		if ((stateMachine.getTrialFlag ()) == 60) 
			stateMachine.resetTrialFlag ();

		//Flash box
		//if (stateMachine.getStatement () == 12) {
		if (stateMachine.getStatement () == 11) {
			box_A.Box (stateMachine.getTrialFlag ());
			box_B.Box (stateMachine.getTrialFlag ());
			box_C.Box (stateMachine.getTrialFlag ());
			box_D.Box (stateMachine.getTrialFlag ());

			//(For Debug) Counter to assure flashing frequencies for each boxes on production
			textA.text = box_A.getCounter ();
			textB.text = box_B.getCounter ();
			textC.text = box_C.getCounter ();
			textD.text = box_D.getCounter ();
		}

		//Finally
		//To distingish whther tmpInt_p1 is same or not
		tmpInt_previous = tmpInt_p1;
		//Debug.Log ("tmpInt_previous: " + tmpInt_previous);
		//Debug.Log ("tmpInt_p1: " + tmpInt_p1);
	}
	
}
