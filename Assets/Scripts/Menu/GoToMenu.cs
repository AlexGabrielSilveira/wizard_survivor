using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    float timer = 3;
    public TextMeshProUGUI timer_;

    
    void Update()
    {
        timer -= Time.deltaTime;
        timer_.text = "De volta ao menu em: " + timer.ToString("F2");

        if(timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
        }
    }
}
