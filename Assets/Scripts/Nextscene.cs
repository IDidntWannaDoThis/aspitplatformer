using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextscene : MonoBehaviour
{


    public string scene;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            loadscene();
        }
    }

    void loadscene()
    {
        SceneManager.LoadScene(scene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
