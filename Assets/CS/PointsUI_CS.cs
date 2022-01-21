using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI_CS : MonoBehaviour
{
    private Text _textAsset;
    private int points = 0;
    
    private void Awake()
    {
        _textAsset = GetComponent<Text>();
    }
    public void addPoint() 
    {
        points++;
        _textAsset.text = "Point's: " + points.ToString();
    }
}
