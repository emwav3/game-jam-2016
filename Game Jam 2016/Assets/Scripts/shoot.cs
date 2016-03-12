using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    bool hasClicked = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
                hasClicked = true;
                Vector3 position = this.transform.position;
                position.y += 0.25f;
                this.transform.position = position;
        }
        if (hasClicked)
        {
            Vector3 position = this.transform.position;
            position.y += 0.25f;
            this.transform.position = position;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject arrow = GameObject.FindGameObjectWithTag("Arrow");
        GameObject cogWheel = GameObject.FindGameObjectWithTag("cogWheel");
        if (col.gameObject.tag == "cogWheel")
        {
            Debug.Log("hi");
            // attach a to b
            arrow.transform.parent = cogWheel.transform;
            hasClicked = false;
        }
    }
}
