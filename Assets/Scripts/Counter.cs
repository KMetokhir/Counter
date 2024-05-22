using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _currentNumber;
    private float _waitingInterval;
    private bool _isRunning;
    private Coroutine _countCoroutine;

    private KeyCode _startPauseButton = KeyCode.Mouse0;

    public event Action<int> ValueChanged;

    private void Awake()
    {
        _currentNumber = 0;
        _waitingInterval = 0.5f;
        _isRunning = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_startPauseButton))
        {
            _isRunning = !_isRunning;            

            if (_isRunning == false)
            {
                if (_countCoroutine != null)
                {
                    StopCoroutine(_countCoroutine);
                }
            }
            else 
            {
                _countCoroutine = StartCoroutine(Count());
            }            
        }
    }

    private IEnumerator Count()
    {
        WaitForSeconds waitingTime = new WaitForSeconds(_waitingInterval);

        while (_isRunning)
        {
            _currentNumber++;
            ValueChanged?.Invoke(_currentNumber);

            yield return waitingTime;
        }
    }
}
