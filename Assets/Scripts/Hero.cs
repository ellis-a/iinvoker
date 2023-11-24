using UnityEngine;

class Hero : MonoBehaviour
{
    public string Name;
    //private HeroClass HeroClass;
    public int MaxHealth;
    public int CurrentHealth;

    [Header("Attributes")]
    public int Power = 10;
    public int Alacrity = 10;
    public int Focus = 10;
    public int Will = 10;
    public int Charm = 10;

    public Hero(bool generateRandom = false)
    {
        if (generateRandom)
        {
            //TODO: Add random name generation
            Name = "";
            Power = Random.Range(5, 15);
            Alacrity = Random.Range(5, 15);
            Focus = Random.Range(5, 15);
            Will = Random.Range(5, 15);
            Charm = Random.Range(5, 15);
        }

        MaxHealth = 100 + (Will * 10);
        CurrentHealth = MaxHealth;
    }

    public static Hero GenerateRandomHero()
    {
        return new Hero(true);
    }
}