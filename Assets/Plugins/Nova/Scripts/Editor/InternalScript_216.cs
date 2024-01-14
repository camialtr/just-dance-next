// Copyright (c) Supernova Technologies LLC
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal class InternalType_581 : AdvancedDropdown
    {
        private struct InternalType_777
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public string InternalField_3716;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public Type InternalField_3717;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_3714 = "Select Type";

        public event System.Action<Type> InternalEvent_6;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<string, int> InternalField_3312 = new Dictionary<string, int>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<InternalType_777> InternalField_3313 = new List<InternalType_777>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string InternalField_3715 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector2 InternalProperty_1168 { get => minimumSize; set => minimumSize = value; }

        public InternalType_581(Type InternalParameter_2621, string InternalParameter_2620 = InternalField_3714) : base(new AdvancedDropdownState())
        {
            InternalField_3715 = InternalParameter_2620;

            TypeCache.TypeCollection InternalVar_1 = TypeCache.GetTypesDerivedFrom(InternalParameter_2621);

            for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.Count; ++InternalVar_2)
            {
                Type InternalVar_3 = InternalVar_1[InternalVar_2];

                if (InternalVar_3.IsAbstract)
                {
                    continue;
                }

                string InternalVar_4 = InternalMethod_3697(InternalVar_3);

                if (InternalField_3312.TryGetValue(InternalVar_4, out int InternalVar_5))
                {
                    InternalVar_5++;
                }
                else
                {
                    InternalVar_5 = 1;
                }

                InternalField_3312[InternalVar_4] = InternalVar_5;
                InternalField_3313.Add(new InternalType_777() { InternalField_3717 = InternalVar_3, InternalField_3716 = InternalVar_4 });
            }

            InternalField_3313.Sort(new InternalType_497());
        }

        private static string InternalMethod_3697(Type InternalParameter_3509)
        {
            TypeMenuPathAttribute InternalVar_1 = InternalParameter_3509.GetCustomAttribute<TypeMenuPathAttribute>();
            TypeMenuNameAttribute InternalVar_2 = InternalParameter_3509.GetCustomAttribute<TypeMenuNameAttribute>();

            string InternalVar_3 = InternalVar_2 != null && !string.IsNullOrWhiteSpace(InternalVar_2.DisplayName) ? InternalVar_2.DisplayName : ObjectNames.NicifyVariableName(InternalParameter_3509.Name);
            string InternalVar_4 = InternalVar_1 != null && !string.IsNullOrWhiteSpace(InternalVar_1.Path) ? InternalVar_1.Path : string.Empty;

            return string.IsNullOrWhiteSpace(InternalVar_4) ? InternalVar_3 : $"{InternalVar_4}/{InternalVar_3}";
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var InternalVar_1 = new AdvancedDropdownItem(InternalField_3715);

            int InternalVar_2 = 0;

            InternalVar_1.AddChild(new InternalType_496(null, "None (Unassigned)")
            {
                id = InternalVar_2++
            });

            for (int InternalVar_3 = 0; InternalVar_3 < InternalField_3313.Count; ++InternalVar_3)
            {
                InternalType_777 InternalVar_4 = InternalField_3313[InternalVar_3];

                Type InternalVar_5 = InternalVar_4.InternalField_3717;
                string InternalVar_6 = InternalVar_4.InternalField_3716;
                string[] InternalVar_7 = InternalVar_6.Split('\\', '/');
                string InternalVar_8 = InternalVar_7[InternalVar_7.Length - 1];

                if (InternalField_3312[InternalVar_6] > 1)
                {
                    string InternalVar_9 = InternalVar_5.Assembly.ToString().Split('(', ',')[0];
                    InternalVar_8 = $"{InternalVar_8} [{InternalVar_5.Namespace}, Assembly: {InternalVar_9}]";
                }

                var InternalVar_10 = new InternalType_496(InternalVar_5, InternalVar_8)
                {
                    id = InternalVar_2++,
                };

                InternalMethod_3698(InternalVar_1, InternalVar_7, 0).AddChild(InternalVar_10);
            }

            return InternalVar_1;
        }

        private static AdvancedDropdownItem InternalMethod_3698(AdvancedDropdownItem InternalParameter_3510, string[] InternalParameter_3511, int InternalParameter_3512)
        {
            if (InternalParameter_3511 == null || InternalParameter_3512 >= InternalParameter_3511.Length - 1)
            {
                return InternalParameter_3510;
            }

            AdvancedDropdownItem InternalVar_1 = InternalParameter_3510.children.Where(x => string.Compare(x.name, InternalParameter_3511[InternalParameter_3512], ignoreCase: true) == 0 && !(x is InternalType_496)).FirstOrDefault();

            if (InternalVar_1 == null)
            {
                InternalVar_1 = new AdvancedDropdownItem(InternalParameter_3511[InternalParameter_3512]);
                InternalParameter_3510.AddChild(InternalVar_1);
            }

            return InternalMethod_3698(InternalVar_1, InternalParameter_3511, InternalParameter_3512 + 1);
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            base.ItemSelected(item);

            if (!item.enabled)
            {
                return;
            }

            if (item is InternalType_496 typePopupItem)
            {
                InternalEvent_6?.Invoke(typePopupItem.InternalProperty_244);
            }
        }

        private struct InternalType_497 : IComparer<InternalType_777>
        {
            public int Compare(InternalType_777 x, InternalType_777 y)
            {
                return x.InternalField_3716.CompareTo(y.InternalField_3716);
            }
        }

        private class InternalType_496 : AdvancedDropdownItem
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public Type InternalProperty_244 { get; }

            public InternalType_496(Type InternalParameter_38, string InternalParameter_3093) : base(InternalParameter_3093)
            {
                InternalProperty_244 = InternalParameter_38;
            }
        }
    }
}

