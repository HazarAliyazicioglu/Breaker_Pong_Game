using TMPro;
using UnityEngine;

namespace BrickBreakerScripts
{
    public class ScoreManagerBB : MonoBehaviour
    {
        public TextMeshProUGUI scoreText1;
        public TextMeshProUGUI scoreText2;

        public int score = 0;
        // Start is called before the first frame update
        void Start()
        {
            ResetScore();
        }
        
        private void OnEnable()
        {
            BusSystem.AddScore += AddScore;
            BusSystem.ReduceScore += ReduceScore;
            BusSystem.ResetScore += ResetScore;
        }

        private void OnDisable()
        {
            BusSystem.AddScore -= AddScore;
            BusSystem.ReduceScore -= ReduceScore;
            BusSystem.ResetScore -= ResetScore;
        }

        private void AddScore()
        {
            score += 100;
            scoreText1.text = "Score: " + score;
            scoreText2.text = score.ToString();
        }

        private void ReduceScore()
        {
            if (score is 0)
            {
                score = 0;
            }
            else
            {
                score -= 100;
                scoreText1.text = "Score: " + score;
                scoreText2.text = score.ToString();
            }
        
        }

        private void ResetScore()
        {
            score = 0;
            scoreText1.text = "Score: " + 0;
        } 
    }
} 
