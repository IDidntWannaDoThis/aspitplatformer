using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;

    private int score = 0;

    private void Awake()
    {
        if (instance == null && instance != this)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int toAdd)
    {
        score += toAdd;
        Debug.Log(score);
    }
}
