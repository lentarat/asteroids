using UnityEngine;


namespace Asteroids.Menu.Windows
{
    public class WindowsInitializer : MonoBehaviour
    {
        [SerializeField] private BaseWindow[] _windows;

        private void Awake()
        {
            foreach (BaseWindow window in _windows)
            {
                window.Initialize();
            }
        }
    }
}
