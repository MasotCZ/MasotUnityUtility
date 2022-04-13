using UnityEngine;

namespace Masot.Standard.Utility
{
    public abstract class ControllerScriptableObjectBase<_T> : ScriptableObject where _T : ScriptableObject
    {
        private static _T _instance;
        public static _T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = ScriptableObject.CreateInstance<_T>();
                    (_instance as ControllerScriptableObjectBase<_T>).Init();
                }

                return _instance;
            }
        }

        protected virtual void Init()
        {
        }
    }
}