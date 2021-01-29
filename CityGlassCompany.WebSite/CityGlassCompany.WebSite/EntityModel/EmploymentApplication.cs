using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGlassCompany.WebSite.EntityModel
{

    public class EmploymentApplication
    {
 
        public string Id { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        public string PhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string ReferredBy { get; set; }
        
        public string PresentAddress { get; set; }
        public string LastAddress { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Country { get; set; }
        
        public string ZipCode { get; set; }
        public string LastCity { get; set; }
        public string LastState { get; set; }
        public string LastCountry { get; set; }
        public string LastZipCode { get; set; }
        
        public string LegalInUSA { get; set; }
        
        public string CurrentlyEmployed { get; set; }
        
        public string CanContactYouEmployer { get; set; }
        public string CurrentlyEmploymentPosition { get; set; }
        public string SalaryDesired { get; set; }
        public string StartDate { get; set; }
        
        public string ApplyBefore { get; set; }
        
        public string WorkBefore { get; set; }
        public string JoinDate { get; set; }
        public string LastSupervisorName { get; set; }
        public string ReasonForLeave { get; set; }
        public string HighSchoolName { get; set; }
        public string CollegeName { get; set; }
        public string TradeBusinessSchoolName { get; set; }
        public string SpecialStudyResearchWork { get; set; }
        public string SpecialTrainingCertificationsLicenses { get; set; }
        public string SpecialSkillsLanguages { get; set; }

        
        public string MilitaryServiceRecord { get; set; }

        #region Former Employers

        public string LastEmployerNameOne { get; set; }
        public string LastEmployerJobTitleOne { get; set; }
        public string LastEmployerEmailAddressOne { get; set; }
        public string LastEmployerAddressOne { get; set; }
        public string LastEmployerCityOne { get; set; }
        public string LastEmployerStateOne { get; set; }
        public string LastEmployerZipCodeOne { get; set; }
        public string LastEmployerStartDateOne { get; set; }
        public string LastEmployerLeaveDateOne { get; set; }
        public string LastEmployerWeeklyStartSalaryOne { get; set; }
        public string LastEmployerWeeklyFinalSalaryOne { get; set; }

        public string LastEmployerNameTwo { get; set; }
        public string LastEmployerJobTitleTwo { get; set; }
        public string LastEmployerEmailAddressTwo { get; set; }
        public string LastEmployerAddressTwo { get; set; }
        public string LastEmployerCityTwo { get; set; }
        public string LastEmployerStateTwo { get; set; }
        public string LastEmployerZipCodeTwo { get; set; }
        public string LastEmployerStartDateTwo { get; set; }
        public string LastEmployerLeaveDateTwo { get; set; }
        public string LastEmployerWeeklyStartSalaryTwo { get; set; }
        public string LastEmployerWeeklyFinalSalaryTwo { get; set; }

        public string LastEmployerNameThree { get; set; }
        public string LastEmployerJobTitleThree { get; set; }
        public string LastEmployerEmailAddressThree { get; set; }
        public string LastEmployerAddressThree { get; set; }
        public string LastEmployerCityThree { get; set; }
        public string LastEmployerStateThree { get; set; }
        public string LastEmployerZipCodeThree { get; set; }
        public string LastEmployerStartDateThree { get; set; }
        public string LastEmployerLeaveDateThree { get; set; }
        public string LastEmployerWeeklyStartSalaryThree { get; set; }
        public string LastEmployerWeeklyFinalSalaryThree { get; set; }

        #endregion

        
        public string KnowAboutThisPosition { get; set; }

        public bool? IsArchived { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
