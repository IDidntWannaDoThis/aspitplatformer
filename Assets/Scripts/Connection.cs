using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Connection : MonoBehaviour
{
    public static Connection Instance;

    SerialPort data_stream = new SerialPort("COM9", 19200);
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

        ArduinoMovement.Instance.MovePlayer(float.Parse(datas[1]));
    }

    private void OnApplicationQuit()
    {
        data_stream.Close();
    }
}
