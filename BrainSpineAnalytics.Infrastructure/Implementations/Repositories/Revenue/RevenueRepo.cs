using BrainSpineAnalytics.Application.DTOs.RequestDTOs.RevenueDto;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Revenue;
using BrainSpineAnalytics.Infrastructure.Data;
using BrainSpineAnalytics.Domain.Entities;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Revenue
{
    public class RevenueRepo:IRevenueRepo
    {
        private readonly BrainSpineDBContext _context;
        public RevenueRepo(BrainSpineDBContext context)
        {
            _context = context;
        }

        List<RevenueFactDto> IRevenueRepo.GetRevenue(int? clinicId)
        {
            var query =
                     from f in _context.DummyFactRevenue
                     join c in _context.DummyDimClinic on f.ClinicId equals c.Id
                     join p in _context.DummyDimProvider on f.ProviderId equals p.Id
                     join pr in _context.DummyDimPayer on f.PayerId equals pr.Id
                     join proc in _context.DummyDimProcedure on f.ProcedureId equals proc.Id
                     where !clinicId.HasValue || f.ClinicId == clinicId.Value
                     select new RevenueFactDto
                     {
                         Id = f.Id,
                         ClinicName = c.ClinicName,
                         ProviderName = p.ProviderName,
                         PayerName = pr.PayerName,
                         ProcedureName = proc.ProcedureName,
                         Revenue = f.Revenue ?? 0m, // Fixes CS0266 and CS8629
                         Visits = f.Visits ?? 0      // Fixes CS0266 and CS8629
                     };

            return query.ToList();
        }
    }
}
