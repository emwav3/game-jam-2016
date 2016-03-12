using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject arrow;
    Transform arrowSpawnPointTransform;
    public GameObject arrowSpawnPoint;


    int levelNumber = 0;
    public int[] arrowsOnLevel = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int numberOfLevels;
    public string[] wheels = { "wheel1", "wheel2", "wheel3", "wheel4", "wheel5", "wheel6", "wheel7", "wheel8", "wheel9", "wheel10" };
    public int totalArrowsForLevel;
    public int arrowsShot;
    public int arrowsHit;


    // Use this for initialization
    void Awake () {
        numberOfLevels = arrowsOnLevel.Length;

        totalArrowsForLevel = arrowsOnLevel[levelNumber];
        arrowsHit = 0;
        


    }
	
	// Update is called once per frame
	void Update () {
	    if(LevelComplete())
        {
            this.levelNumber += 1;
        }

        
	}

    void ReloadWheel()
    {



    }

    public void ReloadArrow()
    {
        arrowSpawnPoint = GameObject.FindGameObjectWithTag("ArrowSpawn");
        arrowSpawnPointTransform = arrowSpawnPoint.GetComponent<Transform>();

        Instantiate(arrow, new Vector2(arrowSpawnPointTransform.position.x, arrowSpawnPointTransform.position.y), Quaternion.identity);



    }
    public bool LevelComplete()
    {
        return this.totalArrowsForLevel == this.arrowsHit;
    }
}
