using UnityEngine;
using TMPro;

public abstract class Timer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _text;
    [SerializeField] protected float _timeRemaining;
    [SerializeField] protected int _decimals;
    [SerializeField] protected bool _isCountingDown;

    // Update is called once per frame
    void Update()
    {
        if (!_isCountingDown) return;

        _timeRemaining -= Time.deltaTime;

        if (_timeRemaining <= 0){
            _timeRemaining = 0;
            _isCountingDown = false;
            TimerEnded();
        }

        UpdateText();
    }

    protected abstract void TimerEnded();

    protected virtual void UpdateText(){
        _text.text = _timeRemaining.ToString($"F{_decimals}");
    }
}
