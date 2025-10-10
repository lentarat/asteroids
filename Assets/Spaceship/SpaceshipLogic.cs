using UnityEngine;

namespace Asteroids.Spaceship
{
    public class SpaceshipLogic
    {
        private readonly SpaceshipData _spaceshipData;

        public SpaceshipLogic(SpaceshipData spaceshipData)
        {
            _spaceshipData = spaceshipData;
        }

        public void Move()
        {
            _spaceshipData.Position += Vector2.one;
        }
    }
}
