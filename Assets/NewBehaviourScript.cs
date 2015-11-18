using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public Texture aTexture;
	
	private float update_duration;
	private float fixedupdate_duration;
	private int framecounter;
	private int onguicounter;

	public int[] pattern = new int[] {0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1};
	
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 20;

		framecounter = 1;
		update_duration = 0;
		fixedupdate_duration = 0;
		onguicounter = 1;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("==============================");
		
		Debug.Log("Time.frameCount :" +  Time.frameCount);
		
		fixedupdate_duration += Time.deltaTime;
		Debug.Log("FiexedUpdate_Duration :" +  fixedupdate_duration);
		


		/*
		update_duration += Time.deltaTime;
		Debug.Log("Update_Duration :" +  update_duration);
		*/

	}

	void FixedUpdate () {


	}

	/*
	void OnGUI() {
		if (!aTexture) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}

		GUI.DrawTexture(new Rect(50, 50, 120, 120), aTexture, ScaleMode.ScaleToFit, true, 0.0F);

		onguicounter += 1;
		Debug.Log("OnGUICounter :" +  onguicounter);
	}
	*/
}
