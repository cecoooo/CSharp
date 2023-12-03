using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using Medicines.Data;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;

namespace Medicines.DataProcessor
{
    public static class Serializer
    {
        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2", CultureInfo.InvariantCulture),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .ToList();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }

        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, DateTime date)
        {
            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > date))
                .OrderByDescending(p => p.PatientsMedicines.Count)
                .ThenBy(p => p.FullName)
                .Select(p => new
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                        .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                        .ThenBy(pm => pm.Medicine.Price)
                        .Select(pm => new
                        {
                            MedicineName = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("F2", CultureInfo.InvariantCulture),
                            Category = pm.Medicine.Category.ToString().ToLower(),
                            Producer = pm.Medicine.Producer,
                            ExpiryDate = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        })
                        .ToList()
                })
                .ToList();

            var xmlDocument = new XDocument(
                new XElement("Patients",
                    patients.Select(p =>
                        new XElement("Patient",
                            new XAttribute("Gender", p.Gender),
                            new XElement("Name", p.Name),
                            new XElement("AgeGroup", p.AgeGroup),
                            new XElement("Medicines",
                                p.Medicines.Select(m =>
                                    new XElement("Medicine",
                                        new XElement("MedicineName", m.MedicineName),
                                        new XElement("Price", m.Price),
                                        new XElement("Category", m.Category),
                                        new XElement("Producer", m.Producer),
                                        new XElement("ExpiryDate", m.ExpiryDate)
                                    )
                                )
                            )
                        )
                    )
                )
            );

            using (var stringWriter = new StringWriter())
            {
                xmlDocument.Save(stringWriter);
                return stringWriter.ToString();
            }
        }
    }
}
