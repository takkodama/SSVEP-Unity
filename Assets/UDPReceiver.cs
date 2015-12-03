using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPReceiver : MonoBehaviour
{
	int PORT_22222 = 22222;
	int PORT_22223 = 22223;
	int PORT_22224 = 22224;
	UdpClient udp22222;
	UdpClient udp22223;
	UdpClient udp22224;

	public string portNum;

	Thread thread;
	
	void Start ()
	{
		portNum = "NullPo";
		udp22222 = new UdpClient(PORT_22222);

		//If timeout should be set
		//udp22222.Client.ReceiveTimeout = 10000;

		thread = new Thread(new ThreadStart(ThreadMethod));
		thread.Start(); 
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
			Debug.Log ("In: ThreadMethod() => Received any UDPs!");
			IPEndPoint remoteEP = null;

			byte[] data = udp22222.Receive(ref remoteEP);
			portNum = Encoding.ASCII.GetString(data);

		}
	} 


}