using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fasteroids.DataLayer
{
    [System.Serializable] public class SpaceShipsData
    {
        public ShipData fleet;

    }
    [System.Serializable]public class ShipData
    {
        public ShipNames[] SpaceShipData;

    }
    [System.Serializable]public class ShipNames
    {
        public string Name;
    }
    public class SpaceshipRepository : IRepository
    {
        public SpaceShipsData ship;
        public void LoadData() 
        {
            string loadedData = Resources.Load<TextAsset>("spaceships")?.text;
            loadedData = "{\"fleet\":" + loadedData + "}";
            ship = JsonUtility.FromJson<SpaceShipsData>(loadedData);
            
        }


    }
}
