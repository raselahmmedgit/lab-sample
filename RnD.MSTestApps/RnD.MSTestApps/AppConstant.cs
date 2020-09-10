using System;
using System.Collections.Generic;
using System.Text;

namespace RnD.MSTestApps
{
    public static class AppConstant
    {
        public const string BaseAddress = "https://ontrack-healthdemo.com/";
    }

    public static class RoleConstants
    {

        public static string SystemAdmin = "SystemAdmin";

        public static string PracticeAdmin = "PracticeAdmin";

        public static string Professional = "Professional";

        public static string Patient = "Patient";

        public static string Scheduler = "Scheduler";

        public static string OperatingRoomPersonnel = "OperatingRoomPersonnel";

        public static string OperatingRoomNurse = "OperatingRoomNurse";

        public static string OperatingRoomMD = "OperatingRoomMD";

    }

    public static class UserConstants
    {

        //Patient Login
        public static string Step2_PatientEmail = "rasel.placovu@gmail.com";
        public static string Step2_PatientPass = "Qwer!234";

        public static string Step3_PatientEmail = "rasel@placovu.com";
        public static string Step3_PatientPass = "Qwer!234";

        public static string Step4_PatientEmail = "zubayed@placovu.com";
        public static string Step4_PatientPass = "Qwer!234";


        //PhysicianAssistant Login
        public static string Step2_PhysicianAssistantEmail = "rasel.placovu@gmail.com";
        public static string Step2_PhysicianAssistantPass = "Qwer!234";

        public static string Step3_PhysicianAssistantEmail = "rasel@placovu.com";
        public static string Step3_PhysicianAssistantPass = "Qwer!234";

        public static string Step4_PhysicianAssistantEmail = "zubayed@placovu.com";
        public static string Step4_PhysicianAssistantPass = "Qwer!234";
    }
}
