using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public CountDownController CountDown;
    public FixedJoystick Joystick;
   
    public static bool PointerDown = false;
    Rigidbody2D rb;
    Vector2 move;
    public Delivery manager;
    [SerializeField]
    int life = 3;
    
    [SerializeField]
    float moveSpeed = 6f;
    [SerializeField]
    float slowSpeed = 3f;
    [SerializeField]
    float boostSpeed = 8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (CountDown.IsGameStart == true)
        {
            move.x = Joystick.Horizontal;
            move.y = Joystick.Vertical;

            float hAxis = move.x;
            float vAxis = move.y;
            float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
        }
    }
    private void FixedUpdate()
    {
        if (PointerDown)
        {
            rb.velocity = Vector3.zero;

        }
        else
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        
        moveSpeed = slowSpeed;
        life--;
        manager.UpdateLifeIcon(life);
        if (life == 0 && CountDown.IsGameStart == true)
        {
            manager.GameOver(); 
        }
        AudioManager.instance.PlaySFX("Boom");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            AudioManager.instance.PlaySFX("Health");

            Destroy(other.gameObject);
        }
    }
}
