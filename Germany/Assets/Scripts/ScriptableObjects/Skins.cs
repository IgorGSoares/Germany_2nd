using UnityEngine;


[CreateAssetMenu(fileName = "Skins", menuName = "Create New Skins", order = 0)]
public class Skins : ScriptableObject 
{
    public Sprite sprite;
    public string ID;
    public string nameSkin;
    public string description;
    public int price;
    public bool bought = false;
    public bool selected = false;
}
