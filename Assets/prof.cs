using UnityEngine;
using System.Collections;

public class prof : MonoBehaviour {
	
	private Renderer _renderer; 
	int counter = 1; //set as 1 intentionally (frame would start from 1 firstly)

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

		//Is it accessed? or automatically reset when the number reached its maximum flame number (ex.FPS=60)?
		if (counter == 61) {
			counter = 1;
		}

		//30Hz
		if (counter > 30) {
			onpic();
		} else {
			offpic();
		}

		//15Hz
		/*
		if (counter % 4 == 0) {
			onpic();
		} else {
			offpic();
		}
		*/

		counter += 1;
	}
	

	void onpic(){
		
		_renderer.enabled = true;
	}

	void offpic(){

		_renderer.enabled = false;

	}

}
