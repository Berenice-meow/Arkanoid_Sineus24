using UnityEngine;

namespace Arkanoid_Sineus24
{
    public class BricksGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject brickPrefab;
        [SerializeField] 
        private Gradient gradient;
        [SerializeField]
        private Vector2Int size;
        [SerializeField]
        private Vector2 offset;

        protected void Awake()
        {
            CreateBrickWall();
        }

        private void CreateBrickWall()
        {
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    GameObject newBrick = Instantiate(brickPrefab, transform);
                    Vector3 newPosition = new Vector3(((size.x - 1) * 0.5f - i) * offset.x, j * offset.y, 0);

                    newBrick.transform.position = transform.position + newPosition;
                    newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));
                }
            }
        }
    }
}
