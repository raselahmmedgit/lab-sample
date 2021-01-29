using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityGlassCompany.WebSite.ViewModels
{
    public class EmploymentApplicationViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
     
        public string DisplayName => (FirstName + " " + LastName)?.Trim();

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string ReferredBy { get; set; }
        [Required]
        public string PresentAddress { get; set; }
        public string LastAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string LastCity { get; set; }
        public string LastState { get; set; }
        public string LastCountry { get; set; }
        public string LastZipCode { get; set; }
        [Required]
        public string LegalInUSA { get; set; }
        [Required]
        public string CurrentlyEmployed { get; set; }
        [Required]
        public string CanContactYouEmployer { get; set; }
        public string CurrentlyEmploymentPosition { get; set; }
        public string SalaryDesired { get; set; }
        public string StartDate { get; set; }
        [Required]
        public string ApplyBefore { get; set; }
        [Required]
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

        [Required]
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

        [Required]
        public string KnowAboutThisPosition { get; set; }

        public bool? IsArchived { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
