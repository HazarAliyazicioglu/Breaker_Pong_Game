using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrickBreakerScripts
{
    public class UIManagerBB : MonoBehaviour
    {
        public GameObject PauseMenu;
        public GameObject FinishMenu;
        public GameObject InGameMenu;
        public GameObject EndMenu;
        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            if (PauseMenu.activeInHierarchy)
            {
                PauseMenu.SetActive(false);
            }
            if (EndMenu.activeInHierarchy)
            {
                EndMenu.SetActive(false);
            }

            if (FinishMenu.activeInHierarchy)
            {
                FinishMenu.SetActive(false);
            }
            if (!InGameMenu.activeInHierarchy)
            {
                InGameMenu.SetActive(true);
            }
        }
        
        private void OnEnable()
        {
            BusSystem.LevelFinish += LevelFinish;
            BusSystem.GameOverBb += GameOverBb;
        }

        private void OnDisable()
        {
            BusSystem.LevelFinish -= LevelFinish;
            BusSystem.GameOverBb -= GameOverBb;
        }

        public void PauseButton()
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            InGameMenu.SetActive(false);
        }
    
        public void ContinueButton()
        {
            if (PauseMenu.activeInHierarchy)
            {
                PauseMenu.SetActive(false);
                InGameMenu.SetActive(true);
                Time.timeScale = 1;
            }
            else if (FinishMenu.activeInHierarchy)
            {
                FinishMenu.SetActive(false);
                Time.timeScale = 1;
                GridManager.gridNumber += 1;
                BusSystem.GridSelector();
                BusSystem.ResetBall();
                BusSystem.PlayerReset();
                BusSystem.ResetScore();
                BusSystem.DestroyAllPowerBalls();
            }
        
        }
    
        public void HomeButton()
        {
            SceneManager.LoadScene("MainMenu");
        }
    
        public void RestartButton()
        {
            SceneManager.LoadScene("BrickBreakerGame");
        }

        private void LevelFinish()
        {
            Time.timeScale = 0;
            FinishMenu.SetActive(true);
        }

        private void GameOverBb()
        {
            EndMenu.SetActive(true);
            Time.timeScale = 0;
        }
    
    }
}
