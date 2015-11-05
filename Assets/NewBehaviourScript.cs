using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	void OnGUI(){
		GUI.Button(new Rect(10,10,100,25), "Click me");
	}
}
