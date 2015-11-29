using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject systemObj1;
	public GameObject systemObj2;
	public GameObject systemObj3;

	private float updateDuration;
	private int updateFrameCounter;
	private int flagMan;

	public Image box1;
	public Image box2;

	
	public int[] pattern30 = new int[] {
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1
	};

	public int[] pattern15 = new int[] {
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1,
	};

	/*
	Renderer box2 = systemObj2.GetComponent<Renderer>();
	Renderer box3 = systemObj3.GetComponent<Renderer>();
	*/

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;

		box1 = systemObj1.GetComponent<Image>();
		box2 = systemObj2.GetComponent<Image>();
	
		updateDuration = 0.0f;
		updateFrameCounter = 0;
		flagMan = 0;

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("==============================");
		
		Debug.Log("Time.frameCount :" +  Time.frameCount);
		
		updateDuration += Time.deltaTime;
		Debug.Log("updateDuration :" +  updateDuration);
		
		++updateFrameCounter;
		Debug.Log("updateFrameCounter :" +  updateFrameCounter);

		++flagMan;
		if (flagMan == 60)
			flagMan = 0;

		//Alpha
		box1.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
		//Check On-Off
		box2.enabled = false;

		if (pattern15 [flagMan] == 1) {
			Debug.Log ("(*v*) Flash!");
			box1.color = new Color(1.00f, 1.00f, 1.00f, 1.00f);
			box2.enabled = true;
			Debug.Log ("pattern15[" + flagMan + "]: " + pattern15 [flagMan]);
		} else {
			Debug.Log ("(-_-) No Flash");
			box1.color = new Color(1.00f, 1.00f, 1.00f, 0.00f);
			box2.enabled = false;
			Debug.Log ("pattern15[" + flagMan + "]: " + pattern15 [flagMan]);
		}
	
	}
}
