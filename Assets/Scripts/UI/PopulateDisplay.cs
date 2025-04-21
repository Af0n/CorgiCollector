using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateDisplay : MonoBehaviour
{
    public Transform Container;
    public Transform LevelPanel;
    [Header("Texts")]
    public TextMeshProUGUI TitleDisplay;
    public TextMeshProUGUI LevelDisplay;
    public TextMeshProUGUI LevelUpLabel;
    public TextMeshProUGUI FluffDisplay;
    public TextMeshProUGUI BiteDisplay;
    public TextMeshProUGUI ChonkDisplay;
    public TextMeshProUGUI TagFluffDisplay;
    public TextMeshProUGUI TagBiteDisplay;
    public TextMeshProUGUI TagChonkDisplay;
    [Header("Transforms")]
    public Transform TagsDisplay;
    [Header("Images")]
    public Image FlavorDisplay;
    public Image LevelBG;
    public Image Progress;
    public Image WhatIf;
    [Header("Misc")]
    public Corgi TargetCorgi;
    public FlavorColors flavorColors;
    [Header("Animators")]
    public Animator ContainerAnim;
    public Animator LevelPanelAnim;
    public Animator TagsPanelAnim;
    public Animator TabsAnim;
    [Header("Messages")]
    public string levelLabelMssg;
    public string noMoreLevelMssg;
    public string tagNoMoreMssg;
    [Header("Testing")]
    public int testOwnedBones;
    public int testOwnedTags;

    private BonesButtonManager bonesButtonManager;
    private TagButtonManager tagButtonManager;

    private List<Transform> tags;

    void Awake()
    {
        bonesButtonManager = GetComponent<BonesButtonManager>();
        tagButtonManager = GetComponent<TagButtonManager>();

        // tagChildren[0] is the parent TagsDisplay transform
        Transform[] tagChildren = TagsDisplay.GetComponentsInChildren<Transform>();
        tags = new();
        tags.AddRange(tagChildren);
        // remove parent
        tags.RemoveAt(0);

        if (TargetCorgi == null)
        {
            return;
        }

        DisplayCorgi();
    }

    public void DisplayCorgi()
    {
        LevelPanelAnim.SetBool("Toggled", false);
        TagsPanelAnim.SetBool("Toggled", false);
        ContainerAnim.SetBool("Toggled", false);
        TabsAnim.SetBool("Toggled", false);

        TitleDisplay.text = TargetCorgi.Title;

        Color flavorColor = flavorColors.GetFlavorColor(TargetCorgi.flavor);
        Color accentColor = flavorColors.GetFlavorAccentColor(TargetCorgi.flavor);

        FlavorDisplay.sprite = flavorColors.GetFlavorSprite(TargetCorgi.flavor);
        FlavorDisplay.color = flavorColor;

        LevelBG.color = accentColor;

        Progress.color = flavorColor;

        WhatIf.color = accentColor;
        WhatIf.fillAmount = TargetCorgi.BonesPercent;

        UpdateCorgi();

        ContainerAnim.SetBool("Toggled", true);
        TabsAnim.SetBool("Toggled", true);
    }

    // should only be called when the corgi display is already populated
    public void UpdateCorgi()
    {
        LevelDisplay.text = TargetCorgi.level.ToString();

        if(TargetCorgi.IsMaxLevel){
            LevelUpLabel.text = noMoreLevelMssg;
        }else{
            LevelUpLabel.text = levelLabelMssg;
        }
        
        Progress.fillAmount = TargetCorgi.BonesPercent;

        SetTags(TargetCorgi.tagLevel, TargetCorgi.flavor);

        FluffDisplay.text = TargetCorgi.InnateFluff.ToString();
        BiteDisplay.text = TargetCorgi.InnateBite.ToString();
        ChonkDisplay.text = TargetCorgi.InnateChonk.ToString();

        // [TODO] replace with bones money script later
        bool showTagTexts = tagButtonManager.Evaluate(testOwnedTags, TargetCorgi.tagLevel);

        if(showTagTexts){
            TagFluffDisplay.text = TargetCorgi.WhatIfFluff.ToString();
            TagBiteDisplay.text = TargetCorgi.WhatIfBite.ToString();
            TagChonkDisplay.text = TargetCorgi.WhatIfChonk.ToString();
        }else{
            TagFluffDisplay.text = tagNoMoreMssg;
            TagBiteDisplay.text = tagNoMoreMssg;
            TagChonkDisplay.text = tagNoMoreMssg;
        }

        // [TODO] replace with tags money script later
        bonesButtonManager.EvaluateButtons(TargetCorgi.bones, testOwnedBones);
    }

    public void SetTags(int count, Flavor flavor)
    {
        // initially set all to be inactive
        foreach (Transform tag in tags)
        {
            tag.gameObject.SetActive(false);
            tag.GetComponent<Image>().color = flavorColors.GetFlavorColor(flavor);
        }

        // Debug.Log(count);
        // activate needed tags
        count = Mathf.Min(10, count);
        for (int i = 0; i < count; i++)
        {
            tags[i].gameObject.SetActive(true);
        }
    }

    public void DoDisplay(Corgi corgi)
    {
        TargetCorgi = corgi;
        DisplayCorgi();
    }

    public void AddBones(int bones){
        TargetCorgi.AddBones(bones);
        testOwnedBones -= bones;
    }

    public void WhatIfDisplay(int testBones){
        float amount = TargetCorgi.WhatIfBonesPercent(testBones);
        // Debug.Log(amount);
        WhatIf.fillAmount = amount;
    }

    public void ResetWhatIf(){
        WhatIf.fillAmount = TargetCorgi.BonesPercent;
    }

    public void ToggleLevelPanel(){
        LevelPanelAnim.SetBool("Toggled", !LevelPanelAnim.GetBool("Toggled"));
    }

    public void ToggleTagPanel(){
        TagsPanelAnim.SetBool("Toggled", !TagsPanelAnim.GetBool("Toggled"));
    }

    public void CloseLevelPanel(){
        LevelPanelAnim.SetBool("Toggled", false);
    }

    public void CloseTagPanel(){
        TagsPanelAnim.SetBool("Toggled", false);
    }

    public void CloseDisplay(){
        ContainerAnim.SetBool("Toggled", false);
        LevelPanelAnim.SetBool("Toggled", false);
        TagsPanelAnim.SetBool("Toggled", false);
        TabsAnim.SetBool("Toggled", false);
    }

    public void AddTag(){
        TargetCorgi.AddTag();
        testOwnedTags--;
    }
}
