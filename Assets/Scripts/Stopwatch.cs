using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;

    private TextMeshProUGUI _buttonText;
    private Coroutine _coroutine;
    private bool _isTuongleOn = false;
    private int _counter = 0;

    private string _startText = "START";
    private string _pauseText = "PAUSE";
    private string _defoultTimerText = "";

    private void Start()
    {
        _text.text = _defoultTimerText;
        _buttonText = _button.GetComponentInChildren<TextMeshProUGUI>();
        _buttonText.text = _startText;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchTimer);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchTimer);
    }

    private void SwitchTimer()
    {
        if (_isTuongleOn)
        {
            _isTuongleOn = false;
            _buttonText.text = _startText;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
        else
        {
            _isTuongleOn = true;
            _buttonText.text = _pauseText;
            _coroutine = StartCoroutine(Countdown(0.5f));
        }
    }

    private IEnumerator Countdown(float delay, int start = 0)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return wait;

            _counter++;

            DisplayCountdown(_counter);
        }
    }

    private void DisplayCountdown(int count) 
    {
        _text.text = count.ToString(_defoultTimerText);
    }
}
