using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RnD.MSTestApps
{
    [TestClass]
    public class PatientPortalTest
    {
        [TestInitialize]
        public void PatientLogIn()
        {
            try
            {
                Console.WriteLine("PatientPortal: Log in.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestCleanup]
        public void PatientLogOff()
        {
            try
            {
                Console.WriteLine("PatientPortal: Log off.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void PatientHomePage()
        {
            try
            {
                Console.WriteLine("PatientPortal: Home page.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
