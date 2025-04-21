using UnityEngine;
using UnityEngine.UI;

public class CorgiBox : MonoBehaviour
{
    public FlavorColors colors;
    public Image bg, portrait;
    public Button bttn;

    private GameObject corgiPrefab;
    public Corgi corgi;

    public void SetCorgi(GameObject c){
        corgiPrefab = c;
        corgi = corgiPrefab.GetComponent<Corgi>();
        
        ShowCorgi();
    }

    public void ShowCorgi(){
        bg.color = colors.GetFlavorAccentColor(corgi.Flavor);
        portrait.sprite = corgi.Portrait;
    }
}
