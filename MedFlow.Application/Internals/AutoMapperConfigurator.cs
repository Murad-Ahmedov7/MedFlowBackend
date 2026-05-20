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
using Application.Business.Examinations.Requests;
using Application.Business.Examinations.Responses;
using Application.Business.Invoices.Requests;
using Application.Business.Invoices.Responses;
using Application.Business.Medicines.Requests;
using Application.Business.Medicines.Responses;
using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Business.Payments.Responses;
using Application.Business.Prescriptions.Requests;
using Application.Business.Prescriptions.Responses;
using Application.Business.Receptionists.Requests;
using Application.Business.Receptionists.Responses;
using Application.Business.Services.Requests;
using Application.Business.Services.Responses;
using Application.Business.Users.Requests;
using Application.Business.Users.Responses;
using AutoMapper;
using Domain.Entities.Appointments;
using Domain.Entities.Auth;
using Domain.Entities.Billing.Invoices;
using Domain.Entities.Billing.Payments;
using Domain.Entities.Demo;
using Domain.Entities.Departments;
using Domain.Entities.Doctors;
using Domain.Entities.DoctorSchedules;
using Domain.Entities.Examinations;
using Domain.Entities.Medicines;
using Domain.Entities.Patients;
using Domain.Entities.Prescriptions;
using Domain.Entities.Services;

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

        CreateMap<SignUpUserRequest, User>();
        CreateMap<User, SignUpUserResponse>();

        CreateMap<CreateReceptionistRequest,User>();
        CreateMap<User,CreateReceptionistResponse>();


        CreateMap<SignInUserRequest, User>();
        CreateMap<User, SignInUserResponse>();

        CreateMap<CreatePatientRequest, Patient>();
        CreateMap<UpdatePatientRequest, Patient>();


        CreateMap<Patient, CreatePatientResponse>();

        CreateMap<Patient, PatientResponse>();

        CreateMap<Patient, PatientInfoResponse>()
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));


        CreateMap<CreateDepartmentRequest, Department>();
        CreateMap<Department, DepartmentResponse>();

        CreateMap<CreateDoctorRequest, Doctor>();
        CreateMap<Doctor, DoctorResponse>();

        CreateMap<CreateDoctorScheduleRequest, DoctorSchedule>();
        CreateMap<DoctorSchedule, DoctorScheduleResponse>();

        CreateMap<CreateAppointmentRequest, Appointment>();
        CreateMap<Appointment, CreateAppointmentResponse>();

        CreateMap<Appointment, AppointmentResponse>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FullName));


        CreateMap<Appointment, GetTodayAppointmentsResponse>();

        CreateMap<UpdateAppointmentStatusRequest, Appointment>();
        CreateMap<Appointment, UpdateAppointmentStatusResponse>();

        CreateMap<CreateExaminationRequest, Examination>();
        CreateMap<Examination, CreateExaminationResponse>();

        CreateMap<Examination, GetExaminationByIdResponse>();

        CreateMap<CreateMedicineRequest, Medicine>();
        CreateMap<Medicine, MedicineResponse>();

        CreateMap<CreatePrescriptionRequest, Prescription>();
        CreateMap<Prescription, PrescriptionResponse>();


        CreateMap<Prescription, GetPrescriptionByIdResponse>();
        CreateMap<Prescription, GetAllPrescriptionsResponse>();
        CreateMap<PrescriptionItem, GetPrescriptionItemsResponse>();


        CreateMap<AddPrescriptionItemRequest, PrescriptionItem>();
        CreateMap<PrescriptionItem, AddPrescriptionItemResponse>();


        CreateMap<CreateServiceForDepartmentRequest, Service>();
        CreateMap<Service, CreateServiceForDepartmentResponse>();

        CreateMap<Service, ServiceResponse>();




        CreateMap<CreateInvoiceRequest, Invoice>();
        CreateMap<Invoice, CreateInvoiceResponse>();


        CreateMap<Invoice, PatientInvoiceResponse>();

        CreateMap<Invoice, InvoiceResponse>()
            .ForMember(dest => dest.RemainingAmount, opt => opt.MapFrom(src => src.TotalAmount - src.PaidAmount));



        CreateMap<InvoiceItem, InvoiceItemResponse>();

        CreateMap<Payment, PaymentResponse>();

    }
}