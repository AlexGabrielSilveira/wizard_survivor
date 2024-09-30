using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio/SRC")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    [Header("sfx/ Clip")]
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip levelUp;
    [SerializeField] AudioClip player_hit;

    [Header("Music / clip")]
    [SerializeField] AudioClip background;

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
        BackgroundMusic();
    }
    public void BackgroundMusic()
    {
        music.clip = background;
        music.loop = true;
        music.volume = 0.2f;
        music.Play();
    }
    public void PlayShoot()
    {
        sfx.PlayOneShot(shoot, 0.4f);
    }
    public void PlayExplosion()
    {
        sfx.PlayOneShot(explosion, 0.3f);
    }
    public void PlayLevelUp()
    {
        sfx.PlayOneShot(levelUp, 0.5f);
    }
    public void PlayPlayerHit()
    {
        sfx.PlayOneShot(player_hit, 0.2f);
        
    }

}
