using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState 
    {
        Off,
        On,
        Blink
    }
    public Collider Bola;
    private new Renderer renderer;
    public Material matsoff;
    public Material matson;
    public ScoreManager scoreManager;
    public float score;

    private SwitchState state;
    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == Bola) 
        {
            Toggle();
        }
    }
    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = matson;
            StopAllCoroutines();
        }
        else 
        {
            state = SwitchState.Off;
            renderer.material = matsoff;
            StartCoroutine(BlinkTimerStart(5));
        }
        
    }

    private void Toggle() 
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else 
        {
            Set(true);
        }
        scoreManager.AddScore(score);
    }
    private IEnumerator Blink(int times) 
    {
        state = SwitchState.Blink;

        int blinkTimes = times * 2;
        for (int i = 0; i < blinkTimes; i++) 
        {
            renderer.material = matson;
            yield return new WaitForSeconds(0.5f);
            renderer.material = matsoff;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time) 
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
    
}

