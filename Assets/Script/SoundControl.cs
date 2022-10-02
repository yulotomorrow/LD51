using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource au;
    public int delay = 2;
    public int correctDelay = 0;
    public GameObject gearUI;
    public GameObject clockHand;
    private float count = 0;
    private float unit = 0.5f;
    private Color c1;
    private Color c2;
    void OnEnable()
    {
        au = GetComponent<AudioSource>();       
        unit = 0.3125f;
        count = -(float)delay * unit;
        c1 = new Color(0.54f, 0.44f, 0.44f);
        c2 = new Color(0.99f, 0.92f, 0.73f);
        if(delay == correctDelay)
        {
            clockHand.GetComponent<SpriteRenderer>().color = c2;
        }
    }
    private void FixedUpdate()
    {
        count += Time.fixedDeltaTime;
        if (count > 2.61f)
            count -= 2.5f;
        if (count < 2.61 && count > 2.59)
        {   
            au.Play();
            count -= 2.5f;
        }
    }
    void TuneTime(bool dir) 
    {
        int newU = dir == true ? 1 : -1;
        count += newU * unit;
        delay -= (int)newU;
        delay %= 8;
        if (delay < 0)
            delay += 8;
        if (delay == correctDelay)
        {
            clockHand.GetComponent<SpriteRenderer>().color = c2;
        }
        else
        {
            clockHand.GetComponent<SpriteRenderer>().color = c1;
        }
    }
    IEnumerator PlaySoundPeriod(float d) 
    {
        yield return new WaitForSecondsRealtime(d);
        while (true) 
        {
            au.Play();
            yield return new WaitForSecondsRealtime(10.0f);
        }
    }
    private void OnMouseDown()
    {
        gearUI.SetActive(true);
        GearEventController.onGearTurn.RemoveAllListeners();
        GearEventController.onGearTurn.AddListener(TuneTime);
    }
    public void ScriptedChange() 
    {
        count += 2 * unit;
        delay = 0;
        clockHand.GetComponent<SpriteRenderer>().color = c2;
    }
}
