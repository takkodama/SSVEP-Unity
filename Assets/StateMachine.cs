using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {

	private int statement = 0;
	private int TrialFlag = 0;
	private int RestFlag = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	public string ExperimentStatement(int portValue){
		if (portValue == 32769) { //START
			Debug.Log ("Experiment Start");
			statement = 100000;

			return "Ex:START";
		} else if (portValue == 32770) { //STOP
			Debug.Log ("Experiment Stop");
			statement = 010101;

			TrialFlag = 0;
			RestFlag = 0;

			return "Ex:STOP";
		}
		return "Ex:STOP";
	}

	public string TrialStatement(int portValue){
		if (portValue == 32773 || portValue == 32779) { //32779 == OVTK_StimulationId_VisualStimulationStart 
			Debug.Log ("Trial Start");
			statement = 101000;

			TrialFlag++;
			RestFlag = 0;

			Debug.Log ("Trial Flag"+ TrialFlag);

			return "Tr:START";
		} else if (portValue == 32774 || portValue == 32780) { //32780 == OVTK_StimulationId_VisualStimulationStop
			Debug.Log ("Trial Stop");
			statement = 100100;

			TrialFlag = 0;
			RestFlag++;

			return  "Tr:STOP";
		}
		return  "Tr:STOP";
	}
	*/

	public string Statement(int portValue1, int portValue2){
		if (portValue1 == 32769 || portValue1 == 33024) { //EX:START (OVTK_StimulationId_VisualStimulationStart or OVTK_StimulationId_Label_00 => when released)
			statement = 10;

			if (portValue2 == 32773 || portValue2 == 32779) { //32779 == OVTK_StimulationId_VisualStimulationStart 
				//Debug.Log ("Trial Start");
				statement = 11;
				
				TrialFlag++;
				RestFlag = 0;
				
				//Debug.Log ("Trial Flag: "+ TrialFlag);
				
				return "TR:START";
			} else if (portValue2 == 32774 || portValue2 == 32780) { //32780 == OVTK_StimulationId_VisualStimulationStop
				//Debug.Log ("Trial Stop");
				statement = 10;
				
				TrialFlag = 0;
				RestFlag++;
				
				return  "TR:STOP";
			}

		} else if (portValue1 == 32770) { //EX:STOP
			TrialFlag = 0;
			RestFlag = 0;

			statement = 00;
		}
		return "Ex:STOP";
	}

	public int getStatement () {
		return statement;
	}

	public int getTrialFlag () {
		return TrialFlag;
	}

	public void resetTrialFlag () {
		TrialFlag = 0;
	}

	public int getRestFlag () {
		return RestFlag;
	}
	
}
