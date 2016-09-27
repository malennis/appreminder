﻿
    //class DateGreaterThanAttribute : Attribute
    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AppointmentReminders.Web.Domain;
 
namespace AppointmentReminders.Web.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=true)]
    public class DateGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        string otherPropertyName;
 
        public DateGreaterThanAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }
 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                // Using reflection we can get a reference to the other date property, in this example the project start date
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                // Let's check that otherProperty is of type DateTime as we expect it to be
                //if (otherPropertyInfo.PropertyType.Equals(new DateTime().GetType()))
                if (otherPropertyInfo.PropertyType.Equals(string.Empty.GetType()))
                {
     
                    DateTime toValidate = (DateTime)value;
                    string timeZone = (string)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    TimeConverter a = new TimeConverter();
                    DateTime appdateTime = a.ToLocalTime(toValidate, timeZone);

                    
                    DateTime utcTime = DateTime.UtcNow;// gives you current Time in server timeZone // convert it to Utc using timezone setting of server computer

                    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                    DateTime localTimeNow = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tz);

                  
                    // if the end date is lower than the start date, than the validationResult will be set to false and return
                    // a properly formatted error message
                    if (appdateTime.CompareTo(localTimeNow) < 1)
                    {
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property. Time Zone  is not of type string");
                }
            }
            catch (Exception ex)
            {
                // Do stuff, i.e. log the exception
                // Let it go through the upper levels, something bad happened
                throw ex;
            }
 
            return validationResult;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            string errorMessage = ErrorMessageString;

            // The value we set here are needed by the jQuery adapter
            ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
            dateGreaterThanRule.ErrorMessage = errorMessage;
            dateGreaterThanRule.ValidationType = "dategreaterthan"; // This is the name the jQuery adapter will use

            
            //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
            dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);

            yield return dateGreaterThanRule;
        }
    }
}

