using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public float duration = 1f;
    private float _pendingFreezeDuration = 0f;

    bool _isFrozen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_pendingFreezeDuration > 0 && !_isFrozen)
        {
            StartCoroutine(DoFreeze());
        }
    }

    public void Freeze()
    {
        _pendingFreezeDuration = duration;
    }

    IEnumerator DoFreeze()
    {
        _isFrozen = true;
        var original = Time.timeScale;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = original;
        _pendingFreezeDuration = 0;
        _isFrozen = false;
    }
}
