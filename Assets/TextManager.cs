using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float timeToDisable;
    public void TextEnable()
    {
        StartCoroutine(WaitToDisable(timeToDisable));
    }

    IEnumerator WaitToDisable(float time)
    {
        text.enabled = true;
        yield return new WaitForSeconds(time);
        text.enabled = false;
    }
}
