using AutoMapper;

namespace Medicines.Data
{
    public class Configuration
    {
        public static string ConnectionString = @"--Set_Your_Connection_String--";

        public static Mapper getMapper() 
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<MedicinesProfile>());
            return new Mapper(cfg);
        }
    }
}
