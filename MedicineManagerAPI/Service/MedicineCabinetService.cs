using AutoMapper;
using MedicineManagerAPI.Authorization;
using MedicineManagerAPI.Entities;
using MedicineManagerAPI.Exceptions;
using MedicineManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedicineManagerAPI.Service
{
    public interface IMedicineCabinetService
    {
        public int Create(CreateMedicineDto dto);
        public MedicineCabinetDto GetById(int id);
        //GetAll;
        public void Update(int id, UpdateMedicine dto);
        public void Delete(int id);
    }
    public class MedicineCabinetService : IMedicineCabinetService
    {
        private readonly MedicineManagerDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<MedicineCabinetService> _logger;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;
        public MedicineCabinetService(MedicineManagerDbContext context, IMapper mapper,
            ILogger<MedicineCabinetService> logger,IAuthorizationService authorizationService, IUserContextService userContextService)
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
            medicineCabinet.CreatedById = _userContextService.GetUserId;
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
            var medicineDto = _mapper.Map<MedicineCabinetDto>(medicine);
            return medicineDto;
        }

        //TODO: Get All method

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
                throw new ForbidException();
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
                throw new ForbidException();
            }
            //end of authorization
            _context.MedicineCabinets.Remove(medicine);
            _context.SaveChanges();
        }
    }
}
