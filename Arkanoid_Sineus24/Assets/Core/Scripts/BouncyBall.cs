using UnityEngine;

namespace Arkanoid_Sineus24
{
    public class BouncyBall : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;
        private Rigidbody2D rbBall;
        private GameManager gameManager;

        private float outZoneY = -5.5f;
        private float force = 400;
        private float offsetX = 0;
        private float offsetY = 0.6f;

        private bool isActive;

        protected void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            rbBall = GetComponent<Rigidbody2D>();

            rbBall.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(player.transform);
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isActive)
            {
                BallActivate();
            }
            BallMiss();
        }

        private void BallActivate()
        {
            isActive = true;
            transform.SetParent(null);
            rbBall.bodyType = RigidbodyType2D.Dynamic;
            rbBall.AddForce(new Vector2(offsetX, force));
        }
        
        private void BallMiss()
        {
            if (transform.position.y < outZoneY)
            {
                isActive = false;
                rbBall.velocity = Vector3.zero;
                transform.SetParent(player.transform);
                transform.position = new Vector2(player.transform.position.x, player.transform.position.y + offsetY);
                gameManager.AddLives(-1);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Brick"))
            {
                Destroy(collision.gameObject);
                gameManager.AddScore(10);
            }
        }
    }
}
