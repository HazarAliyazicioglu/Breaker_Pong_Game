using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BrickBreakerScripts
{
    public class PowerBallManager : MonoBehaviour
    {
        public List<GameObject> powerBalls;
        public GameObject ball;
        public static PowerBallManager instance { get; private set; }

        private GameObject powerBall;
        private int ballSelector;
        private int chance;
        
        // Start is called before the first frame update
        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            BusSystem.PowerBallSpawner += PowerBallSpawner;
            BusSystem.DestroyAllPowerBalls += DestroyAllPowerBalls;
        }

        private void OnDisable()
        {
            BusSystem.PowerBallSpawner -= PowerBallSpawner;
            BusSystem.DestroyAllPowerBalls -= DestroyAllPowerBalls;
        }
        
        private void PowerBallSpawner(Vector3 position)
        {
            ballSelector = Random.Range(0, 5);
            chance = Random.Range(1, 10);
            if (chance is 9 or 10)
            {
                powerBall = Instantiate(powerBalls[ballSelector], position, Quaternion.identity);
            }
        }

        private void DestroyAllPowerBalls()
        {
            Destroy(powerBall);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (powerBall)
            {
                
            }
        }
    }
}
