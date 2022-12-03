using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   //Circle And Square GO
    public GameObject[] BlueGO;
    public GameObject[] OrangeGO;
    //To instantiate squate and circle
    public float startWait;
    public float spawnWait;
    //which GO to Instantiate
    GameObject Blue, Orange;

    //spawn point spawn randomly X pos
    float[] XPosition = new float[2] { 1.5f, 4.6f };
    bool GameOverBool;

    int Score;
    public Text ScoreText;

    public GameObject GameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        GameOverBool = false;
        Time.timeScale = 1;
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 50; i++)
            {
                //choosing Xpos
                float OrangeXpos = XPosition[Random.Range(0, XPosition.Length)];
                //setting position
                Vector3 OrangePos = new Vector3(OrangeXpos, 10, 0);
                //choosing between square or circle
                Orange = OrangeGO[Random.Range(0, OrangeGO.Length)] as GameObject;
                //Instantiate now
                Instantiate(Orange, OrangePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);

                //choosing Xpos
                float BlueXpos = -XPosition[Random.Range(0, XPosition.Length)];
                //setting position
                Vector3 BluePos = new Vector3(BlueXpos, 10, 0);
                //choosing between square or circle
                Blue = BlueGO[Random.Range(0, BlueGO.Length)] as GameObject;
                //Instantiate now
                Instantiate(Blue, BluePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
           
        }
    }
    public void StartGame()
    {   
        StartCoroutine(SpawnObjects());
    }
    public void GameOver()
    {
        GameOverBool = true;
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
    }
    public void AddScore()
    {
        Score += 1;
        ScoreText.text = Score.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
