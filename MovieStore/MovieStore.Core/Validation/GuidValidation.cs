﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Core.Validation
{
    public class GuidValidationAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "'{0}' does not contain a valid guid";

        public GuidValidationAttribute()
            : base(DefaultErrorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value == null || new Guid(value.ToString()) == Guid.Empty)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            catch (Exception)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }


            return null;
        }
    }
}
