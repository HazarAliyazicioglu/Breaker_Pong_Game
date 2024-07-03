using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreakerScripts
{
    public class GridManager : MonoBehaviour
    {
        private GameObject grid;
        private List<GameObject> childs;
    
        public List<GameObject> grids;
        public static float childCount;
        public static int gridNumber = 0;
    
        // Start is called before the first frame update
        public void Start()
        {
            GridSelecter();
            GetChildNumber();
        }

        private void Update()
        {
            GridsFinished();
        }

        private void OnEnable()
        {
            BusSystem.BrickReducer += BrickReducer;
            BusSystem.GridSelector += GridSelecter;
            BusSystem.GridSelector += GetChildNumber;
        }

        private void OnDisable()
        {
            BusSystem.BrickReducer -= BrickReducer;
            BusSystem.GridSelector -= GridSelecter;
            BusSystem.GridSelector -= GetChildNumber;
        }

        private void GetChildNumber()
        {
            childs = new List<GameObject>();
            foreach (Transform grid in grid.transform)
            {
                // childs.Add(this.grid.gameObject);   buradaki this.grid daha önce yukarıda tanımladığımız Gameobject olan gridi kullanıyor 
                childs.Add(grid.gameObject);
            }

            childCount = childs.Count;
        }

        private void GridSelecter()
        {
            grid = grids[gridNumber];
            grid.SetActive(true);
        }

        private void BrickReducer()
        {
            childCount -= 1;
        }

        private void GridsFinished()
        {
            if (gridNumber is 3 && childCount is 0)
            {
                BusSystem.GameOverBb();
            }
        }
    }
}
