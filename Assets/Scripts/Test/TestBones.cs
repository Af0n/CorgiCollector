using UnityEngine;

public class TestBones : MonoBehaviour
{
    public Corgi testCorg;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            testCorg.AddBones(2);
            Debug.Log(testCorg.BonesPercent);
        }
    }
}
