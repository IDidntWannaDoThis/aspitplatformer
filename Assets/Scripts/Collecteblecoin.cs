using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecteblecoin : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PointManager.instance.AddToScore(5);
            StartCoroutine(Fade());
        }
    }
    
    
    IEnumerator Fade()
    {
        Color c = spriteRenderer.color;
        for (float alpha = 1f; alpha >= -0.1f; alpha -= 0.1f)
        {
            c.a = alpha;
            spriteRenderer.color = c;
            gameObject.transform.position += new Vector3(0,0.01f,0);
            yield return new WaitForSeconds(.05f);
        }
        Destroy(gameObject);
    }
}
