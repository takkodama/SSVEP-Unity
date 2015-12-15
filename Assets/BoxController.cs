using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxController : MonoBehaviour {

	//Declare UDPReceiver
	private UDPReceiver udprcv;

	//Declare SerialHandler
	private SerialHandler serialHandler;
	
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
	private BoxFlicker box_10hz;
	private BoxFlicker box_12hz;
	private BoxFlicker box_15hz;
	private BoxFlicker box_20hz;

	//Indicator in pics
	public GameObject systemObj_I1;
	public GameObject systemObj_I2;
	public GameObject systemObj_I3;
	public GameObject systemObj_I4;
	//public GameObject systemObj25;

	//Frame counter (NOT debug)
	private int TrialFlag = 0;
	private int RestFlag = 0;

	//GET UDP signals
	private int tmpInt_p1, tmpInt_p2, tmpInt_p3, tmpInt_p4, tmpInt_p5;
	private int holdInt_p2, holdInt_p3;
	
	//(For debug) Each boxes counter
	public GameObject systemObj5;
	public GameObject systemObj6;
	public GameObject systemObj7;
	public GameObject systemObj8;
	public GameObject systemObj9;
	public GameObject systemObj10;
	public Text text1;
	public Text text2;
	public Text text10;
	public Text text12;
	public Text text15;
	public Text text20;
	public Text text_Indicator1;
	public Text text_Indicator2;
	public Text text_Indicator3;
	public Text text_Indicator4;
	//public Text text_Indicator5;

	//(For debug) Received PORT number
	public GameObject systemObj11, systemObj12, systemObj13, systemObj14, systemObj15;
	public Text text_PORT1, text_PORT2, text_PORT3, text_PORT4, text_PORT5;

	//(For debug) Frame Counter and Elapsed Time
	private float updateDuration = 0.0f;
	private int updateFrameCounter = 0;

	//Flicker pattern arrays
	public int[] pattern30 = new int[] {
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1
	};

	public int[] pattern20 = new int[] {
		0, 0, 1, 0, 0, 1, 0, 0, 1, 0,
		0, 1, 0, 0, 1, 0, 0, 1, 0, 0,
		1, 0, 0, 1, 0, 0, 1, 0, 0, 1,
		0, 0, 1, 0, 0, 1, 0, 0, 1, 0,
		0, 1, 0, 0, 1, 0, 0, 1, 0, 0,
		1, 0, 0, 1, 0, 0, 1, 0, 0, 1,
	};

	public int[] pattern15 = new int[] {
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
	};

	public int[] pattern12 = new int[] {
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
		0, 0, 0, 1, 1, 0, 0, 0, 1, 1
	};

	public int[] pattern10 = new int[] {
		0, 0, 0, 1, 1, 1, 0, 0, 0, 1,
		1, 1, 0, 0, 0, 1, 1, 1, 0, 0,
		0, 1, 1, 1, 0, 0, 0, 1, 1, 1,
		0, 0, 0, 1, 1, 1, 0, 0, 0, 1,
		1, 1, 0, 0, 0, 1, 1, 1, 0, 0,
		0, 1, 1, 1, 0, 0, 0, 1, 1, 1
	};

	// Use this for initialization
	void Start () {
		//Define frame rate
		Application.targetFrameRate = 60;

		//Set UDPReceiver instance & Port number set
		udprcv = GetComponent<UDPReceiver> ();
		udprcv.PORT_SET (20321, 20322, 20323, 20324, 20326);

		//Set serialHandler
		serialHandler = GetComponent<SerialHandler> ();

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
		//text_Indicator5 = systemObj25.GetComponent<Text> ();

		//(For debug)
		text1 = systemObj5.GetComponent<Text> ();
		text2 = systemObj6.GetComponent<Text> ();
		text10 = systemObj7.GetComponent<Text> ();
		text12 = systemObj8.GetComponent<Text> ();
		text15 = systemObj9.GetComponent<Text> ();
		text20 = systemObj10.GetComponent<Text> ();
		text_PORT1 = systemObj11.GetComponent<Text> ();
		text_PORT2 = systemObj12.GetComponent<Text> ();
		text_PORT3 = systemObj13.GetComponent<Text> ();
		text_PORT4 = systemObj14.GetComponent<Text> ();
		text_PORT5 = systemObj15.GetComponent<Text> ();

		//Set BoxFlicker instance
		box_10hz = systemObj1.AddComponent<BoxFlicker>(); 
		box_12hz = systemObj2.AddComponent<BoxFlicker>(); 
		box_15hz = systemObj3.AddComponent<BoxFlicker>(); 
		box_20hz = systemObj4.AddComponent<BoxFlicker>(); 

		box_10hz.Setting (pattern10, box1);
		box_12hz.Setting (pattern12, box2);
		box_15hz.Setting (pattern15, box3);
		box_20hz.Setting (pattern20, box4);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("========= For Debug =========");

		//GET UDP signals
		tmpInt_p1 = udprcv.PORT_GET_1 () - 33024; //Stimulus (PORT: 20321)
		tmpInt_p2 = udprcv.PORT_GET_2 () - 33024; //Target (PORT: 20322)
		tmpInt_p3 = udprcv.PORT_GET_3 () - 33024; //Result (PORT: 20323)
		tmpInt_p4 = udprcv.PORT_GET_4 (); //Experiment start(32769) Default: stop(32770)  (PORT: 20324)
		tmpInt_p5 = udprcv.PORT_GET_5 (); //Trial start(32773) stop(32774) (PORT: 20326) Default:0 

		//Hold some parameters on behalf of frame valuable
		//if (tmpInt_p2 != 33024)
		//	holdInt_p2 = tmpInt_p2;

		//Put them screen texts
		text_PORT1.text = tmpInt_p1.ToString (); //will not need (For debug)
		text_PORT2.text = tmpInt_p2.ToString (); //Target
		text_PORT3.text = tmpInt_p3.ToString (); //Result
		//text_PORT4.text = tmpInt_p4.ToString (); //will not need (For debug)
		//text_PORT5.text = tmpInt_p5.ToString (); //will not need (For debug)

		//(For Debug) Call UDPReceiver 
		//Debug.Log ("PORT1_udprcv(20321):" + tmpInt_p1);
		//Debug.Log ("PORT2_udprcv(20322):" + tmpInt_p2);
		//Debug.Log ("PORT3_udprcv(20323):" + tmpInt_p3);
		//Debug.Log ("PORT4_udprcv(20324):" + tmpInt_p4);
		//Debug.Log ("PORT5_udprcv(20326):" + tmpInt_p5);

		//Trial start(32773) Default: stop(32774)
		//Switch TrialFlag
		//Reset Target and Result texts and picture circle
		if (tmpInt_p5 == 32774) {
			TrialFlag = 0;
			RestFlag++;
			text_PORT5.text = "Tr:STOP";
		} else if (tmpInt_p5 == 32773) {
			TrialFlag++;
			RestFlag = 0;
			text_PORT5.text = "Tr:START";
		}

		//Yellow depict OFF (Only 180 frames)
		if (RestFlag > 1 && RestFlag < 180) {
			tmpInt_p2 = 0;
			text_Indicator1.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator2.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator3.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator4.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
		}

		//Depict TARGET and stimulus position on pic
		// -- depict1 ~ 4
		if (tmpInt_p2 == 0) {
			text_Indicator1.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator2.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator3.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator4.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
		}else if (tmpInt_p2 == 1) {
			text_PORT3.text = "-";
			text_Indicator1.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator2.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator3.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator4.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
		} else if (tmpInt_p2 == 2) {
			text_PORT3.text = "-";
			text_Indicator1.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator2.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator3.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator4.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
		} else if (tmpInt_p2 == 3) {
			text_PORT3.text = "-";
			text_Indicator1.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator2.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator3.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
			text_Indicator4.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
		} else if (tmpInt_p2 == 4) {
			text_PORT3.text = "-";
			text_Indicator1.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator2.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator3.color = new Color (1.00f, 1.00f, 0.00f, 0.00f);
			text_Indicator4.color = new Color (1.00f, 1.00f, 0.00f, 1.00f);
		}

		//Experiment start(32769) Default: stop(32770)
		//Reset Target and Result texts and picture circle
		if (tmpInt_p4 == 32770) {
			TrialFlag = 0;
			RestFlag = 0;
			text_PORT2.text = "-";
			text_PORT3.text = "-";
			text_PORT4.text = "Ex:STOP";
		} else if (tmpInt_p4 == 32769) {
			text_PORT4.text = "Ex:START";
		}

		//Debug.Log (tmpInt_p1.ToString ());
		//serialHandler.Write (tmpInt_p1.ToString());

		//==============================

		//(For Debug) Frame Counter and Elapsed Time
		updateDuration += Time.deltaTime;
		++updateFrameCounter;

		if (updateFrameCounter % 60 == 0) {
			text1.text = updateDuration.ToString ();
			text2.text = updateFrameCounter.ToString ();
		}

		if (TrialFlag == 60) 
			TrialFlag = 0;

		//Flash box
		box_10hz.Box (TrialFlag);
		box_12hz.Box (TrialFlag);
		box_15hz.Box (TrialFlag);
		box_20hz.Box (TrialFlag);

		//(For Debug) Counter to assure flashing frequencies for each boxes on production
		text10.text = box_10hz.GetCounter ();
		text12.text = box_12hz.GetCounter ();
		text15.text = box_15hz.GetCounter ();
		text20.text = box_20hz.GetCounter ();
	
	}
}
