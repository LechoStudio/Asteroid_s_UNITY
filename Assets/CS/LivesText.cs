using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesText : MonoBehaviour
{
    private Text _textAsset;
    

    private void Awake()
    {
        _textAsset = GetComponent<Text>();
    }
    // Start is called before the first frame update
    public void LivesChange(int lives)
    {
        
        _textAsset.text = "Live's: " + lives.ToString();
    }
}
