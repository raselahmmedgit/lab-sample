﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.Helpers
{
    public static class EnumHelper
    {
        public static IDictionary<Enum, string> ToDictionary(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var dics = new Dictionary<Enum, string>();
            var enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                dics.Add(value, GetDisplayName(value));
            }

            return dics;
        }

        public static string GetDisplayName(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var displayName = value.ToString();
            var fieldInfo = value.GetType().GetField(displayName);
            var attributes = (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes.Length > 0)
            {
                displayName = attributes[0].Description;
            }

            return displayName;
        }
    }

    public static class Enums
    {
        public enum OrganizationTypeEnum
        {
            System = 1
        }

        public enum PictureTypeEnum
        {
            Logo = 1,
            ProfilePicture = 2
        }

        public enum DocumentTypeEnum
        {
            Logo = 1,
            ProfilePicture = 2
        }
    }
}
