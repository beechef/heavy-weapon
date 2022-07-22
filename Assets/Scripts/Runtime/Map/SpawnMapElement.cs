using System.Collections.Generic;
using UnityEngine;

public class SpawnMapElement : MonoBehaviour
{
   //[SerializeField] private GameStateSO gameState;
   [SerializeField] private List<MapElement> elementsToSpawn;
   private float timeToSpawm=0;

   private void Update()
   {
      timeToSpawm += Time.time;
      for (int i = 0; i < elementsToSpawn.Count; i++)
      {
         if (timeToSpawm >= 3)
         {
            var mapElement =Instantiate(elementsToSpawn[i].objectToSpawn, transform.position, Quaternion.identity);
            mapElement.transform.parent = this.transform.GetChild(0).GetChild(1);
            timeToSpawm = Mathf.NegativeInfinity;
         }
      }
   }
}
