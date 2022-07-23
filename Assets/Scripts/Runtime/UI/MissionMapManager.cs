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
   private Sequence mySequence;
   private void Start()
   {
      targetMission.SetActive(true);
   }

   private void Update()
   {
      CheckCurrentMission();
   }

   private void CheckCurrentMission()
   {
      TargetMission(currentMission.Value);
   }

   public void TargetMission(int i)
   {
      mySequence = DOTween.Sequence();
      mySequence.Append(targetMission.transform.DOMove(missions[i].transform.position,3f));
      mySequence.Insert(0,targetMission.transform.DOScale(0.3f,2f));
      StartCoroutine(WaitToEnableImage(2,i));
      
   }
   IEnumerator WaitToEnableImage(float time, int i)
   {
      var missionDes = missions[i].transform.GetChild(0);
      yield return new WaitForSeconds(time);
      if (targetMission.activeSelf)
      { targetMission.SetActive(false);
      }
     
      missionDes.gameObject.SetActive(true);
   }

}
