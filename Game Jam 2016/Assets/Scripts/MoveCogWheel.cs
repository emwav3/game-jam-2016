using UnityEngine;
using System.Collections;

public class MoveCogWheel : MonoBehaviour {

    Transform cogTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        cogTransform = GetComponent<Transform>();
        cogTransform.Rotate(0, 0, 1);
	}
}
