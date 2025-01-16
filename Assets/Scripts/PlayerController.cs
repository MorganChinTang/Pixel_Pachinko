using UnityEngine;
using Unity.VisualScripting;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    private Rigidbody2D playerRB = null;
    private bool isFalling = false;
    //private bool isFinished = false;
    private RigidbodyConstraints2D originalConstraints;
    private Vector3 playerPosition;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        originalConstraints = playerRB.constraints;
        playerPosition = transform.position;
    }

    void Update()
    {
        if (!isFalling)
        {
        playerRB.linearVelocityX = 0.0f;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            { playerRB.linearVelocityX -= moveSpeed; }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            { playerRB.linearVelocityX += moveSpeed; }

            if(Input.GetKey(KeyCode.Space))
            {
                playerPosition = transform.position;
                playerRB.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                isFalling = true;
            }
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Finish"))
        {
            //isFinished = true;
            RespawnPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("100"))
        {
            GameManager.Instance.AddScore(100);
        }

        if (collision.gameObject.CompareTag("200"))
        {
            GameManager.Instance.AddScore(200);
        }

        if (collision.gameObject.CompareTag("80"))
        {
            GameManager.Instance.AddScore(80);
        }

        if (collision.gameObject.CompareTag("50"))
        {
            GameManager.Instance.AddScore(50);
        }

        if (collision.gameObject.CompareTag("500"))
        {
            GameManager.Instance.AddScore(500);
        }

        if (collision.gameObject.CompareTag("2500"))
        {
            GameManager.Instance.AddScore(2500);
        }
    }

    private void RespawnPlayer()
    {
        transform.position = playerPosition;
        isFalling = false;
        playerRB.linearVelocity = Vector2.zero;
        playerRB.constraints = originalConstraints;
    }


}
