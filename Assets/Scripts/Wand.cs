using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour, IWand
{
    [SerializeField]
    public GameObject WandModel;
    [SerializeField]
    public WandLength Length;
    [SerializeField]
    public WandWood Wood;
    [SerializeField]
    public WandCore Core;

    // Start is called before the first frame update
    void Start()
    {
        switch (Length)
        {
            case WandLength.Short:
                WandModel.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                WandModel.transform.localPosition = new Vector3(0f, 0f, 0.65f);
                break;
            case WandLength.Medium:
                WandModel.transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
                WandModel.transform.localPosition = new Vector3(0f, 0f, 0.75f);
                break;
            case WandLength.Long:
                WandModel.transform.localScale = new Vector3(0.1f, 0.7f, 0.1f);
                WandModel.transform.localPosition = new Vector3(0f, 0f, 0.85f);
                break;
            default:
                break;
        }

        if (Length == WandLength.Short)
        {
            
        }
        else if (Length == WandLength.Long)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum WandLength
    {
        Short,
        Medium,
        Long
    }

    public enum WandWood
    {
        Birch,
        Maple,
        RedOak,
        Cedar,
        Walnut
    }

    public enum WandCore
    {
        ArachneaWeb,
        StormGiantsBeard,
        PhoenixFeather,
        MerfolkScale,
        UnicornHeart
    }
}
