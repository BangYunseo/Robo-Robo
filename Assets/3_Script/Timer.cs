﻿using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
    private Text _timer;
    private float _timerForText;
    private int _secText;
    private int _minText;


	// Use this for initialization
	void Start () {
        if(_timer == null){
            Debug.LogError("Time Text 설정 필수!");
        }
	}
	
	// Update is called once per frame
	void Update () {

        _timerForText += Time.deltaTime;

        if (_timerForText > 1.0f)
        {
            _secText += 1;
            if (_secText > 60)
            {
                _minText += 1;
                _secText = 0;
            }
            _timer.text = string.Format("{0:D2}:{1:D2}", _minText, _secText);
            
            //_timer.text = string.Format("{0:D2}", _minText.ToString()) + ":" + string.Format("{0:D2}", _secText.ToString());
            _timerForText = 0;
        }

	
	}
}
