using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float timeToDisable;
    public void TextEnable()
    {
        StartCoroutine(WaitToDisable(timeToDisable));
    }

    IEnumerator WaitToDisable(float time)
    {
        image.enabled = true;
        yield return new WaitForSeconds(time);
        image.enabled = false;
    }
}
