using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ArduinoMovement : MonoBehaviour
{
    public static ArduinoMovement Instance;

    [HideInInspector] public Rigidbody2D rb;
    public float sensitivity = 1f;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovePlayer(float data)
    {
        rb.AddForce(transform.right * data * sensitivity * Time.deltaTime, ForceMode2D.Force);
    }
}
