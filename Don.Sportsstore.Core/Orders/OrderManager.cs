using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Abp.Threading;
using Don.Sportsstore.Cart;
using Don.Sportsstore.Carts;

namespace Don.Sportsstore.Orders
{
    public class OrderManager : IOrderManager
    {
        private readonly EmailSettings _emailsSettings;

        public OrderManager() //todo DI here
        {
            var writeAsFile = ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false";
            var emailSettings = new EmailSettings();
            emailSettings.WriteAsFile = true;
            _emailsSettings = emailSettings;
        }


        public async Task ProcessOrder(Carts.Cart cart, ShippingDetails shippingDetails)
        {
            // return await Task.Run(ProcessOrderMock(cart, shippingDetails));
            await Work(cart, shippingDetails);
            //return new Task();
        }

        private Task Work(Carts.Cart cart, ShippingDetails shippingDetails)
        {
            //http://www.hexacta.com/2016/06/01/task-run-vs-async-await/
            return Task.Run(() =>
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = _emailsSettings.UseSsl;
                    smtpClient.Host = _emailsSettings.ServerName;
                    smtpClient.Port = _emailsSettings.ServerPort;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials
                        = new NetworkCredential(_emailsSettings.Username,
                            _emailsSettings.Password);
                    if (_emailsSettings.WriteAsFile)
                    {
                        smtpClient.DeliveryMethod
                            = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        smtpClient.PickupDirectoryLocation = _emailsSettings.FileLocation;
                        smtpClient.EnableSsl = false;
                    }

                    StringBuilder body = new StringBuilder()
                        .AppendLine("A new order has been submitted")
                        .AppendLine("---")
                        .AppendLine("Items:");

                    foreach (var line in cart.Lines)
                    {
                        var subtotal = line.Product.Price * line.Quantity;
                        body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity,
                            line.Product.Name,
                            subtotal);
                    }

                    body.AppendFormat("Total order value: {0:c}", cart.CalcTotalValue())
                        .AppendLine("---")
                        .AppendLine("Ship to:")
                        .AppendLine(shippingDetails.Name)
                        .AppendLine(shippingDetails.Line1)
                        .AppendLine(shippingDetails.Line2 ?? "")
                        .AppendLine(shippingDetails.Line3 ?? "")
                        .AppendLine(shippingDetails.City)
                        .AppendLine(shippingDetails.State ?? "")
                        .AppendLine(shippingDetails.Country)
                        .AppendLine(shippingDetails.Zip)
                        .AppendLine("---")
                        .AppendFormat("Gift wrap: {0}",
                            shippingDetails.GiftWrap ? "Yes" : "No");


                    MailMessage mailMessage = new MailMessage(
                        _emailsSettings.MailFromAddress, // From
                        _emailsSettings.MailToAddress, // To
                        "New order submitted!", // Subject
                        body.ToString()); // Body

                    if (_emailsSettings.WriteAsFile)
                    {
                        mailMessage.BodyEncoding = Encoding.ASCII;
                    }

                    smtpClient.Send(mailMessage);
                }
            });
        }
    }
}