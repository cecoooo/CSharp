namespace Medicines
{
    using AutoMapper;
    using Medicines.Data.Models;
    using Medicines.DataProcessor.ImportDtos;

    public class MedicinesProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public MedicinesProfile()
        {
            CreateMap<ImportMedicineDTO, Medicine>();
            CreateMap<ImportPharmaciesDTO, Pharmacy>();
        }
    }
}
