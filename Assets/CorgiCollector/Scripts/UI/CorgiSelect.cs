using UnityEngine;
using UnityEngine.UI;

public class CorgiSelect : MonoBehaviour
{
    public GameObject corgiBoxPrefab;
    public PopulateDisplay pop;
    
    private GameObject[] corgis;

    void Awake()
    {
        corgis = Resources.LoadAll<GameObject>("Corgis");

        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        float width = GetComponent<RectTransform>().rect.width;
        grid.cellSize = new(width/3, width/3);

        PopulateArray();
    }

    public void PopulateArray(){
        foreach (GameObject corgi in corgis)
        {
            GameObject obj = Instantiate(corgiBoxPrefab, transform);

            CorgiBox corgiBox = obj.GetComponent<CorgiBox>();
            corgiBox.bttn.onClick.AddListener(() => pop.DoDisplay(corgiBox.corgi));
            corgiBox.SetCorgi(corgi);

            
        }
    }
}
