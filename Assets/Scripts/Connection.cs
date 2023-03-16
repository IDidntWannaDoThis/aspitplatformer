using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Connection : MonoBehaviour
{
    public static Connection Instance;

    SerialPort data_stream = new SerialPort("COM3", 19200);
    public string recievedString;
    public GameObject test_data;

    public string[] datas;


    private void Awake()
    {
        if (Instance == null && Instance != this)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        data_stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        recievedString = data_stream.ReadLine();

        string[] datas = recievedString.Split(',');
        Debug.Log(float.Parse(datas[1]));
        ArduinoMovement.Instance.MovePlayer(float.Parse(datas[1]));

        if (int.Parse(datas[2]) == 1)
        {
            ArduinoMovement.Instance.Jump();
        }
    }

    private void OnApplicationQuit()
    {
        data_stream.Close();
    }
}
