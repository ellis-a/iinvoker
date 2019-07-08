using UnityEngine;

public class SummonElement : MonoBehaviour
{
    private string _element1;
    private string _element2;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _element1 = "fire";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _element1 = "water";
        }
    }
}
