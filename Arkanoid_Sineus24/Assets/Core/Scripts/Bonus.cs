using UnityEngine;

namespace Arkanoid_Sineus24
{
    public class Bonus : MonoBehaviour
    {
        private Rigidbody2D rbBonus;
        private SpriteRenderer playerSprite;
        private PolygonCollider2D playerCollider;

        private float speed = 100f;
        private float sizeBoost = 1.5f;

        private bool isBonusFalling;

        private void Awake()
        {
            playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
            playerCollider = GameObject.Find("Player").GetComponent<PolygonCollider2D>();
            rbBonus = GetComponent<Rigidbody2D>();
        }

        private void AddSize()
        {
            Vector2[] newPoints = new Vector2[playerCollider.points.Length];
            for (int i = 0; i < newPoints.Length; i++)
            {
                newPoints[i] = new Vector2(playerCollider.points[i].x * sizeBoost, playerCollider.points[i].y);
            }

            playerSprite.size = new Vector2(playerSprite.size.x * sizeBoost, playerSprite.size.y);
            playerCollider.points = newPoints;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball") && !isBonusFalling)
            {
                rbBonus.AddForce(Vector2.down * speed * Time.deltaTime, ForceMode2D.Impulse);
                isBonusFalling = true;
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                AddSize();
            }
        }
    }
}
