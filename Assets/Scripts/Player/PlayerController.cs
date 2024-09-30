using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] Sprite darkWizard;
    [SerializeField] Sprite defaultWizard;

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x > 0 || x < 0 || y > 0 || y < 0)
        {
            if (x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

            }
        }

        rb.velocity = new Vector3((x * GameManager.Instance.move_speed) * Time.fixedDeltaTime, (y * GameManager.Instance.move_speed) * Time.fixedDeltaTime, 0);
    }
    private void Update()
    {
        Evolution();
    }
    public void Evolution()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && GameManager.Instance.isEvolved == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = darkWizard;
            GameManager.Instance.DarkWizard();
        }
        if (GameManager.Instance.isEvolved == true)
        {
            GameManager.Instance.player_stamina -= Time.deltaTime;
            if (GameManager.Instance.player_stamina <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = defaultWizard;
                GameManager.Instance.LightWizard();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlayPlayerHit();
        }
    }
}
