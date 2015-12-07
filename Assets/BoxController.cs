using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoxController : MonoBehaviour {

	//Declare UDPReceiver
	private UDPReceiver udprcv;
	
	//Boxes
	public GameObject systemObj1;
	public GameObject systemObj2;
	public GameObject systemObj3;
	public GameObject systemObj4;

	//Boxes & Flicer instances
	public Image box1;
	public Image box2;
	public Image box3;
	public Image box4;
	private BoxFlicker box_10hz;
	private BoxFlicker box_12hz;
	private BoxFlicker box_15hz;
	private BoxFlicker box_20hz;

	//Frame counter (NOT debug)
	private int flagMan = 0;
	
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

	//(For debug) Received PORT number
	public GameObject systemObj11, systemObj12, systemObj13, systemObj14;
	public Text text_PORT1, text_PORT2, text_PORT3, text_PORT4;

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
		udprcv.PORT_SET (22222, 22223, 22224, 22225);

		//Set GetComponents (must be put here, or Start() function)
		box1 = systemObj1.GetComponent<Image>(); 
		box2 = systemObj2.GetComponent<Image>();
		box3 = systemObj3.GetComponent<Image>();
		box4 = systemObj4.GetComponent<Image>();
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
	
		//(For Debug) Call UDPReceiver 
		Debug.Log ("udprcv(22222):" + udprcv.PORT_GET_1 ());
		Debug.Log ("udprcv(22223):" + udprcv.PORT_GET_2 ());
		Debug.Log ("udprcv(22224):" + udprcv.PORT_GET_3 ());
		Debug.Log ("udprcv(22225):" + udprcv.PORT_GET_4 ());

		//Show their UDP signals
		text_PORT1.text = udprcv.PORT_GET_1 ();
		text_PORT2.text = udprcv.PORT_GET_2 ();
		text_PORT3.text = udprcv.PORT_GET_3 ();
		text_PORT4.text = udprcv.PORT_GET_4 ();

		//(For Debug) Frame Counter and Elapsed Time
		updateDuration += Time.deltaTime;
		++updateFrameCounter;

		if (updateFrameCounter % 60 == 0) {
			text1.text = updateDuration.ToString ();
			text2.text = updateFrameCounter.ToString ();
		}

		++flagMan;
		if (flagMan == 60) 
			flagMan = 0;

		box_10hz.Box (flagMan);
		box_12hz.Box (flagMan);
		box_15hz.Box (flagMan);
		box_20hz.Box (flagMan);

		//(For Debug) Counter to assure flashing frequencies for each boxes on production
		text10.text = box_10hz.GetCounter ();
		text12.text = box_12hz.GetCounter ();
		text15.text = box_15hz.GetCounter ();
		text20.text = box_20hz.GetCounter ();
	
	}
}
