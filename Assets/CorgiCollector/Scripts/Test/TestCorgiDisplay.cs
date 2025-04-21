using UnityEngine;

public class TestCorgiDisplay : MonoBehaviour
{
    public PopulateDisplay popul;
    public Corgi testCorg;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            popul.DoDisplay(testCorg);
        }
    }
}
