using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPReceiver : MonoBehaviour
{
	private int PORT_NO;
	private string receivedSignal;
	private UdpClient udp;

	Thread thread;
	
	void Start ()
	{
		receivedSignal = "NullPo";
		udp = new UdpClient(PORT_NO);
		Debug.Log ("In: UDPReceiver " + PORT_NO + " is set");
		//If timeout should be set
		//udp.Client.ReceiveTimeout = 10000;

		thread = new Thread(new ThreadStart(ThreadMethod));
		thread.Start(); 
	}

	public void PORT_SET (int received_PORT_NO) {
		PORT_NO = received_PORT_NO;
	}

	public string PORT_GET () {
		return receivedSignal;
	}

	void Update ()
	{
	}
	
	void OnApplicationQuit()
	{
		thread.Abort();
	}

	//(memo)Below method moves when only the UDP signal receives
	public void ThreadMethod()
	{
		while(true)
		{
			Debug.Log ("In: " + PORT_NO + " => Received any UDPs!");
			IPEndPoint remoteEP = null;

			byte[] data = udp.Receive(ref remoteEP);
			receivedSignal = Encoding.ASCII.GetString(data);

		}
	} 
}