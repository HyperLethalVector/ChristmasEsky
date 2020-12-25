﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimated : MonoBehaviour
{
    public AnimationCurve SpringAnimationCurveX;
    public AnimationCurve SpringAnimationCurveY;
    public AnimationCurve SpringAnimationCurveZ;
    public bool isActiveStart = false;
    public bool disableOnStart = false;
    bool isIn = false;
    float timeAt = 0;
    public float TimeToAnimate = 1;//just assume 1
    Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        isIn = isActiveStart;
        originalScale = transform.localScale;
        if(isIn){
            timeAt = 1;
        }else{
            timeAt = 0;
            transform.localScale = new Vector3(0.0000001f,0.0000001f,0.0000001f);
        }
        if(disableOnStart){
            gameObject.SetActive(false);
        }
    }
    public void SetIn(bool value){
        isIn = value;
    }
    // Update is called once per frame
    void Update()
    {
        if(isIn){
            if(timeAt < 1){
                timeAt += Time.deltaTime / TimeToAnimate; 

                Vector3 nn = originalScale;
                nn.Scale(new Vector3(SpringAnimationCurveX.Evaluate(timeAt),SpringAnimationCurveY.Evaluate(timeAt),SpringAnimationCurveZ.Evaluate(timeAt)));
                transform.localScale = nn;                
            }else{
                transform.localScale = originalScale;
            }
        }else{
            if(timeAt > 0){
                timeAt -= Time.deltaTime / TimeToAnimate; 
                Vector3 nn = originalScale;
                nn.Scale(new Vector3(SpringAnimationCurveX.Evaluate(timeAt),SpringAnimationCurveY.Evaluate(timeAt),SpringAnimationCurveZ.Evaluate(timeAt)));
                transform.localScale = nn;
            }else{
                transform.localScale = new Vector3(0.0000001f,0.0000001f,0.0000001f);
            }            
        }
    }
}
