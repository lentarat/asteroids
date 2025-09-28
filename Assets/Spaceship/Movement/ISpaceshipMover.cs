using System;
using UnityEngine;

public interface ISpaceshipMover
{
    event Action<float> OnMove;
    event Action<float> OnRotate;
}
