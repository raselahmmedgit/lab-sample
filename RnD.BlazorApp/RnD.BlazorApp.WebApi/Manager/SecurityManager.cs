using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using RnD.BlazorApp.WebApi.Models;
using log4net;
using RnD.BlazorApp.WebApi.Core;

namespace RnD.BlazorApp.WebApi.Manager
{
    public class SecurityManager : ISecurityManager
    {
        private readonly IConfiguration _configuration;
        private static readonly ILog _log = LogManager.GetLogger(typeof(SecurityManager));
        public SecurityManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJsonWebToken(UserModel model)
        {
            try
            {
                _log.Info(Log4NetMessageHelper.FormateMessageForStart("GenerateJsonWebToken"));

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["AppJwt:Issuer"],
                    _configuration["AppJwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                _log.Info(Log4NetMessageHelper.FormateMessageForEnd("GenerateJsonWebToken"));

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                _log.Error("Error: GenerateJSONWebToken. " + ex.StackTrace);
            }
            return null;
        }
        public UserModel AuthenticateUser(UserModel model)
        {
            try
            {
                _log.Info(Log4NetMessageHelper.FormateMessageForStart("AuthenticateUser"));

                UserModel user = null;
                var emailAddress = _configuration["AppContactUsConfig:EmailAddress"].ToString();
                var emailAddressDisplayName = _configuration["AppContactUsConfig:EmailAddressDisplayName"].ToString();

                var userName = _configuration["SchedulerManager:Username"].ToString();
                var password = _configuration["SchedulerManager:Password"].ToString();
                
                //Validate the User Credentials      
                if (model.Username == userName && model.Password == password)
                {
                    user = new UserModel { Username = emailAddressDisplayName, EmailAddress = emailAddress };
                    _log.Info("Valid User.");
                }
                else
                {
                    _log.Info("Invalid User.");
                }

                _log.Info(Log4NetMessageHelper.FormateMessageForEnd("AuthenticateUser"));

                return user;
            }
            catch (Exception ex)
            {
                _log.Error("Error: AuthenticateUser. " + ex.StackTrace);
            }
            return null;
        }
    }
}
