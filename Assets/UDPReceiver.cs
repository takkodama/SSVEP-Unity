using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPReceiver : MonoBehaviour
{
	private int PORT_NO_1;
	private int PORT_NO_2;
	private int PORT_NO_3;
	private int PORT_NO_4;
	private int PORT_NO_5;
	private int PORT_NO_6;
	private string receivedSignal1;
	private string receivedSignal2;
	private string receivedSignal3;
	private string receivedSignal4;
	private string receivedSignal5;
	private string receivedSignal6;
	private UdpClient udp1;
	private UdpClient udp2;
	private UdpClient udp3;
	private UdpClient udp4;
	private UdpClient udp5;
	private UdpClient udp6;
	Thread thread1;
	Thread thread2;
	Thread thread3;
	Thread thread4;
	Thread thread5;
	Thread thread6;
	
	void Start ()
	{
		receivedSignal1 = "33024"; //Stimulus - Label number
		receivedSignal2 = "33024"; //Target - Label number
		receivedSignal3 = "33024"; //Result - Label number
		receivedSignal4 = "32770"; //Experiment start(32769) Default: stop(32770)
		receivedSignal5 = "0"; 	   //Trial start(32773) stop(32774) Default: 0
		receivedSignal6 = "0"; 	   //32779 == OVTK_StimulationId_VisualStimulationStart, 32780 == OVTK_StimulationId_VisualStimulationStop, Default:0
		udp1 = new UdpClient (PORT_NO_1);
		udp2 = new UdpClient (PORT_NO_2);
		udp3 = new UdpClient (PORT_NO_3);
		udp4 = new UdpClient (PORT_NO_4);
		udp5 = new UdpClient (PORT_NO_5);
		udp6 = new UdpClient (PORT_NO_6);
		Debug.Log ("In: UDPReceiver " + PORT_NO_1 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_2 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_3 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_4 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_5 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_6 + " is set");

		//If timeout should be set
		//udp.Client.ReceiveTimeout = 10000;
		thread1 = new Thread(new ThreadStart(ThreadMethod1));
		thread2 = new Thread(new ThreadStart(ThreadMethod2));
		thread3 = new Thread(new ThreadStart(ThreadMethod3));
		thread4 = new Thread(new ThreadStart(ThreadMethod4));
		thread5 = new Thread(new ThreadStart(ThreadMethod5));
		thread6 = new Thread(new ThreadStart(ThreadMethod6));
		//1
		//thread.IsBackground = true;
		thread1.Start(); 
		thread2.Start(); 
		thread3.Start(); 
		thread4.Start(); 
		thread5.Start(); 
		thread6.Start(); 
	}

	public void PORT_SET_INIT (int received_PORT_NO_1, int received_PORT_NO_2, int received_PORT_NO_3, int received_PORT_NO_4, int received_PORT_NO_5, int received_PORT_NO_6) {
		PORT_NO_1 = received_PORT_NO_1;
		PORT_NO_2 = received_PORT_NO_2;
		PORT_NO_3 = received_PORT_NO_3;
		PORT_NO_4 = received_PORT_NO_4;
		PORT_NO_5 = received_PORT_NO_5;
		PORT_NO_6 = received_PORT_NO_6;
	}

	public void PORT1_valueRESET () {
		receivedSignal1 = "33123";
	}

	public void PORT1_valueSET (int received_PORT_NO_1) {
		receivedSignal1 = received_PORT_NO_1.ToString();
	}

	public void PORT2_valueSET (int received_PORT_NO_2) {
		receivedSignal2 = received_PORT_NO_2.ToString();
	}

	public void PORT3_valueSET (int received_PORT_NO_3) {
		receivedSignal3 = received_PORT_NO_3.ToString();
	}

	public void PORT4_valueSET (int received_PORT_NO_4) {
		receivedSignal4 = received_PORT_NO_4.ToString();
	}

	public void PORT5_valueSET (int received_PORT_NO_5) {
		receivedSignal5 = received_PORT_NO_5.ToString();
	}

	public void PORT6_valueSET (int received_PORT_NO_6) {
		receivedSignal6 = received_PORT_NO_6.ToString();
	}

	public int PORT1_valueGET () {
		return System.Int32.Parse (receivedSignal1);
	}

	public int PORT2_valueGET () {
		return System.Int32.Parse (receivedSignal2);
	}

	public int PORT3_valueGET () {
		return System.Int32.Parse (receivedSignal3);
	}
	
	public int PORT4_valueGET () {
		return System.Int32.Parse (receivedSignal4);
	}

	public int PORT5_valueGET () {
		return System.Int32.Parse (receivedSignal5);
	}

	public int PORT6_valueGET () {
		return System.Int32.Parse (receivedSignal6);
	}

	void Update ()
	{
	}
	
	public void OnApplicationQuit()
	{
		Debug.Log ("Thread Aborted");
		thread1.Abort();
		thread2.Abort();
		thread3.Abort();
		thread4.Abort();
		thread5.Abort();
		thread6.Abort();
	}

	//(memo)This method may keep opening 
	public void ThreadMethod1()
	{
		while(true)
		{
			IPEndPoint remoteEP1 = null;
			
			byte[] data1 = udp1.Receive(ref remoteEP1);
			receivedSignal1 = Encoding.ASCII.GetString(data1);
			Debug.Log ("ThreadMethod1() : " + receivedSignal1 + "=> Received!");
		}
	} 

	public void ThreadMethod2()
	{
		while(true)
		{
			IPEndPoint remoteEP2 = null;
			
			byte[] data2 = udp2.Receive(ref remoteEP2);
			receivedSignal2 = Encoding.ASCII.GetString(data2);
			Debug.Log ("ThreadMethod2() : " + receivedSignal2 + "=> Received!");
		}
	} 

	public void ThreadMethod3()
	{
		while(true)
		{
			IPEndPoint remoteEP3 = null;
			
			byte[] data3 = udp3.Receive(ref remoteEP3);
			receivedSignal3 = Encoding.ASCII.GetString(data3);
			Debug.Log ("ThreadMethod3() : " + receivedSignal3 + "=> Received!");
		}
	} 

	public void ThreadMethod4()
	{
		while(true)
		{
			IPEndPoint remoteEP4 = null;
			
			byte[] data4 = udp4.Receive(ref remoteEP4);
			receivedSignal4 = Encoding.ASCII.GetString(data4);
			Debug.Log ("ThreadMethod4() : " + receivedSignal4 + "=> Received!");
		}
	} 
		
	public void ThreadMethod5()
	{
		while(true)
		{
			IPEndPoint remoteEP5 = null;
			
			byte[] data5 = udp5.Receive(ref remoteEP5);
			receivedSignal5 = Encoding.ASCII.GetString(data5);
			Debug.Log ("ThreadMethod5() : " + receivedSignal5 + "=> Received!");
		}
	} 

	public void ThreadMethod6()
	{
		while(true)
		{
			IPEndPoint remoteEP6 = null;
			
			byte[] data6 = udp6.Receive(ref remoteEP6);
			receivedSignal6 = Encoding.ASCII.GetString(data6);
			Debug.Log ("ThreadMethod6() : " + receivedSignal6 + "=> Received!");
		}
	} 
}