
using UnityEngine;

public interface ICollectable
{
    Item item { get; }
    void Spawn(Vector3 position);

    void PickUp(Item item);
}
