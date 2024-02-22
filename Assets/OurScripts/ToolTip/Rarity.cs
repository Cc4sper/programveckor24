using UnityEngine;

[CreateAssetMenu]

public class Rarity : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private Color rarity;


    public string Name { get { return name; } } // Hjälper till att skapa namn för rarity.

    public Color TextColor { get { return rarity; } } // Skapar färgen för rarity.
}