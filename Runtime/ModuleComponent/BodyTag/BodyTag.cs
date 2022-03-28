using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    public class BodyTag : MonoBehaviour, IModuleComponent
    {
        [SerializeField] private ModuleComponentList moduleComponetList;
        protected virtual void Awake()
        {
            Reset();
        }

        private void Reset()
        {
            if (moduleComponetList == null)
            {
                moduleComponetList = GetComponent<ModuleComponentList>();
                if (moduleComponetList == null)
                {
                    moduleComponetList = transform.root.GetComponentInChildren<ModuleComponentList>();
                    if (moduleComponetList == null)
                    {
                        moduleComponetList = transform.root.gameObject.AddComponent<ModuleComponentList>();
                    }
                }
            }
        }
        public ModuleComponentList ModuleComponentList { get => moduleComponetList; set => moduleComponetList = value; }
        public List<MonoBehaviour> ModuleComponents { get => moduleComponetList.ModuleComponents; }
    }
}