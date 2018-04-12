

using UnityEngine;

public struct CustomTimer
{
    private float currentTime;
    private float endTime;

    public CustomTimer(float endTime)
    {
        this.currentTime = 0f;
        this.endTime = endTime;
    }

    public bool Playing()
    {
        currentTime += Time.deltaTime;

        if (currentTime < endTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Playing(float endTime)
    {
        currentTime += Time.deltaTime;

        if (currentTime < endTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetTimer()
    {
        SetCurrentTime(0f);
    }

    public void ResetTimer(float currentTimer)
    {
        SetCurrentTime(currentTime);
    }

    public void SetCurrentTime(float time)
    {
        currentTime = time;
    }
}