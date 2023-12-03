namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportClientDTO[]), new XmlRootAttribute("Clients"));

            using var reader = new StringReader(xmlString);
            ImportClientDTO[] importClientDTOs = (ImportClientDTO[])xmlSerializer.Deserialize(reader);

            var mapper = Configuration.GetMapper();
            List<Client> clients = new List<Client>();
            for (int i = 0; i < importClientDTOs.Length; i++)
            {
                Client client = mapper.Map<Client>(importClientDTOs[i]);
                if (IsValid(client))
                {
                    clients.Add(client);
                    Console.WriteLine(SuccessfullyImportedClients, client.Name);
                }
                else 
                {
                    Console.WriteLine(ErrorMessage);
                }
            }
            context.AddRange(clients);
            context.SaveChanges();

            return $"Successfully imported {clients.Count}";
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
