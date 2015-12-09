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
	private string receivedSignal1;
	private string receivedSignal2;
	private string receivedSignal3;
	private string receivedSignal4;
	private string receivedSignal5;
	private UdpClient udp1;
	private UdpClient udp2;
	private UdpClient udp3;
	private UdpClient udp4;
	private UdpClient udp5;

	Thread thread1;
	Thread thread2;
	Thread thread3;
	Thread thread4;
	Thread thread5;
	
	void Start ()
	{
		receivedSignal1 = "33024"; //Stimulus - Label number
		receivedSignal2 = "33024"; //Target - Label number
		receivedSignal3 = "33024"; //Result - Label number
		receivedSignal4 = "NullPo";
		receivedSignal5 = "NullPo";
		udp1 = new UdpClient (PORT_NO_1);
		udp2 = new UdpClient (PORT_NO_2);
		udp3 = new UdpClient (PORT_NO_3);
		udp4 = new UdpClient (PORT_NO_4);
		udp5 = new UdpClient (PORT_NO_5);
		Debug.Log ("In: UDPReceiver " + PORT_NO_1 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_2 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_3 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_4 + " is set");
		Debug.Log ("In: UDPReceiver " + PORT_NO_5 + " is set");

		//If timeout should be set
		//udp.Client.ReceiveTimeout = 10000;
		thread1 = new Thread(new ThreadStart(ThreadMethod1));
		thread2 = new Thread(new ThreadStart(ThreadMethod2));
		thread3 = new Thread(new ThreadStart(ThreadMethod3));
		thread4 = new Thread(new ThreadStart(ThreadMethod4));
		thread5 = new Thread(new ThreadStart(ThreadMethod5));
		//1
		//thread.IsBackground = true;
		thread1.Start(); 
		thread2.Start(); 
		thread3.Start(); 
		thread4.Start(); 
		thread5.Start(); 
	}

	public void PORT_SET (int received_PORT_NO_1, int received_PORT_NO_2, int received_PORT_NO_3, int received_PORT_NO_4, int received_PORT_NO_5) {
		PORT_NO_1 = received_PORT_NO_1;
		PORT_NO_2 = received_PORT_NO_2;
		PORT_NO_3 = received_PORT_NO_3;
		PORT_NO_4 = received_PORT_NO_4;
		PORT_NO_5 = received_PORT_NO_5;
	}

	public string PORT_GET_1 () {
		return receivedSignal1;
	}

	public string PORT_GET_2 () {
		return receivedSignal2;
	}

	public string PORT_GET_3 () {
		return receivedSignal3;
	}
	
	public string PORT_GET_4 () {
		return receivedSignal4;
	}

	public string PORT_GET_5 () {
		return receivedSignal5;
	}

	void Update ()
	{
	}
	
	void OnApplicationQuit()
	{
		thread1.Abort();
		thread2.Abort();
		thread3.Abort();
		thread4.Abort();
		thread5.Abort();
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
}