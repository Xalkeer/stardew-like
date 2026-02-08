using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class player_crops : MonoBehaviour
{
    public Sprite grownCropSprite;
    public Tilemap targetTilemap;
    public Vector3Int explicitCellPosition;
    public bool useExplicitCell = true;
    public Vector2 localFootOffset = new Vector2(0f, -0.5f);

    private Tile runtimeTile;

    void Start()
    {
        if (targetTilemap == null) Debug.LogWarning("Assigner une Tilemap dans l'inspecteur.");
        if (grownCropSprite != null)
        {
            runtimeTile = ScriptableObject.CreateInstance<Tile>();
            runtimeTile.sprite = grownCropSprite;
        }
    }

    void Update()
    {
        GrowCrop();
    }

    public void GrowCrop()
    {
        if (Keyboard.current == null || !Keyboard.current.eKey.wasPressedThisFrame) return;
        if (targetTilemap == null || grownCropSprite == null) return;

        if (useExplicitCell)
        {
            targetTilemap.SetTile(explicitCellPosition, GetOrCreateTile());
        }
        else
        {
            Vector3 worldPos = transform.TransformPoint(localFootOffset);
            Vector3Int cell = targetTilemap.WorldToCell(worldPos);
            targetTilemap.SetTile(cell, GetOrCreateTile());
        }

        // Forcer le rafraîchissement visuel si besoin
        if (useExplicitCell)
            targetTilemap.RefreshTile(explicitCellPosition);
        else
            targetTilemap.RefreshTile(targetTilemap.WorldToCell(transform.TransformPoint(localFootOffset)));
    }

    private Tile GetOrCreateTile()
    {
        if (runtimeTile == null)
        {
            runtimeTile = ScriptableObject.CreateInstance<Tile>();
            runtimeTile.sprite = grownCropSprite;
        }
        return runtimeTile;
    }
}