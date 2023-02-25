using AutoMapper;
using MedicineManagerAPI.Entities;
using MedicineManagerAPI.Models;

namespace MedicineManagerAPI
{
    public class MedicineManagerMaperProfile : Profile
    {
        public MedicineManagerMaperProfile()
        {
            CreateMap<DietDto, Diet>();
            CreateMap<Diet, DietDto>();
            CreateMap<MedicineCabinetDto,MedicineCabinet>();
            CreateMap<MedicineCabinet,MedicineCabinetDto>();
            CreateMap<CreateMedicineDto, MedicineCabinet>();
            CreateMap<PatientDto,Patient>();
            CreateMap<Patient,PatientDto>();
            CreateMap<TreatmentDto,Treatment>();
            CreateMap<Treatment,TreatmentDto>();
        }
    }
}
