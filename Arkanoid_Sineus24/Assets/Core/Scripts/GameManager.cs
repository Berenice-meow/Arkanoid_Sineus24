using TMPro;
using UnityEngine;

namespace Arkanoid_Sineus24
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject ball;
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField]
        private GameObject winPanel;
        [SerializeField]
        private GameObject[] livesImage;
        [SerializeField]
        private TextMeshProUGUI scoreText;

        private int lives = 5;
        private int score = 0;
        private int brickCount;

        void Start()
        {
            brickCount = FindObjectOfType<BricksGenerator>().transform.childCount;
        }

        public void AddLives(int value)
        {
            lives += value;
            livesImage[lives].SetActive(false);

            if (lives <= 0)
            {
                GameOver();
            }
        }

        public void AddScore(int value)
        {
            score += value;
            scoreText.text = score.ToString("000");
            brickCount--;
            if (brickCount <= 0)
            {
                Win();
            }
        }

        private void GameOver()
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            Destroy(ball);
        }

        private void Win()
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
            Destroy(ball);
        }
    }
}
