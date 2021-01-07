using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public static class MessageHelper
    {
        public static string MessageTypeInfo = "info";
        public static string MessageTypeWarning = "warning";
        public static string MessageTypeSuccess = "success";
        public static string MessageTypeDanger = "danger";

        public static string Save = "Saved Successfully.";
        public static string Update = "Updated Successfully.";
        public static string Delete = "Deleted Successfully.";
        public static string Add = "Added Successfully.";
        public static string Edit = "Edited Successfully.";
        public static string Remove = "Removed Successfully.";

        public static string SaveFail = "Couldn't Saved Successfully.";
        public static string UpdateFail = "Couldn't Updated Successfully.";
        public static string DeleteFail = "Couldn't Deleted Successfully.";
        public static string AddFail = "Couldn't Added Successfully.";
        public static string EditFail = "Couldn't Edited Successfully.";
        public static string RemoveFail = "Couldn't Removed Successfully.";

        public static string Success = "Successfully.";
        public static string Info = "Please contact your system admin.";
        public static string Warning = "Please contact your system admin.";
        public static string Error = "We are facing some problem while processing the current request. Please try again later.";
        public static string UnhandelledError = "We are facing some problem while processing the current request. Please try again later.";
        public static string UnAuthenticated = "You are not authenticated user.";
        public static string NullError = "Requested object could not found.";
        public static string NullReferenceExceptionError = "There are one or more required fields that are missing.";
        public static string DataNotFound = "Data not found.";

        public static string IsEmailNotExists = "Email '{0}' is not taken.";
        public static string IsEmailExists = "Email '{0}' already taken. Please choose another email.";
        public static string EmailRequired = "Email is required.";

        public static string IsPhoneNoExists = "Phone no '{0}' already taken. Please choose another phone no.";
        public static string IsPhoneNoNotExists = "Phone no '{0}' is not taken.";
        public static string PhoneNoRequired = "Phone no is required.";

        public static string AtleastOne = "At least one {0} is required. Please select one.";

        public static string DataNotFoundMore = "Data not found. Please select one.";
        public static string InternalServerError = "Internal Server error.";

        public static string SentMessage = "Message Sent Successfully.";
        public static string SentMessageFail = "Couldn't Message Sent Successfully.";

    }
}
