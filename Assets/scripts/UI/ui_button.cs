using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ui_button : MonoBehaviour
{
    public void CallJump()
    {
        mainchar.Instance.Jump();
    }


    

    public void CallSlide()
    {
        mainchar.Instance.Slide();
    }

    public void CallSlideEnd()
    {
        mainchar.Instance.SlideEnd();
    }
    
}
