using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using Runtime;
using UnityEngine;
using UnityEngine.UI;

public class MissionMapManager : MonoBehaviour
{
   [SerializeField] private IntVariable currentMission;
   [SerializeField] private List<GameObject> missions;
   [SerializeField] private GameObject targetMission;
 
   [SerializeField] private GameObject finishImage;
 
   private void Start()
   {
   
      targetMission.SetActive(true);
   }

   private void Update()
   {
      
      if (currentMission.Value >= 3)
      {
         finishImage.SetActive(true);
         return;
      }
      CheckCurrentMission();
   }

   private void CheckCurrentMission()
   {
      TargetMission(currentMission.Value);
   }
   public void TargetMission(int i)
   {
      var missionDes = missions[i].transform.GetChild(0);
      targetMission.transform.position =missions[i].transform.position;
      targetMission.transform.localScale =new Vector3(0.3f,0.3f,0.3f);
      /*if (!(_delayTime > 2)) return;*/
      if (targetMission.activeSelf)
      { 
         targetMission.SetActive(false);
      }
      missionDes.gameObject.SetActive(true);
   }
}

