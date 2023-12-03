using AutoMapper;

namespace Invoices.Data
{
    public static class Configuration
    {
        public static string ConnectionString = @"--Set_Your_Connection_String--";

        public static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<InvoicesProfile>());
            return new Mapper(cfg);
        }
    }
}
