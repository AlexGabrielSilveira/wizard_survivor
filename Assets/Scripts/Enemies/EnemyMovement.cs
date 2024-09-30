using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyBehaviour enemy;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponent<EnemyBehaviour>();
    }
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy.move_speed * Time.deltaTime);
    }
}
