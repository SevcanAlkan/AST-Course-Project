using MovieStore.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data.Helper
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(T enumObj)
        {
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return enumObj.ToString();
            }
            else
            {
                DescriptionAttribute attrib = null;

                foreach (var att in attribArray)
                {
                    if (att is DescriptionAttribute)
                        attrib = att as DescriptionAttribute;
                }

                if (attrib != null)
                    return attrib.Description;

                return enumObj.ToString();
            }
        }

        public static List<string> GetDescriptionList<T>(T[] enumArray)
        {
            List<string> values = new List<string>();

            foreach (var item in enumArray)
            {
                values.Add(GetDescription<T>(item));
            }

            return values;
        }

        public static List<string> GetDescriptionList<T>()
        {
            List<string> values = new List<string>();
            var enumValues = System.Enum.GetValues(typeof(T)).Cast<T>();

            if (enumValues != null && enumValues.Count() > 0)
            {
                foreach (var item in enumValues)
                {
                    values.Add(GetDescription<T>(item));
                }
            }

            return values;
        }

        public static List<SelectListVM> GetSelectList<T>()
        {
            List<SelectListVM> list = new List<SelectListVM>();

            Type genericType = typeof(T);
            if (genericType.IsEnum)
            {
                foreach (T obj in Enum.GetValues(genericType))
                {
                    Enum enumVal = Enum.Parse(typeof(T), obj.ToString()) as Enum;
                    int intValue = Convert.ToInt32(enumVal);
                    list.Add(new SelectListVM() { Value = intValue, Text = GetDescription<T>(obj) });
                }
            }

            return list;
        }

        public static SelectListVM GetSelectItem<T>(T obj)
        {
            SelectListVM item = new SelectListVM();

            Type genericType = typeof(T);
            if (genericType.IsEnum)
            {
                Enum enumVal = Enum.Parse(typeof(T), obj.ToString()) as Enum;
                int intValue = Convert.ToInt32(enumVal);

                item.Value = intValue;
                item.Text = GetDescription<T>(obj);
            }

            return item;
        }
    }
}
