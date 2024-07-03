using TMPro;
using UnityEngine;

namespace PongGameScripts
{
    public class ScoreManager : MonoBehaviour
    {
    
        [SerializeField] private TextMeshProUGUI p1ScoreText;
        [SerializeField] private TextMeshProUGUI p2ScoreText;
        [SerializeField] private int p1Score;
        [SerializeField] private int p2Score;
        private void Start()
        {
            BusSystem.AddScoreOne += AddScorePlayerOne;
            BusSystem.AddScoreTwo += AddScorePlayerTwo;
            p2Score = 0;
            p1Score = 0;
        }

        public void AddScorePlayerOne()
        {
            p1Score += 1;
            p1ScoreText.text = p1Score.ToString();
        }
        public void AddScorePlayerTwo()
        {
            p2Score+= 1;
            p2ScoreText.text = p2Score.ToString();
        }
    
    }
}
