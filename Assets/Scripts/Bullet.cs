using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = collision.gameObject.GetComponent<EnemyBehaviour>();

            AudioManager.Instance.PlayExplosion();

            Destroy(this.gameObject);
            enemy.RemoveEnemyHp(GameManager.Instance.attack_damage);

            var new_popup = Instantiate(GameManager.Instance.damage_popup, transform.position, Quaternion.identity);
            new_popup.GetComponentInChildren<TextMeshPro>().text = GameManager.Instance.attack_damage.ToString("F2");
            Destroy(new_popup, 0.3f);

            var instExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(instExplosion, 3f);
            if (GameManager.Instance.attack_damage >= enemy.health)
            {
                Destroy(collision.gameObject);

                GameManager.Instance.enemies_killed++;
                GameManager.Instance.SetStats(enemy.exp);

                var new_explosion = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(new_explosion, 0.3f);
            }
        }
    }


}
