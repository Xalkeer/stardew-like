using UnityEngine;

public class plantsInstance : MonoBehaviour
{
    public PlantsData plantsData;
    public SpriteRenderer sr;
    
    public int growthTime;
    public AllPlants allPlants;
    public int yieldAmount;
    public Sprite seedSprite;
    public Sprite grownPlantSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (plantsData != null)
        {
            Debug.Log(plantsData);
            sr.sprite = plantsData.grownPlantSprite;
        }
    }
}
