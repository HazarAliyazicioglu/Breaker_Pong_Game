using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenuScripts
{
    public class MainMenuUIManager : MonoBehaviour
    {
        public GameObject MainMenuPanel;
        public GameObject PlayPanel;
        public GameObject SettingsPanel;
    
        // Start is called before the first frame update
        void Start()
        {
        
            Time.timeScale = 1;
        
            if (SettingsPanel.activeInHierarchy)
            {
                SettingsPanel.SetActive(false);
            }

            if (PlayPanel.activeInHierarchy)
            {
                PlayPanel.SetActive(false);
            }

            if (!MainMenuPanel.activeInHierarchy)
            {
                MainMenuPanel.SetActive(true);
            }
        
        }

        public void ReturnButton()
        {
            if (PlayPanel.activeInHierarchy || !SettingsPanel.activeInHierarchy)
            {
                PlayPanel.SetActive(false);
                MainMenuPanel.SetActive(true);
            }
            else
            {
                SettingsPanel.SetActive(false);
                MainMenuPanel.SetActive(true);
            }
        }

        public void PlayButton()
        {
            MainMenuPanel.SetActive(false);
            PlayPanel.SetActive(true);
        }

        public void SettingsButton()
        {
            MainMenuPanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }

        public void TwoPlayersButton()
        {
            SceneManager.LoadScene("PongGame");
        } 

        public void OnePlayerButton()
        {
            SceneManager.LoadScene("BrickBreakerGame");
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}
