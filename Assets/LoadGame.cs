using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    //Для блоків
    public GameObject block;
    static int col = 17; int row = 8;
    private float _Dx = 10;
    private float _Dz = 10f;

    //For timer
    public static float timer = 14, coolDown;
    private bool _timerIsRun = true;

    //For Death
    public Text text;
    private bool _isDeath;
    //ForMoney

    public static int money;
    private int _howMuchWinGames;

    public static AudioSource audio;

    public AudioClip[] sounds;


    private void Awake()
    {

        _howMuchWinGames = PlayerPrefs.GetInt("winStreikGames");

        switch (_howMuchWinGames)
        {
            case 0:
                timer = 14f;
                break;
            case 1:
                timer = 13f;
                money += 15;
                break;
            case 2:
                timer = 12f;
                money += 20;
                break;
            case 3:
                timer = 11f;
                money += 30;
                break;
            case 4:
                timer = 10f;
                money += 40;
                break;
            case 5:
                timer = 9f;
                money += 50;
                break;
            case 6:
                timer = 8f;
                money += 60;
                break;
            case 7:
                timer = 7f;
                money += 70;
                break;
            case 8:
                timer = 6f;
                money += 80;
                break;
            case 9:
                timer = 5f;
                money += 90;
                break;
            default:
                money += 90;
                timer = 5f;
                break;


        }
    }
    void Update()
    {
        _isDeath = ControlHero.isDeath;


    }

    void Start()
    {
        audio = GetComponent<AudioSource>();

        int index = Random.Range(0, sounds.Length);
        audio.clip = sounds[index];

        CreateArea();

        StartCoroutine(Timer());
        audio.Play();
    }


    //CreateArea of blocks
    void CreateArea()
    {

        Vector3 Mypos = new Vector3(-76.3f, 3.75f, -51.2f);
        for (int yy = 0; yy < row; yy++)
        {
            for (int xx = 0; xx < col; xx++)
            {
                Instantiate(block, Mypos, Quaternion.identity);

                Mypos.x += _Dx;
            }

            Mypos.x = -76.3f;

            Mypos.z += _Dz;
        }


    }
    //OnApplicationQuit monets in lvl is 0
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("winStreikGames", 0);
    }

    //RestartGameForWin
    void RestartForWin()
    {
        _isDeath = false;
        ControlHero.isDeath = _isDeath;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("winStreikGames", _howMuchWinGames);
        _timerIsRun = true;
    }
    
    
    
    IEnumerator Timer()
    {
        
        while (_timerIsRun == true)
        {
            if (_isDeath == true)
            {
                _timerIsRun = false;
                text.text = "Game Ower";
                _howMuchWinGames = 0;
                PlayerPrefs.SetInt("winStreikGames", 0);
                Invoke("ReloadGame", 1.5f);

            }
            else
            {
                timer -= 1;
                text.text = timer + " sec";
                if (timer == 0)
                {
                    text.text = "Time to fall";
                    _timerIsRun = false;
                    Invoke("checkStatusOfGame", 2.5f);
                }
            }
            yield return new WaitForSeconds(1f);
        }

        
    }
    void ReloadGame()
    {
        
        GameOwerMenu.GameIsOwer = true;
    }
    void checkStatusOfGame()
    {
        if (_isDeath == true)
        {
           
            text.text = "Game Ower";
            _howMuchWinGames = 0;
            PlayerPrefs.SetInt("winStreikGames", 0);
            Invoke("ChangeValueOfIsDeath", 1f);

            
            
        }
        if (_isDeath == false)
        {
            
            text.text = "You winner!";
            _howMuchWinGames += 1;
            PlayerPrefs.SetInt("winStreikGames", _howMuchWinGames);
            
            Invoke("RestartForWin", 2f);
            
        }
        
    }


    //For buttons
    public void RestartDeath()
    {
        _isDeath = false;
        ControlHero.isDeath = _isDeath;
        GameOwerMenu.GameIsOwer = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _timerIsRun = true;

    }
        
    public void Menu()
    {
        PlayerPrefs.SetInt("winStreikGames", 0);
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Pause_Menu.gameIsPaused = true;
        audio.Pause();
    }
    public void ChangeValueOfIsDeath()
    {
        GameOwerMenu.GameIsOwer = true;
    }
}
