using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public Arrow PrefabUp;
    public Arrow PrefabDown;
    public Arrow PrefabLeft;
    public Arrow PrefabRight;
    public Arrow PrefabSpecial;

    [HideInInspector]
    public List<Arrow> ListSpawnedArrows;

    private GateSpawner gateSpawner;


    void Start()
    {
        ListSpawnedArrows = new List<Arrow>();
        gateSpawner = FindObjectOfType<GateSpawner>();
    }

    public void Spawn(Direction direction)
    {
        Arrow type = GetArrowType(direction);
        Arrow arrow = Instantiate(type, transform);
        arrow.transform.parent = gateSpawner.LastGateTransform;

        ListSpawnedArrows.Add(arrow);
    }

    private Arrow GetArrowType(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                return PrefabUp;
            case Direction.down:
                return PrefabDown;
            case Direction.left:
                return PrefabLeft;
            case Direction.right:
                return PrefabRight;
            case Direction.special:
                return PrefabSpecial;
        }
        Debug.LogWarning("Returned default arrow type!");
        return PrefabUp;
    }
}
