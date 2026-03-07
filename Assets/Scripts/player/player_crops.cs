using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class player_crops : MonoBehaviour
{
    public AllPlants selectedPlant;
    public Tile testTile;
    public bool isPlanting = false;
    public PlantsManager plantsManager;
    


    void Start()
    {
        
        
        
    }

    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            isPlanting = !isPlanting; 
        }
        if (isPlanting && Keyboard.current.rKey.wasPressedThisFrame)
        {
            selectedPlant = AllPlants.patate;
            Debug.Log("Planting " + selectedPlant);
            GrownPlants(selectedPlant);
        }
    }
    
    void GrownPlants(AllPlants plants)
    {
        if (plants == AllPlants.patate)
        {
            if (plantsManager == null || Camera.main == null || Mouse.current == null) return;

            // Convertir position écran → monde
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(
                mouseScreenPos.x,
                mouseScreenPos.y,
                Mathf.Abs(Camera.main.transform.position.z)
            ));

            // Trouver la cellule de la tilemap sous le curseur
            Grid grid = FindAnyObjectByType<Grid>();
            if (grid == null)
            {
                Debug.LogWarning("Aucune Grid trouvée dans la scène !");
                return;
            }

            Vector3Int cellPos = grid.WorldToCell(mouseWorldPos);
            // Convertir la cellule en position monde centrée
            Vector3 cellCenterWorld = grid.GetCellCenterWorld(cellPos);

            Debug.Log($"Curseur: {mouseScreenPos} → Monde: {mouseWorldPos} → Cellule: {cellPos} → Centre: {cellCenterWorld}");
            plantsManager.CreatePlant(new Vector2(cellCenterWorld.x, cellCenterWorld.y));
        }
    }

}