using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlantsManager : MonoBehaviour
{

    public GameObject plantPrefab;
    public List<AllPlants> allPlants;
    public List<PlantsData> plantsDataList;
    public AllPlants selectedPlant;

    public bool isPlanting;

    public void SetIsPlanting(bool value)
    {
        isPlanting = value;
    }
    
    
    GameObject updateData()
    {
        GameObject plant = plantPrefab;
        plant.GetComponent<plantsInstance>().plantsData = plantsDataList[0]; // Assigner les données de la plante
        return plant;
    }
    
    public void CreatePlant(Vector2 position)
    {
        GameObject newPlant = Instantiate(updateData(), position, Quaternion.identity);
        Debug.Log("Created plant: " + newPlant.name);
    }
}
