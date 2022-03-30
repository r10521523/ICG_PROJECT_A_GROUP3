using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkingGameScene : MonoBehaviour
{
    public CarEntity Easy;
    public CarEntity Normal;
    public CarEntity Hard;
    static public CarEntity Follow;
    static public bool isEasy = false;
    static public bool isNormal = false;
    static public bool isHard = false;
    public GameObject GameTitle;
    public GameObject GameOverTitle;
    public GameObject GameCompleteTitle;
    public GameObject PlayButton;
    public GameObject Panel;
    public static bool IsPlaying = false;
    public static ParkingGameScene Instance;
    public static bool choose = false;
    public GameObject RestartButton;
    public GameObject QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        GameTitle.SetActive(true);
        GameOverTitle.SetActive(false);
        GameCompleteTitle.SetActive(false);
        RestartButton.SetActive(false);
        Debug.Log("Welcome to the parking game, please choose the difficulty to challenge!");
        Debug.Log("E for Easy; N for Normal; H for Hard");

    }
    public void GameStart()
    {
        IsPlaying = true;
        GameTitle.SetActive(false);
        PlayButton.SetActive(false);
        QuitButton.SetActive(false);
        Panel.SetActive(false);
        
    }
    public void GameOver()
    {
        IsPlaying = false;
        Panel.SetActive(true);
        GameOverTitle.SetActive(true);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
    }
    public void GameComplete()
    {
        IsPlaying = false;
        Panel.SetActive(true);
        GameCompleteTitle.SetActive(true);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
    }
    public void ResetGame() 

    {
        Debug.Log("Now you restart the parking game, please choose the difficulty to challenge!");
        Debug.Log("E for Easy; N for Normal; H for Hard");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PointEntity.point = 100;
        isEasy = false;
        isNormal = false;
        isHard = false;
        choose = false;
        IsPlaying = false;
    }
    public void QuitGame()
    {
        Debug.Log("You quit the game successfully.");
        Finish();
    }
    // Update is called once per frame
    void Finish()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    void Update()
    {
        if (!choose && IsPlaying == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Now, start the Easy mode.");
                Debug.Log("Your score is start from 100!");
                GameObject.Destroy(Normal.gameObject);
                GameObject.Destroy(Hard.gameObject);

                Follow = Easy;
                choose = true;
                isEasy = true;
            }

            else if (Input.GetKey(KeyCode.N))
            {
                Debug.Log("Now, start the Normal mode.");
                Debug.Log("Your score is start from 120!");
                GameObject.Destroy(Easy.gameObject);
                GameObject.Destroy(Hard.gameObject);

                Follow = Normal;
                choose = true;
                isNormal = true;
            }

            else if (Input.GetKey(KeyCode.H))
            {
                Debug.Log("Now, start the Hard mode.");
                Debug.Log("Your score is start from 150!");
                GameObject.Destroy(Normal.gameObject);
                GameObject.Destroy(Easy.gameObject);

                Follow = Hard;
                choose = true;
                isHard = true;
            }
        }
        
    }
}
