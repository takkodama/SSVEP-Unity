using UnityEngine;
using System.Collections;

public class prof : MonoBehaviour {
	
	private Renderer _renderer; 
	
	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Random.Range (0,3) == 0) {
			kuso ();
		} else {
			yaya();
		}
	}
	
	
	void kuso(){
		
		_renderer.enabled = false; //trueで表示
		
	}
	void yaya(){
		
		_renderer.enabled = true;
	}
}
