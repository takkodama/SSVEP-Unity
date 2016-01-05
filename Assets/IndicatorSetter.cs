using UnityEngine;
using System.Collections;

public class IndicatorSetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Color Indicator1 (int pattern) {

		switch (pattern)
		{
		case 0:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		case 1:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (1.00f, 1.00f, 0.00f, 0.00f);
		}
	}

	public Color Indicator2 (int pattern) {
		
		switch (pattern)
		{
		case 0:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		case 2:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (1.00f, 1.00f, 0.00f, 0.00f);
		}
	}

	public Color Indicator3 (int pattern) {
		
		switch (pattern)
		{
		case 0:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		case 3:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (1.00f, 1.00f, 0.00f, 0.00f);
		}
	}

	public Color Indicator4 (int pattern) {
		
		switch (pattern)
		{
		case 0:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		case 4:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (1.00f, 1.00f, 0.00f, 0.00f);
		}
	}

	
	public Color boxIndicator1 (int pattern) {
		
		switch (pattern)
		{
		case 0:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		case 1:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		}
	}
	
	public Color boxIndicator2 (int pattern) {
		
		switch (pattern)
		{
		case 0:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		case 2:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		}
	}
	
	public Color boxIndicator3 (int pattern) {
		
		switch (pattern)
		{
		case 0:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		case 3:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		}
	}
	
	public Color boxIndicator4 (int pattern) {
		
		switch (pattern)
		{
		case 0:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		case 4:
			return new Color (1.00f, 1.00f, 0.00f, 1.00f);
		default:
			return new Color (0.00f, 0.00f, 0.00f, 1.00f);
		}
	}
}
