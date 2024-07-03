using UnityEngine;
using UnityEngine.SceneManagement;

namespace PongGameScripts
{
    public class UIManager : MonoBehaviour
    {
        public GameObject PausePanel;
        public GameObject InGamePanel;
        // Start is called before the first frame update
        void Start()
        {
            if (PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(false);
            }

            Time.timeScale = 1;
        }

        // Update is called once per frame
        void Update()
        {
            BusSystem.GameOver += GameOver;
        }

        public void PauseButton()
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            InGamePanel.SetActive(false);
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }

        public void MainMenuButton()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void ContinueButton()
        {
            if (!InGamePanel.activeInHierarchy)
            {
                Time.timeScale = 1;
                PausePanel.SetActive(false);
                InGamePanel.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("PongGame");
            }
        
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}
