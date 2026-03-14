using Application.Business.Appointments.Requests;
using Application.Business.Appointments.Responses;
using Application.Business.Categories.Requests;
using Application.Business.Categories.Responses;
using Application.Business.Departments.Requests;
using Application.Business.Departments.Responses;
using Application.Business.Doctors.Requests;
using Application.Business.Doctors.Responses;
using Application.Business.DoctorSchedules.Requests;
using Application.Business.DoctorSchedules.Responses;
using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Business.Users.Requests;
using Application.Business.Users.Responses;
using AutoMapper;
using Domain.Entities.Appointments;
using Domain.Entities.Auth;
using Domain.Entities.Demo;
using Domain.Entities.Departments;
using Domain.Entities.Doctors;
using Domain.Entities.DoctorSchedules;
using Domain.Entities.Patients;

namespace Application.Internals;

public sealed class AutoMapperConfigurator : Profile
{
    public AutoMapperConfigurator()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CreateCategoryResponse>();

        CreateMap<UpdateCategoryRequest, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
        CreateMap<Category, UpdateCategoryResponse>();
        CreateMap<Category, GetCategoryByIdResponse>();
        CreateMap<Category, GetAllCategoriesResponse>();

        CreateMap<RegisterUserRequest, User>();
        CreateMap<User, RegisterUserResponse>();


        CreateMap<LoginUserRequest, User>();
        CreateMap<User, LoginUserResponse>();

        CreateMap<CreatePatientRequest, Patient>();

        CreateMap<Patient,PatientResponse>();


        CreateMap<CreateDepartmentRequest, Department>();
        CreateMap<Department, DepartmentResponse>();

        CreateMap<CreateDoctorRequest, Doctor>();
        CreateMap<Doctor, DoctorResponse>();

        CreateMap<CreateDoctorScheduleRequest, DoctorSchedule>();
        CreateMap<DoctorSchedule,DoctorScheduleResponse>();

        CreateMap<CreateAppointmentRequest, Appointment>();
        CreateMap<Appointment, CreateAppointmentResponse>();

        CreateMap<Appointment, AppointmentResponse>()
            .ForMember( dest => dest.DoctorName,opt => opt.MapFrom(src => src.Doctor.User.FullName));
    }
}