using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioCertificateDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioCertificateServices
{
    public class PortfolioCertificateService : IPortfolioCertificateService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioCertificateService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioCertificateAsync(CreatePortfolioCertificateDto createPortfolioCertificateDto)
        {
            var values = _mapper.Map<PortfolioCertificate>(createPortfolioCertificateDto);
            await _context.portfolioCertificates.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioCertificateAsync(int id)
        {
            var values = await _context.portfolioCertificates.FindAsync(id);
            _context.portfolioCertificates.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioCertificateDto>> GetAllPortfolioCertificateAsync()
        {
            var values = await _context.portfolioCertificates.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioCertificateDto>>(values);
        }

        public async Task<GetPortfolioCertificateByPortfolioCertificateIdDto> GetPortfolioCertificateByPortfolioCertificateIdAsync(int id)
        {
            var values = await _context.portfolioCertificates.FindAsync(id);
            return _mapper.Map<GetPortfolioCertificateByPortfolioCertificateIdDto>(values);
        }

        public async Task UpdatePortfolioCertificateAsync(UpdatePortfolioCertificateDto updatePortfolioCertificateDto)
        {
            var values = _mapper.Map<PortfolioCertificate>(updatePortfolioCertificateDto);
            _context.portfolioCertificates.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
