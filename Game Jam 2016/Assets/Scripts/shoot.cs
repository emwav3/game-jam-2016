using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    bool hasHit = false;
    GameManager gameManger;

	// Use this for initialization
	void Start () {
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //        //gameManger.ReloadArrow();
        //        hasClicked = true;
        //        Vector3 position = this.transform.position;
        //        position.y += 0.55f;
        //        this.transform.position = position;
        //}
        if (!hasHit)
        {
            Vector3 position = this.transform.position;
            position.y += 0.25f;
            this.transform.position = position;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //GameObject arrow = GameObject.FindGameObjectWithTag("Arrow");
        GameObject cogWheel = GameObject.FindGameObjectWithTag("cogWheel");
        if (col.gameObject.tag == "cogWheel")
        {
            Debug.Log("hi");
            // attach a to b
            this.transform.parent = cogWheel.transform;
            print("HIT!");
            this.hasHit = true;
        }
    }
}
