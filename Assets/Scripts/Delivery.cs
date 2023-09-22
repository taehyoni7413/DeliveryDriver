using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Delivery : MonoBehaviour
{

   
    public CountDownController CountDown;
    public static Delivery Instance;
    public int BoxScore = 3;
    public Text BoxText;
    public GameObject DeliveryPrefab;   
    [SerializeField]
    Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField]
    Color32 noPackageColor = new Color32(1, 1, 1, 1);
   
    
    bool hasPackage;
    SpriteRenderer spriteRenderer;
    //public Text boxText;
    public Image[] lifeImg;
    public GameObject gameOverSet;
    public GameObject gameClearSet;

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();

        }
    }
    void Start()
    {
        BoxScore = 3;
        Instance = this;

    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (BoxScore == 0 && CountDown.IsGameStart == true)
        {
            GameClear();
            CountDown.IsGameStart = false;
            UnlockNewLevel();
        }
    }
    public void UpdateLifeIcon(int life)
    {
     for (int index = 0; index < 3; index++)
        {
            lifeImg[index].color = new Color(1,1,1,0);
        }
        for (int index = 0; index < life; index++)
        {
            lifeImg[index].color = new Color(1, 1, 1, 1);
        }
    }
    public void GameOver()
    {
        
            gameOverSet.SetActive(true);
        CountDown.IsGameStart = false;
            AudioManager.instance.PlaySFX("GAmeover");
        
       
    }
    public void GameClear()
    {
        gameClearSet.SetActive(true);
        CountDown.IsGameStart = false;

        AudioManager.instance.PlaySFX("Clearrr");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package get!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject);
            AudioManager.instance.PlaySFX("Pickup");

        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            BoxScore -= 1;
            AudioManager.instance.PlaySFX("Complete");

        }
        
        
        

    }

}
