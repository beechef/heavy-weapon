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
   private float delayTime;
   private void Start()
   {
      targetMission.SetActive(true);
   }

   private void OnEnable()
   {
      delayTime = 2;
   }

   private void Update()
   {
      delayTime -= Time.deltaTime;
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
      targetMission.transform.DOMove(missions[i].transform.position,1.5f);
      targetMission.transform.DOScale(0.3f, 1f);
      if (delayTime <= 0)
      {
         if (targetMission.activeSelf) 
         { 
            targetMission.SetActive(false);
         }
         missionDes.gameObject.SetActive(true);
         delayTime = Mathf.Infinity;
      }
    
   }
}

