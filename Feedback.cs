using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour
{
    public bool shouldDestroy;
    // Start is called before the first frame update
    void Start()
    {

        var angle = Random.Range(0, 2*Mathf.PI);
        var mag = Random.Range(1, 2);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle)*mag,Mathf.Sin(angle)*mag);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldDestroy){
            Destroy(gameObject);
        }
    }
}
