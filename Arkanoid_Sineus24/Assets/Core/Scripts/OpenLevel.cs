using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid_Sineus24
{
    public class OpenLevel : MonoBehaviour
    {
        [SerializeField]
        private int levelNumber;

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void RestarLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level" + levelNumber);
        }

        public void NextLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level" + (levelNumber + 1));
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
