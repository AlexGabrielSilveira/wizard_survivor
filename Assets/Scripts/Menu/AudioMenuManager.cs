using UnityEngine;

public class AudioMenuManager : MonoBehaviour
{

    [Header("Audio/SRC")]
    [SerializeField] AudioSource music;

    [Header("Music / clip")]
    [SerializeField] AudioClip menu_music;

    private void Start()
    {
        MenuMusic();
    }
    public void MenuMusic()
    {
        music.clip = menu_music;
        music.loop = true;
        music.volume = 0.1f;
        music.Play();
    }
}
