using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthAttache.Data.Infrastructure
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DataAnnotations.DisplayAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }

        public static string GetDisplayName(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                //var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), false);
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DataAnnotations.DisplayAttribute)_Attribs.ElementAt(0)).Name;
                }
            }
            return GenericEnum.ToString();
        }

        public static string GetPrompt(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                //var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), false);
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DataAnnotations.DisplayAttribute)_Attribs.ElementAt(0)).Prompt;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
