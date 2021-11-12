using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    public Animator transitionAnim;

    public void Transition()
    {
        transitionAnim.SetTrigger("End");
    }

}
