using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScoreUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Max Score: " + PlayerPrefs.GetInt("MaxScore", 0);
    }
}
