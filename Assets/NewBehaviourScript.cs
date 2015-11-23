using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public Texture aTexture;
	
	private float update_duration;
	private float fixedupdate_duration;

	private int Updateframecounter;
	private int FixedUpdateframecounter;

	private int onguicounter;
	private int flagman;


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
		Application.targetFrameRate = 60;

		onguicounter = 0;
		Updateframecounter = 0;
		FixedUpdateframecounter = 0;
		update_duration = 0;
		fixedupdate_duration = 0;

		flagman = 0;

		Debug.Log ("pattern10[" + flagman + "]: " + pattern10[flagman]);
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("==============================");

		Debug.Log("Time.frameCount :" +  Time.frameCount);

		update_duration += Time.deltaTime;
		Debug.Log("Update_Duration :" +  update_duration);

		++Updateframecounter;
		Debug.Log("Updateframecounter :" +  Updateframecounter);

		++flagman;
		if (flagman == 60)
			flagman = 0;
		Debug.Log("($V$)<Flagman! :" +  flagman);


	}

	void FixedUpdate () {

		/*
		Debug.Log ("==============================");
		
		Debug.Log("Time.frameCount :" +  Time.frameCount);

		fixedupdate_duration += Time.deltaTime;
		Debug.Log("FiexedUpdate_Duration :" +  fixedupdate_duration);

		++FixedUpdateframecounter;
		Debug.Log("FixedUpdateframecounter :" +  FixedUpdateframecounter);

		++flagman;
		if (flagman == 60)
			flagman = 0;
		Debug.Log("($V$)<Flagman! :" +  flagman);
		*/
	}


	void OnGUI() {

		if (!aTexture) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}

		Debug.Log ("Flagman at OnGUI! :" + flagman);

		//DrawTexture 1
		if (pattern10 [flagman] == 1) {
			Debug.Log ("(*v*) Flash!");
			Debug.Log ("pattern10[" + flagman + "]: " + pattern10[flagman]);
			GUI.DrawTexture (new Rect (50, 50, 120, 120), aTexture, ScaleMode.ScaleToFit, true, 0.0F);
		} else {
			Debug.Log ("(-_-) No Flash");
			Debug.Log ("pattern10[" + flagman + "]: " + pattern10[flagman]);
		}

		/*
		onguicounter += 1;
		Debug.Log("OnGUICounter :" +  onguicounter);
		*/

	}

}
