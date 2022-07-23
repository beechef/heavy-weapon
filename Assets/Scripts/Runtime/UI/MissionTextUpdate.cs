using System.Collections;
using System.Collections.Generic;
using Runtime;
using TMPro;
using UnityEngine;

public class MissionTextUpdate : MonoBehaviour
{
    [SerializeField] private IntVariable currentMission;

    [SerializeField] private TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = "M" + currentMission.Value.ToString();
    }
}
