using TMPro;
using UnityEngine;

public class CounterView: MonoBehaviour
{
    private Counter _counter;
    private TMP_Text _textComponent;

    private void Awake()
    {
        _textComponent = GetComponent<TMP_Text>();
        _counter = GetComponent<Counter>();
    }

    private void OnEnable()
    {
        _counter.ValueChanged += OnCounterValueChanged;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnCounterValueChanged;
    }

    private void OnCounterValueChanged(int value)
    {
        _textComponent.text = value.ToString();
    }
}
