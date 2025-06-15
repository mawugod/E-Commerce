using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail; // For email sending functionality


namespace Secomez.Pages
{
    public class ContactUsModel : PageModel
    {
        [BindProperty]
        public ContactFormModel ContactModel { get; set; }

        public void OnGet()
        {
            // Code to execute when the page is requested
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the form is not valid, redisplay the page with validation errors
                return Page();
            }

            // Code to handle form submission
            try
            {
                // Access form values through ContactModel
                // Example: string name = ContactModel.Name;

                // Perform your logic here, e.g., sending an email, saving to a database, etc.
                SendEmail(ContactModel);

                // Redirect to a confirmation page or reload the current page
                return RedirectToPage("ContactUsConfirmation");
            }
            catch (Exception ex)
            {
                // Log the error and handle it appropriately
                // You might want to redirect to an error page or display a friendly message
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
                return Page();
            }
        }

        private void SendEmail(ContactFormModel model)
        {
            // Use a secure method to send emails, such as SMTP with authentication
            using (SmtpClient smtpClient = new SmtpClient("your-smtp-server.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("your-email@example.com", "your-email-password");
                smtpClient.EnableSsl = true;

                // Create the email message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@example.com"),
                    Subject = "New Contact Form Submission",
                    Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}",
                    IsBodyHtml = false
                };

                // Add recipient email addresses
                mailMessage.To.Add("your-support-email@example.com");
                mailMessage.CC.Add("your-sales-email@example.com");

                // Send the email
                smtpClient.Send(mailMessage);
            }
        }
    }

    public class ContactFormModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        public string Message { get; set; }
    }
}
