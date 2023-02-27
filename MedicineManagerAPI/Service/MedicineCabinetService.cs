using AutoMapper;
using MedicineManagerAPI.Authorization;
using MedicineManagerAPI.Entities;
using MedicineManagerAPI.Exceptions;
using MedicineManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;

namespace MedicineManagerAPI.Service
{
    public interface IMedicineCabinetService
    {
        public int Create(CreateMedicineDto dto);
        public MedicineCabinetDto GetById(int id);
        //GetAll;
        public void Update(int id, UpdateMedicine dto);
        public void Delete(int id);
        public PagedResult<MedicineCabinetDto> GetAll(MedicineCabinetQuery query);

    }
    public class MedicineCabinetService : IMedicineCabinetService
    {
        private readonly MedicineManagerDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<MedicineCabinetService> _logger;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;
        public MedicineCabinetService(MedicineManagerDbContext context, IMapper mapper,
            ILogger<MedicineCabinetService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        /// <summary>
        /// Method <c>Create</c> Creates new medicine in Medicine Cabinet.
        /// </summary>
        public int Create(CreateMedicineDto dto)
        {
            var medicineCabinet = _mapper.Map<MedicineCabinet>(dto);
            
            medicineCabinet.UserId = _userContextService.GetIntUserID();
            _context.MedicineCabinets.Add(medicineCabinet);
            _context.SaveChanges();
            return medicineCabinet.Id;
        }
        /// <summary>
        /// Method <c>GetById</c> Returns Medicine from Medicine Cabinet by ID.
        /// </summary>
        public MedicineCabinetDto GetById(int id)
        {
            var medicine = _context
                .MedicineCabinets.FirstOrDefault(x => x.Id == id);
            if (medicine == null)
            {
                throw new NotFoundException("Medicine not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, medicine,
                new ResourceOperationRequirement(ResourceOperation.Read)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("Action Forbid");
            }
            var medicineDto = _mapper.Map<MedicineCabinetDto>(medicine);
            return medicineDto;
        }
        /// <summary>
        /// Method <c>GetAll</c> Returns Medicine List from Medicine Cabinet filter by Clims UserID.
        /// </summary>
        public PagedResult<MedicineCabinetDto> GetAll(MedicineCabinetQuery query)
        {
            var UId = _userContextService.GetIntUserID();

            var baseQuery = _context
            .MedicineCabinets
                .Where(r => query.SearchPhrase == null || (r.MedName.ToLower().Contains(query.SearchPhrase.ToLower())
                                                           || r.MedDescription.ToLower()
                                                               .Contains(query.SearchPhrase.ToLower()))&&r.UserId == UId);


            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<MedicineCabinet, object>>>
                {
                    { nameof(MedicineCabinet.MedName), r => r.MedName },
                    { nameof(MedicineCabinet.MedDescription), r => r.MedDescription },
                    { nameof(MedicineCabinet.MedExpirationDate), r => r.MedExpirationDate },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                : baseQuery.OrderByDescending(selectedColumn);
            }
            var meds = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();
            var medsDtos = _mapper.Map<List<MedicineCabinetDto>>(meds);
            var result = new PagedResult<MedicineCabinetDto>(medsDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;

            
            //var medicine=_context.MedicineCabinets.Where(i=>i.UserId==UId).ToList();
            //var medicinedto = _mapper.Map<List<MedicineCabinetDto>>(medicine);
            //return medicinedto;
        }

        /// <summary>
        /// Method <c>Update</c> Modify existing Med in Medicine Cabinet .
        /// </summary>
        public void Update(int id, UpdateMedicine dto)
        {
            var medicine = _context.MedicineCabinets.FirstOrDefault(x => x.Id == id);
            if (medicine == null)
            {
                throw new NotFoundException("Medicine not found");
            }
            //Authorization check 
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, medicine,
                new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("Action Forbid");
            }
            //end of authorization
            medicine.MedName = dto.MedName;
            medicine.MedDescription = dto.MedDescription;
            medicine.MedExpirationDate = dto.MedExpirationDate;
            medicine.MedAmount = dto.MedAmount;
            _context.SaveChanges();
        }

        /// <summary>
        /// Method <c>Delete</c> Delete existing Med in Medicine Cabinet .
        /// </summary>
        public void Delete(int id)
        {
            _logger.LogError($"Medicine with id: {id} DELETE action invoked ");

            var medicine = _context.MedicineCabinets.FirstOrDefault(x => x.Id == id);
            if (medicine == null)
            {
                throw new NotFoundException("Medicine not found");
            }
            //Authorization check
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, medicine,
                new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException("Action Forbid");
            }
            //end of authorization
            _context.MedicineCabinets.Remove(medicine);
            _context.SaveChanges();
        }
    }
}
