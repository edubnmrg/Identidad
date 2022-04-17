using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Services
{
    public class EnviarCorreo
    {
        public string Destinatario { get; set; }
        public string Email { get; set; }
        public string Tema { get; set; }
        public string Mensaje { get; set; }

        public EnviarCorreo(string Dest, string Emai, string Tem, string Mens) 
        {
            Destinatario = Dest;
            Email = Emai;
            Tema = Tem;
            Mensaje =Mens;
        }

        public void Enviar() {
            try
            {
                //instantiate a new MimeMessage
                var message = new MimeMessage();
                //Setting the To e-mail address
                message.To.Add(new MailboxAddress(this.Destinatario, this.Email));
                //Setting the From e-mail address
                message.From.Add(new MailboxAddress("5 Quillas", "5QuillasJCRC@gmail.com"));
                //E-mail subject 
                message.Subject = this.Tema;
                //E-mail message body
                message.Body = new TextPart(TextFormat.Html)
                {
                    //Text = $"Confirme su cuenta en 5 Quillas cliqueando este link: <a href='{confirmationLink}'>link</a>"
                    Text = this.Mensaje
                };

                //Configure the e-mail
                using (var emailClient = new SmtpClient())
                {
                    emailClient.Connect("smtp.gmail.com", 587, false);
                    //emailClient.Authenticate("5QuillasJCRC@gmail.com", "Gma5ben$");
                    emailClient.Authenticate("eduardoben@gmail.com", "Gma5ben$");
                    //emailClient.Connect("smtp.postmarkapp.com", 587, false);
                    //emailClient.Authenticate("CasinJCRC@outlook.com,ar", "Out5ben$");
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
               //ModelState.Clear();
               //ViewBag.Message = $" Oops! We have a problem here {ex.Message}";
                //return View("Error");
            }
        }
    }

   
}
