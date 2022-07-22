using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
   [SerializeField] private Image cursorImg;

   private void Start()
   {
     Cursor.visible = false;
   }

   private void Update()
   {
      cursorImg.rectTransform.position = Input.mousePosition;
   }
}
