using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject arrow;
    Transform arrowSpawnPointTransform;
    public GameObject arrowSpawnPoint;
    GameObject cogWheel;

    int levelNumber = 0;
    public int[] arrowsOnLevel = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int numberOfLevels;
    public string[] wheels = { "wheel1", "wheel2", "wheel3", "wheel4", "wheel5", "wheel6", "wheel7", "wheel8", "wheel9", "wheel10" };
    public int totalArrowsForLevel;
    public int arrowsShot;
    public int arrowsHit;

    private bool gameOver;
    private bool restart;

    public Text gameOverText;
    public Text restartText;

    // Use this for initialization
    void Awake () {
        numberOfLevels = arrowsOnLevel.Length;

        totalArrowsForLevel = arrowsOnLevel[levelNumber];
        arrowsHit = 0;
        


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ReloadArrowCoroutine());
        }
            if (LevelComplete())
        {
            this.levelNumber += 1;
        }
        if (gameOver)
        {
            cogWheel = GameObject.FindGameObjectWithTag("cogWheel");
            Transform cogWheelTrans = cogWheel.GetComponent<Transform>();
            cogWheelTrans.Rotate(0, 0, -1);
            restartText.text = "Press 'R' for Restart";
            restart = true;

        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
                Time.timeScale = 1.0f;
            }
        }

    }

    void ReloadWheel()
    {



    }

    public IEnumerator ReloadArrowCoroutine()
    {
        yield return new WaitForSeconds(0.15f);
        ReloadArrow();
    }
    public void ReloadArrow()
    {

        //arrowSpawnPoint = GameObject.FindGameObjectWithTag("ArrowSpawn");
        arrowSpawnPointTransform = arrowSpawnPoint.GetComponent<Transform>();

        Instantiate(arrow, new Vector3(arrowSpawnPointTransform.position.x, arrowSpawnPointTransform.position.y, arrowSpawnPointTransform.position.z), Quaternion.identity);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverText.text = "Game Over!";
        gameOver = true;
        print("game over!");
        
    }


    public bool LevelComplete()
    {
        return this.totalArrowsForLevel == this.arrowsHit;
    }
}
