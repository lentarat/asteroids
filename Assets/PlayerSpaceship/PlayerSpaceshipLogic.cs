using UnityEngine;

public class PlayerSpaceshipLogic
{
    private readonly PlayerSpaceshipData _playerSpaceshipData;
    
    public PlayerSpaceshipLogic(PlayerSpaceshipData playerSpaceshipData)
    {
        _playerSpaceshipData = playerSpaceshipData;
    }

    public void Move() 
    {
        _playerSpaceshipData.Position += Vector2.one;
    }
}
