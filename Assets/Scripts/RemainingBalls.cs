using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingBalls : MonoBehaviour {
    public enum AnimationState
    {
        Idle,
        RampUp,
        RampDown
    }

    public Text text;
    public Material EdgeMaterial;
    public Color DefaultColor;
    public Color EffectColor;
    public float RampUpTime = 0.8f;
    public float RampDownTime = 2f;
    private float _currentStepStartTime = 0f;
    private AnimationState _aminationState = AnimationState.Idle;
    private int _numBalls = 3;

    void Start()
    {
        SetRemainingBalls(3, 0);
    }

    void Update()
    {
        var timeInAnimationStep = Time.time - _currentStepStartTime;

        switch (_aminationState)
        {
            case AnimationState.Idle:
                break;
            case AnimationState.RampUp:
                if (timeInAnimationStep > RampUpTime)
                {
                    _aminationState = AnimationState.RampDown;
                    _currentStepStartTime = Time.time;
                }
                var color = Color.Lerp(DefaultColor, EffectColor, timeInAnimationStep / RampUpTime);
                EdgeMaterial.SetColor("_EmissionColor", color);
                break;
            case AnimationState.RampDown:
                if (timeInAnimationStep > RampDownTime)
                {
                    _aminationState = AnimationState.Idle;
                    _currentStepStartTime = Time.time;
                }
                color = Color.Lerp(EffectColor, DefaultColor, timeInAnimationStep / RampDownTime);
                EdgeMaterial.SetColor("_EmissionColor", color);
                break;
        }
    }
	
    public void SetRemainingBalls(int numBalls, int splashes)
    {
        text.text = string.Format("Remaining Balls: {0} Splashes in World: {1}", numBalls, splashes);
        if (_numBalls != numBalls)
        {
            _numBalls = numBalls;
            _aminationState = AnimationState.RampUp;
            _currentStepStartTime = Time.time;
        }
    }
    
}
