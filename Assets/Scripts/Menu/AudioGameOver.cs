using UnityEngine;

public class AudioGameOver : MonoBehaviour
{

    [Header("Audio/SRC")]
    [SerializeField] AudioSource music;

    [Header("Music / clip")]
    [SerializeField] AudioClip GameOver_music;

    private void Start()
    {
        GameOverMusic();
    }
    public void GameOverMusic()
    {
        music.clip = GameOver_music;
        music.loop = true;
        music.volume = 0.1f;
        music.Play();
    }
}
