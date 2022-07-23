using System;
using System.Collections;
using System.Collections.Generic;
using Runtime;
using TMPro;
using UnityEngine;

public class UpdatePoint : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI text;
   [SerializeField] private IntVariable point;

   private void Update()
   {
      text.text = point.Value.ToString();
   }
}
