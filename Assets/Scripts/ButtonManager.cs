using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    float multiplier = 1.1f;
    float speed_multiplier = 1.90f;
    float move_speed_multiplier = 1.05f;

    public void ClickToSetAtributes(string atr_)
    {
        switch (atr_)
        {
            case "atk_damage":
                GameManager.Instance.base_attack_damage *= multiplier;
                break;
            case "atk_speed":
                GameManager.Instance.base_attack_speed *= (speed_multiplier -1);
                break;
            case "move_speed":
                GameManager.Instance.base_move_speed *= move_speed_multiplier;
                break;
            case "stamina":
                GameManager.Instance.player_max_stamina += 1;
                break;
        }
        GameManager.Instance.HUD_levelUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickToPlay()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CloseModal()
    {
        GameManager.Instance.panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
