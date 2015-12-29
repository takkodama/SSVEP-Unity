using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour {
	
	public delegate void SerialDataReceivedEventHandler(string message);
	public event SerialDataReceivedEventHandler OnDataReceived;
	
	//public string portName = "COM6";
	public string portName = "/dev/cu.usbmodem1411";
	public int baudRate    = 9600;
	
	private static SerialPort serialPort_;
	private Thread thread_;
	private bool isRunning_ = false;
	
	private string message_;
	private bool isNewMessageReceived_ = false;
	
	void Awake()
	{
		Open();
	}
	
	void Update()
	{
		if (isNewMessageReceived_) {
			OnDataReceived(message_);
		}
	}
	
	void OnDestroy()
	{
		Close();
	}
	
	private void Open()
	{
		serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
		serialPort_.ReadTimeout = 10000;
		serialPort_.Open();
		
		isRunning_ = true;
		
		thread_ = new Thread(Read);
		thread_.Start();
	}
	
	private void Close()
	{
		isRunning_ = false;
		
		if (thread_ != null && thread_.IsAlive) {
			thread_.Join();
		}
		
		if (serialPort_ != null && serialPort_.IsOpen) {
			serialPort_.Close();
			serialPort_.Dispose();
		}
	}
	
	private void Read()
	{
		while (isRunning_ && serialPort_ != null && serialPort_.IsOpen) {
			try {
				// if (serialPort_.BytesToRead > 0) {
				message_ = serialPort_.ReadLine ();
				isNewMessageReceived_ = true;
				// }
			} catch (System.Exception e) {
				Debug.LogWarning (e.Message);
			}
		}
	}

	public void CommandReceiver(int command)
	{
		switch (command)
		{
		case 1:
			Write ("0");
			break;
		case 2:
			Write ("1");
			break;
		case 3:
			Write ("2");
			break;
		case 4:
			Write ("3");
			break;
		default:
			Write ("99");
			break;
		}
	}
	
	public void Write(string message)
	{
		try {
			Debug.Log("=> Before" + Time.time);
			serialPort_.Write (message);
			StartCoroutine(DelayMethod(0.1f, () =>
			                           {
				Debug.Log("After =>" + Time.time);
				serialPort_.Write ("99");
			}));
		} catch (System.Exception e) {
			Debug.LogWarning (e.Message);
		}
	}
	
	private IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}

	//IF wanna use loop function (operated by frame, 6 frame == 0.1 sec)
	private IEnumerator loopFrame(string message, int frame) {
		while (frame > 0) {
			yield return null;
			serialPort_.Write (message);
			Debug.Log(frame);
			frame--;
		}
		Debug.Log("After =>" + Time.time);
		serialPort_.Write ("99");
	}

}

