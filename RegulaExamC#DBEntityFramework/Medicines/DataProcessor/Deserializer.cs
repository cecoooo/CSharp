using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Medicines.Data;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;

namespace Medicines.DataProcessor
{
    public static class Deserializer
    {
        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var xml = XDocument.Parse(xmlString);
            var sb = new StringBuilder();

            var pharmacies = xml.Root.Elements("Pharmacy");

            foreach (var pharmacyElement in pharmacies)
            {
                try
                {
                    var isNonStopAttribute = pharmacyElement.Attribute("non-stop")?.Value;
                    var isNonStop = bool.Parse(isNonStopAttribute);

                    var pharmacy = new Pharmacy
                    {
                        Name = pharmacyElement.Element("Name")?.Value,
                        PhoneNumber = pharmacyElement.Element("PhoneNumber")?.Value,
                        IsNonStop = isNonStop,
                        Medicines = pharmacyElement
                            .Elements("Medicines")
                            .Elements("Medicine")
                            .Select(medicineElement => new Medicine
                            {
                                Name = medicineElement.Element("Name")?.Value,
                                Price = decimal.Parse(medicineElement.Element("Price")?.Value, CultureInfo.InvariantCulture),
                                Category = (Category)Enum.Parse(typeof(Category), medicineElement.Attribute("category")?.Value),
                                ProductionDate = DateTime.ParseExact(medicineElement.Element("ProductionDate")?.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                                ExpiryDate = DateTime.ParseExact(medicineElement.Element("ExpiryDate")?.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                                Producer = medicineElement.Element("Producer")?.Value
                            })
                            .ToList()
                    };

                    if (IsValid(pharmacy))
                    {
                        if (!context.Pharmacies.Any(p => p.Name == pharmacy.Name))
                        {
                            context.Pharmacies.Add(pharmacy);
                            context.SaveChanges();
                            sb.AppendLine($"Successfully imported pharmacy - {pharmacy.Name} with {pharmacy.Medicines.Count} medicines.");
                        }
                        else
                        {
                            sb.AppendLine("Invalid Data!");
                        }
                    }
                    else
                    {
                        sb.AppendLine("Invalid Data!");
                    }
                }
                catch
                {
                    sb.AppendLine("Invalid Data!");
                }
            }

            return sb.ToString().Trim();
        }

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var patients = JsonConvert.DeserializeObject<Patient[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var patient in patients)
            {
                try
                {
                    if (IsValid(patient))
                    {
                        var medicinesIds = patient.PatientsMedicines.Select(pm => pm.MedicineId).ToList();

                        var patientEntity = new Patient
                        {
                            FullName = patient.FullName,
                            AgeGroup = patient.AgeGroup,
                            Gender = patient.Gender,
                            PatientsMedicines = patient.PatientsMedicines
                        };

                        if (!context.Patients.Any(p => p.FullName == patientEntity.FullName))
                        {
                            context.Patients.Add(patientEntity);
                            context.SaveChanges();
                            sb.AppendLine($"Successfully imported patient - {patientEntity.FullName} with {patientEntity.PatientsMedicines.Count} medicines.");
                        }
                        else
                        {
                            sb.AppendLine("Invalid Data!");
                        }
                    }
                    else
                    {
                        sb.AppendLine("Invalid Data!");
                    }
                }
                catch
                {
                    sb.AppendLine("Invalid Data!");
                }
            }

            return sb.ToString().Trim();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(entity, validationContext, validationResults, true);
        }
    }
}
