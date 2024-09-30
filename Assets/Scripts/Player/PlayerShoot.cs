using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    float fire_rate;
    float bullet_speed = 30f;

    private void Start()
    {
        fire_rate = GameManager.Instance.attack_speed;
    }
    void Update()
    {
        fire_rate -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(fire_rate <= 0)
            {
                Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                direction.Normalize();

                fire_rate = GameManager.Instance.attack_speed;
                var bullets = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation);

                float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                bullets.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

                bullets.GetComponent<Rigidbody2D>().AddForce(direction * bullet_speed, ForceMode2D.Impulse);
                Destroy(bullets, 1f);

                AudioManager.Instance.PlayShoot();
            }
            
        }
    }

    
}
