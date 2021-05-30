
using UnityEngine;

public interface ICollectable
{
    void Spawn(Vector3 position);

    Item PickUp();
}
