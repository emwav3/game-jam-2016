using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{

    public bool hasClicked = false;
    public bool hasHit = false;
    GameManager gameManger;

    // Use this for initialization
    void Start()
    {
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasHit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //gameManger.ReloadArrow();
                hasClicked = true;
                Vector3 position = this.transform.position;
                position.y += 0.3f;
                this.transform.position = position;
            }
            if (hasClicked)
            {
                Vector3 position = this.transform.position;
                position.y += 0.3f;
                this.transform.position = position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GameObject cogWheel = GameObject.FindGameObjectWithTag("cogWheel");
        if (col.gameObject.tag == "cogWheel")
        {
            // attach arrow to cog
            this.transform.parent = cogWheel.transform;
            this.hasHit = true;
        }
        if (col.gameObject.tag == "Arrow")
        {
            gameManger.GameOver();
        }
    }

}
