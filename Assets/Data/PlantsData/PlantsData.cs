using UnityEngine;

[CreateAssetMenu(fileName = "New Plant Data", menuName = "Data/Plant Data")]
public class PlantsData : ScriptableObject
{
    public int growthTime;
    public AllPlants allPlants;
    public int yieldAmount;
    public Sprite seedSprite;
    public Sprite grownPlantSprite;
}
