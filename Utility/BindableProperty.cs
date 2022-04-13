using System;
using UnityEngine;

namespace Masot.Standard.Utility
{
    //dosesnt work with editor but oh well,
    //just make it work with like ui elements and stuff
    [Serializable]
    public class BindableProperty<_T>
    {
        [HideInInspector]
        public Action<BindableProperty<_T>> OnChange { get; set; }
        [HideInInspector]
        public Func<BindableProperty<_T>, _T, bool> CanChange { get; set; }

        public BindableProperty(_T value, Action<BindableProperty<_T>> onChange = null, Func<BindableProperty<_T>, _T, bool> canChange = null)
        {
            _value = value;
            OnChange += onChange;
            CanChange += canChange;
        }

        public static implicit operator _T(BindableProperty<_T> property) => property.Value;

        [SerializeField]
        private _T _value;
        public _T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                {
                    return;
                }

                if (CanChange != null && !CanChange.Invoke(this, value))
                {
                    return;
                }

                _value = value;
                OnChange?.Invoke(this);
            }
        }
    }
}
