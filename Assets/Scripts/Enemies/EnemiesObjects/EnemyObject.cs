using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy")]
public class EnemyObject : ScriptableObject
{
    public float health_;
    public float attack_damage_;
    public float attack_speed_;
    public float move_speed_;
    public float exp_;
    public float gold_;
}
