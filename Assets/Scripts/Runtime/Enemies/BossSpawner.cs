using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossSpawner : MonoBehaviour
{
   [SerializeField] private GameObject boss;
   public float DelayTime;
   private bool BossSpawned;
   private float Gameplaytime;
   [SerializeField] private GameStateSO state;
   [SerializeField]private Slider mapMeter;
   [SerializeField] private UnityEvent dangerEvent;
   private bool isInvokeEvent;

   private void Awake()
   {
       isInvokeEvent = false;
       mapMeter.maxValue = DelayTime;
   }

   private void Start()
   {
       BossSpawned = false;
   }
   private void Update()
   {
       if (state.State == GameStateSO.GameState.PlayGame)
       {
           Gameplaytime += Time.deltaTime;
           mapMeter.value += Time.deltaTime;
       }

       if (Gameplaytime > DelayTime - 5f&&!isInvokeEvent)
       {
           dangerEvent.Invoke();
           isInvokeEvent = true;
       }
       
       if (Gameplaytime> DelayTime)
       {
           var newBoss= Instantiate(boss, transform.position, Quaternion.identity);
           newBoss.transform.parent = transform;
           BossSpawned = true;
           state.BossFight();
           DelayTime = Mathf.Infinity;
       }

       if (transform.childCount == 0 && BossSpawned)
       {
           BossKilled();
       }
   }
   public void BossKilled()
   {
       state.BossKilled();
   }
}
