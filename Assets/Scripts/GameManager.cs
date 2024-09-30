using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject panel;
    public GameObject gameOverPanel;


    [Header("refs")]
    public Slider hp;
    public Slider exp;
    public Slider stamina;
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI time_survive;
    public TextMeshProUGUI kills;
    public GameObject bullet;
    public GameObject explosion;


    //pop up
    public GameObject damage_popup;

    //level up
    public GameObject HUD_levelUp;

    //attributes
    public float player_max_hp = 100;
    public float player_hp;
    public float player_exp = 0;
    public float player_level = 1;
    public float enemies_killed = 0;
    public float player_max_stamina = 15;
    public float player_stamina;
    public bool isEvolved = false;


    //base stats
    public float base_attack_damage;
    public float base_attack_speed;
    public float base_move_speed;

    public float attack_damage = 1;
    public float attack_speed = 0.5f;
    public float move_speed =  450f;

    float darkWizardMultiplier = 1.5f;

    //time
    float time;
    float callGameOver = 1f;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        player_hp = player_max_hp;
        player_stamina = player_max_stamina;

        base_attack_damage = attack_damage;
        base_attack_speed = attack_speed;
        base_move_speed = move_speed;

        bullet.GetComponent<SpriteRenderer>().color = Color.white;
        explosion.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void Update()
    {
        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);

        time_survive.text = string.Format("{00:00}:{01:00}", minutes, seconds);

        if(isEvolved == false && player_stamina < player_max_stamina)
        {
            player_stamina += Time.deltaTime / 1.1f;
        }
        if (isEvolved == true && player_hp < player_max_hp)
        {
            player_hp += Time.deltaTime * 2f;
        }

        SetUpPlayerStats();
        LevelUp();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        GameOver();
    }
    void SetUpPlayerStats()
    {
        hp.maxValue = player_max_hp;
        hp.value = player_hp;
        stamina.maxValue = player_max_stamina;
        stamina.value = player_stamina;
        exp.maxValue = player_level * 100;
        exp.value = player_exp;
        lvl.text = player_level.ToString();
        kills.text = enemies_killed.ToString();
    }
    public void SetStats(float exp)
    {
        player_exp += exp;
    }
    void LevelUp()
    {
        if(player_exp >= player_level * 100)
        {
            player_exp = 0;
            player_level++;
            AudioManager.Instance.PlayLevelUp();

            Time.timeScale = 0f;
            HUD_levelUp.SetActive(true);
            
        }
    }
    public void TakeDamage(float damage)
    {
       player_hp -= damage;
    }
    
    public void DarkWizard()
    {
        isEvolved = true;
        if (isEvolved == true)
        {
            attack_damage *= darkWizardMultiplier;
            attack_speed *= (darkWizardMultiplier - 1);
            move_speed *= darkWizardMultiplier;
            
            bullet.GetComponent<SpriteRenderer>().color = Color.magenta;
            explosion.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }
    public void LightWizard()
    {
        isEvolved = false;
        if(isEvolved == false)
        {
            attack_damage = base_attack_damage;
            attack_speed = base_attack_speed;
            move_speed = base_move_speed;
            bullet.GetComponent<SpriteRenderer>().color = Color.white;
            explosion.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void GameOver()
    {
        if (player_hp <= 0)
        {
            callGameOver -= Time.deltaTime;
            gameOverPanel.SetActive(true);

            if(callGameOver <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

}
