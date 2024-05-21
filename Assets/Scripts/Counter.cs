using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> ValueChanged;

    private int _currentNumber;
    private float _waitingInterval;
    private bool _isRunning;

    private void Awake()
    {
        _currentNumber = 0;
        _waitingInterval = 0.5f;
        _isRunning = false;

        StartCoroutine(Count(_waitingInterval));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isRunning = !_isRunning;

            StartCoroutine(Count(_waitingInterval));
        }
    }

    private IEnumerator Count(float waitingInterval)
    {
        WaitForSeconds waitingTime = new WaitForSeconds(waitingInterval);

        while (_isRunning)
        {
            _currentNumber++;
            ValueChanged?.Invoke(_currentNumber);
            
            yield return waitingTime;
        }
    }
}
