using UnityEngine;
using System.Collections;

public class PatternArray : MonoBehaviour {

	//petternA 1Hz length == 10
	private int[] patternA = new int[] {
		0, 0, 0, 0, 0, 1, 1, 1, 1, 1
	};

	//petternB 5Hz length == 30
	private int[] patternB = new int[] {
		0, 0, 0, 1, 1, 1, 0, 0, 0, 1,
		1, 1, 0, 0, 0, 1, 1, 1, 0, 0,
		0, 1, 1, 1, 0, 0, 0, 1, 1, 1
	};

	//petternC 5Hz length == 20
	private int[] patternC = new int[] {
		0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 
		1, 1, 0, 0, 1, 1, 0, 0, 1, 1
	};

	//petternC 5Hz length == 10
	private int[] patternD = new int[] {
		0, 1, 0, 1, 0, 1, 0, 1, 0, 1
	};

	//petternE 5Hz length == 40
	private int[] patternE = new int[] {
		0, 0, 0, 0, 1, 1, 1, 1, 0, 0,
		0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 
		1, 1, 1, 1, 0, 0, 0, 0, 1, 1,
		1, 1, 0, 0, 0, 0, 1, 1, 1, 1
	};
	
	private int[] pattern10 = new int[60];
	private int[] pattern12 = new int[60];
	private int[] pattern15 = new int[60];
	private int[] pattern20 = new int[60];

	//New arrays
	private int[] pattern6 = new int[60];
	private int[] pattern7 = new int[60];
	private int[] pattern8 = new int[60];
	private int[] pattern9 = new int[60];
	private int[] pattern11 = new int[60];
	private int[] pattern13 = new int[60];
	private int[] pattern14 = new int[60];
	private int[] pattern16 = new int[60];
	private int[] pattern17 = new int[60];
	private int[] pattern18 = new int[60];
	//private int[] pattern19 = new int[60];
	private int[] pattern21 = new int[60];
	private int[] pattern22 = new int[60];
	private int[] pattern23 = new int[60];
	private int[] pattern24 = new int[60];
	private int[] pattern25 = new int[60];
	private int[] pattern26 = new int[60];
	


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Steady
	public int[] getPat10 () {
		patternB.CopyTo(pattern10, 0);
		patternB.CopyTo(pattern10, 30);
		return pattern10;
	}
	
	public int[] getPat12 () {
		patternA.CopyTo(pattern12, 0);
		patternC.CopyTo(pattern12, 10);
		patternA.CopyTo(pattern12, 30);
		patternC.CopyTo(pattern12, 40);
		return pattern12;
	}

	//Steady
	public int[] getPat15 () {
		patternC.CopyTo(pattern15, 0);
		patternC.CopyTo(pattern15, 20);
		patternC.CopyTo(pattern15, 40);
		return pattern15;
	}

	public int[] getPat20 () {
		patternC.CopyTo(pattern20, 0);
		patternD.CopyTo(pattern20, 20);
		patternC.CopyTo(pattern20, 30);
		patternD.CopyTo(pattern20, 50);
		return pattern20;
	}

	//new arrays

	public int[] getPat6 () {
		patternA.CopyTo(pattern6, 0);
		patternA.CopyTo(pattern6, 10);
		patternA.CopyTo(pattern6, 20);
		patternA.CopyTo(pattern6, 30);
		patternA.CopyTo(pattern6, 40);
		patternA.CopyTo(pattern6, 50);
		return pattern6;
	}

	public int[] getPat7 () {
		patternE.CopyTo(pattern7, 0);
		patternA.CopyTo(pattern7, 40);
		patternA.CopyTo(pattern7, 50);
		return pattern7;
	}

	public int[] getPat8 () {
		patternA.CopyTo(pattern8, 0);
		patternA.CopyTo(pattern8, 10);
		patternA.CopyTo(pattern8, 20);
		patternB.CopyTo(pattern8, 30);
		return pattern8;
	}

	public int[] getPat9 () {
		patternA.CopyTo(pattern9, 0);
		patternA.CopyTo(pattern9, 10);
		patternC.CopyTo(pattern9, 20);
		patternA.CopyTo(pattern9, 40);
		patternA.CopyTo(pattern9, 50);
		return pattern9;
	}

	public int[] getPat11 () {
		patternA.CopyTo(pattern11, 0);
		patternB.CopyTo(pattern11, 10);
		patternC.CopyTo(pattern11, 40);
		return pattern11;
	}

	public int[] getPat13 () {
		patternA.CopyTo(pattern13, 0);
		patternA.CopyTo(pattern13, 10);
		patternA.CopyTo(pattern13, 20);
		patternC.CopyTo(pattern13, 30);
		patternD.CopyTo(pattern13, 50);
		return pattern13;
	}

	public int[] getPat14 () {
		patternA.CopyTo(pattern14, 0);
		patternA.CopyTo(pattern14, 10);
		patternA.CopyTo(pattern14, 20);
		patternA.CopyTo(pattern14, 30);
		patternD.CopyTo(pattern14, 40);
		patternD.CopyTo(pattern14, 50);
		return pattern14;
	}

	public int[] getPat16 () {
		patternA.CopyTo(pattern16, 0);
		patternC.CopyTo(pattern16, 10);
		patternC.CopyTo(pattern16, 30);
		patternD.CopyTo(pattern16, 50);
		return pattern16;
	}

	public int[] getPat17 () {
		patternA.CopyTo(pattern17, 0);
		patternA.CopyTo(pattern17, 10);
		patternC.CopyTo(pattern17, 20);
		patternD.CopyTo(pattern17, 40);
		patternD.CopyTo(pattern17, 50);
		return pattern17;
	}
	
	public int[] getPat18 () {
		patternA.CopyTo(pattern18, 0);
		patternA.CopyTo(pattern18, 10);
		patternA.CopyTo(pattern18, 20);
		patternD.CopyTo(pattern18, 30);
		patternD.CopyTo(pattern18, 40);
		patternD.CopyTo(pattern18, 50);
		return pattern18;
	}
	
	//getPat19 ... is not able to create
	
	public int[] getPat21 () {
		patternA.CopyTo(pattern21, 0);
		patternC.CopyTo(pattern21, 10);
		patternD.CopyTo(pattern21, 30);
		patternD.CopyTo(pattern21, 40);
		patternD.CopyTo(pattern21, 50);
		return pattern21;
	}
	
	public int[] getPat22 () {
		patternA.CopyTo(pattern22, 0);
		patternD.CopyTo(pattern22, 10);
		patternD.CopyTo(pattern22, 20);
		patternA.CopyTo(pattern22, 30);
		patternD.CopyTo(pattern22, 40);
		patternD.CopyTo(pattern22, 50);
		return pattern22;
	}
	
	//getPat23 ... is not able to create
	//getPat24 ... is not able to create
	
	public int[] getPat25 () {
		patternD.CopyTo(pattern25, 0);
		patternD.CopyTo(pattern25, 10);
		patternC.CopyTo(pattern25, 20);
		patternD.CopyTo(pattern25, 40);
		patternD.CopyTo(pattern25, 50);
		return pattern25;
	}
	
	public int[] getPat26 () {
		patternA.CopyTo(pattern26, 0);
		patternD.CopyTo(pattern26, 10);
		patternD.CopyTo(pattern26, 20);
		patternD.CopyTo(pattern26, 30);
		patternD.CopyTo(pattern26, 40);
		patternD.CopyTo(pattern26, 50);
		return pattern26;
	}
	


}
