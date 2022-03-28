using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    public class ModuleComponentList : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> moduleComponents = new List<MonoBehaviour>();
        [ContextMenu("Fill Module Accessors (This component should be at the root GameObject)")]
        private void GetModuleAccessors()
        {
            moduleComponents.Clear();
            IModuleComponent[] accessors = transform.GetComponentsInChildren<IModuleComponent>();
            foreach(IModuleComponent accessor in accessors)
            {
                moduleComponents.Add((MonoBehaviour)accessor);
            }
        }
        public List<MonoBehaviour> ModuleComponents { get => moduleComponents; set => moduleComponents = value; }
    }
}