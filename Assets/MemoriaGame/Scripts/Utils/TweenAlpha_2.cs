//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tween the object's alpha.
/// </summary>

public class TweenAlpha_2 : UITweener
{
    #if UNITY_3_5
	public float from = 1f;
	public float to = 1f;





#else
    [Range (0f, 1f)] public float from = 1f;
    [Range (0f, 1f)] public float to = 1f;
    #endif

    CanvasGroup mRect;

    public CanvasGroup cachedRect {
        get {
            if (mRect == null) {
                mRect = GetComponent<CanvasGroup> ();
                if (mRect == null)
                    mRect = GetComponentInChildren<CanvasGroup> ();
            }
            return mRect;
        }
    }

    [System.Obsolete ("Use 'value' instead")]
    public float alpha { get { return this.value; } set { this.value = value; } }

    /// <summary>
    /// Tween's current value.
    /// </summary>

    public float value { get { return cachedRect.alpha; } set { cachedRect.alpha = value; } }

    /// <summary>
    /// Tween the value.
    /// </summary>

    protected override void OnUpdate (float factor, bool isFinished)
    {
        value = Mathf.Lerp (from, to, factor);
    }

    /// <summary>
    /// Start the tweening operation.
    /// </summary>

    static public TweenAlpha_2 Begin (GameObject go, float duration, float alpha)
    {
        TweenAlpha_2 comp = UITweener.Begin<TweenAlpha_2> (go, duration);
        comp.from = comp.value;
        comp.to = alpha;

        if (duration <= 0f) {
            comp.Sample (1f, true);
            comp.enabled = false;
        }
        return comp;
    }

    public override void SetStartToCurrentValue ()
    {
        from = value;
    }

    public override void SetEndToCurrentValue ()
    {
        to = value;
    }
}
