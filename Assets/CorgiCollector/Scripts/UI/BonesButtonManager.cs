using System;
using UnityEngine;
using UnityEngine.UI;

public class BonesButtonManager : MonoBehaviour
{
    [Serializable]
    public class Buttonpair{
        public Button button;
        public int minimum;
        public bool interactable;

        public void Apply(){
            button.interactable = interactable;
        }
    }

    public Buttonpair[] Buttonpairs;

    public void EvaluateButtons(int corgiBones, int owned){
        foreach (Buttonpair pair in Buttonpairs)
        {
            // have enough bones
            pair.interactable = owned >= pair.minimum;

            // corgi not at max bones
            pair.interactable = pair.interactable && corgiBones < 5050;
            pair.Apply();
        }
    }
}
