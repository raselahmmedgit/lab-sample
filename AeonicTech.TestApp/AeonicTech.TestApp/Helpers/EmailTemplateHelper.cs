using AeonicTech.TestApp.Models;

namespace AeonicTech.TestApp.Helpers
{
    public static class EmailTemplateHelper
    {
        public static string GetEmailTemplate(string title, string link, string linkText)
        {
            string html = string.Empty;

            html += "<div style='vertical-align: top; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto;' valign='top'>";
            html += "<div width='100%' cellpadding='0' cellspacing='0' style='font-family: Montserrat; box-sizing: border-box; font-size: 14px; border-radius: 3px; background-color: #fff; margin: 0; border: 1px solid #e9e9e9;' bgcolor='#fff'>";
            html += "<table align='center' width='100%' cellpadding='0' cellspacing='0' style='box-sizing: border-box; font-family: Montserrat; margin: 0 auto; padding: 0; width: 570px;' bgcolor='#FFFFFF'>";
            html += "<tbody>";
            html += "<tr>";
            html += "<td style='box-sizing: border-box; font-family: Montserrat; padding: 35px; word-break: break-word;'>";
            html += "<p style='box-sizing: border-box; color: #74787E; font-family: Montserrat; font-size: 16px; line-height: 1.5em; margin-top: 0;margin-bottom:10px' align='left'>";
            html += $"{title}";
            html += "</p>";
            html += "<table width='100%' border='0' cellspacing='0' cellpadding='0' style='box-sizing: border-box; margin-top:10px; font-family: Montserrat;'>";
            html += "<tbody>";
            html += "<tr>";
            html += $"<td align='center' style='box-sizing: border-box; font-family: Montserrat; word-break: break-word;'><table border='0' cellspacing='0' cellpadding='0' style='box-sizing: border-box; font-family: Montserrat;'><tbody><tr><td style='box-sizing: border-box; font-family: Montserrat; word-break: break-word; padding-bottom: 20px;'><a href='{link}' target='_blank' style='-webkit-text-size-adjust: none; background: #D6E700; border-color: #D6E700; border-radius: 3px; border-style: solid; border-width: 10px 30px; box-shadow: 0 2px 3px rgba(0, 0, 0, 0.16); box-sizing: border-box; color: #FFF; display: inline-block; font-family: Montserrat; text-decoration: none;font-size:15px'>{linkText}</a></td></tr></tbody></table></td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table><table style='border-top-color: #EDEFF2; border-top-style: solid; border-top-width: 1px; box-sizing: border-box; font-family: Montserrat; margin-top: 25px; padding-top: 25px;'><tbody><tr><td style='box-sizing: border-box; font-family: Montserrat; word-break: break-word;'><p style='box-sizing: border-box; color: #74787E; font-family: Montserrat; font-size: 12px; line-height: 1.5em; margin-top: 0;' align='left'> Do not reply to this email address. Emails sent to this address will not receive a response.</p></td></tr></tbody></table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</div>";
            html += "</div>";

            return html;
        }

        public static string GetContactSendMessageEmailTemplate(string title = "City Glass - Contact Us!", ContactSendMessage contactSendMessage = null)
        {
            string html = string.Empty;

            if (contactSendMessage != null)
            {
                html += "<style>@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600&display=swap')</style>";
                html += "<div style='vertical-align: top; display: block !important; clear: both !important; margin: 0 auto;' valign='top'>";
                html += "<div width='100%' cellpadding='0' cellspacing='0' style='font-family: Montserrat; box-sizing: border-box; font-size: 15px; border-radius: 3px; background-color: #fff; margin: 0; border: 1px solid #e9e9e9;' bgcolor='#fff'>";
                html += "<table align='center' width='100%' cellpadding='0' cellspacing='0' style='box-sizing: border-box; font-family: Montserrat; margin: 0 auto; padding: 0;' bgcolor='#FFFFFF'>";
                html += "<tbody>";
                html += "<tr>";
                html += "<td style='box-sizing: border-box; font-family: Montserrat; padding: 35px; word-break: break-word;'>";

                html += "<table width='100%' border='0' cellspacing='0' cellpadding='0' style='box-sizing: border-box; font-family: Montserrat;'>";
                html += "<tbody>";

                //start

                html += "<tr style='box-sizing: border-box; font-family: Montserrat; word-break: break-word; padding-bottom: 20px; display: inline-block;'>";

                html += "<td width='100%' style='box-sizing: border-box;'>";
                html += "<div style='padding: 0px 10px;'>";
                html += "<h4 style='line-height: 30px; font-size: 20px;'>";
                html += $"Message Category : {contactSendMessage.MessageCategory}";
                html += "</h4>";
                html += "<h5 style='line-height: 28px; font-size: 18px; margin-bottom: 5px;'>";
                html += $"Email : {contactSendMessage.ContactEmail}";
                html += "</h5>";
                html += "<h5 style='line-height: 18px; font-size: 16px; font-weight: 400; margin-bottom: 5px;'>";
                html += $"Name : {contactSendMessage.ContactName}";
                html += "</h5>";
                html += "<h5 style='line-height: 18px; font-size: 16px; font-weight: 400; margin-bottom: 5px;'>";
                html += $"Phone : {contactSendMessage.ContactPhone}";
                html += "</h5>";
                html += "<h5 style='line-height: 18px; font-size: 16px; font-weight: 400; margin-bottom: 5px;'>";
                html += $"Subject : {contactSendMessage.ContactSubject}";
                html += "</h5>";
                html += "<h5 style='line-height: 18px; font-size: 16px; font-weight: 400; margin-bottom: 5px;'>";
                html += $"Message : {contactSendMessage.ContactMessage}";
                html += "</h5>";
                html += "</div>";
                html += "</td>";

                html += "</tr>";

                //end


                html += "</tbody>";
                html += "</table><table style='border-top-color: #EDEFF2; border-top-style: solid; border-top-width: 1px; box-sizing: border-box; font-family: Montserrat; margin-top: 25px; padding-top: 25px;'><tbody><tr><td style='box-sizing: border-box; font-family: Montserrat; word-break: break-word;'><p style='box-sizing: border-box; color: #74787E; font-family: Montserrat; font-size: 12px; line-height: 1.5em; margin-top: 0;' align='left'> Do not reply to this email address. Emails sent to this address will not receive a response.</p></td></tr></tbody></table>";
                html += "</td>";
                html += "</tr>";
                html += "</tbody>";
                html += "</table>";
                html += "</div>";
                html += "</div>";
            }

            return html;
        }
    }
}
