using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TagButtonManager : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI fluffText, biteText, chonkText;
    public string endMessage;

    public bool Evaluate(int ownedTags, int tagLevel){
        // if not max tags and we have tags to give
        bool test = tagLevel < 10 && ownedTags > 0;
        button.interactable = test;
        return test;
    }
}
