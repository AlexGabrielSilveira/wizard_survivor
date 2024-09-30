using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyObject enemy;
    public float health;
    public float attack_damage;
    public float attack_speed;
    public float move_speed;
    public float exp;
    public float gold;
    void Start()
    {
        health = enemy.health_;
        attack_damage = enemy.attack_damage_;
        attack_speed = enemy.attack_speed_;
        move_speed = enemy.move_speed_;
        exp = enemy.exp_;
        gold = enemy.gold_;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.TakeDamage(enemy.attack_damage_);

        }
    }
    public void RemoveEnemyHp(float damage)
    {
        health -= damage;
    }
}
