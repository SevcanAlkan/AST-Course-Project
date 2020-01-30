﻿using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core
{
    public static class ModelCopier
    {
        public static void CopyCollection<T>(IEnumerable<T> from, ICollection<T> to)
        {
            if (from == null || to == null || to.IsReadOnly)
            {
                return;
            }

            to.Clear();
            foreach (T element in from)
            {
                to.Add(element);
            }
        }

        public static T ToDM<T>(object from) where T : BaseEntity, IBaseEntity, new()
        {
            T to = new T();

            if (from == null)
                return null;

            CopyModel(from, to);

            return to;
        }
        public static void CopyModel(object from, object to)
        {
            if (from == null || to == null)
            {
                return;
            }

            PropertyDescriptorCollection fromProperties = TypeDescriptor.GetProperties(from);
            PropertyDescriptorCollection toProperties = TypeDescriptor.GetProperties(to);

            foreach (PropertyDescriptor fromProperty in fromProperties)
            {
                bool dontCopy = fromProperty.Attributes.OfType<ModelCopierAttribute>().Where(a=> a.DontCopy).Any();
                if (dontCopy)
                {
                    continue;
                }

                PropertyDescriptor toProperty = toProperties.Find(fromProperty.Name, true /* ignoreCase */);
                if (toProperty != null && !toProperty.IsReadOnly)
                {
                    // Can from.Property reference just be assigned directly to to.Property reference?
                    bool isDirectlyAssignable = toProperty.PropertyType.IsAssignableFrom(fromProperty.PropertyType);
                    // Is from.Property just the nullable form of to.Property?
                    bool liftedValueType = (isDirectlyAssignable) ? false : (Nullable.GetUnderlyingType(fromProperty.PropertyType) == toProperty.PropertyType);

                    if (isDirectlyAssignable || liftedValueType)
                    {
                        object fromValue = fromProperty.GetValue(from);
                        if (isDirectlyAssignable || (fromValue != null && liftedValueType))
                        {
                            toProperty.SetValue(to, fromValue);
                        }
                    }
                }
            }
        }
    }
}
