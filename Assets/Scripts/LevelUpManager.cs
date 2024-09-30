using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public List<TextMeshProUGUI> atributes_values;


    private void Update()
    {
        atributes_values[0].text = GameManager.Instance.base_attack_damage.ToString("F2");
        atributes_values[1].text = GameManager.Instance.base_attack_speed.ToString("F2");
        atributes_values[2].text = GameManager.Instance.base_move_speed.ToString("F2");
        atributes_values[3].text = GameManager.Instance.player_max_stamina.ToString("F2");
    }

    
}
