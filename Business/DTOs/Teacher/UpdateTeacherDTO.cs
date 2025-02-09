using Business.DTOs.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.DTOs.Teacher;

public class UpdateTeacherDTO : BaseIdDTO
{
    public string Fullname { get; set; }
    public string? ProfileImgUrl { get; set; }
    public IFormFile? ProfilePhoto { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }
    public string? PersonalExperience { get; set; }
    public string? Address { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? CertificatesUrl { get; set; }
    public IFormFile? CertificatesPhotos { get; set; }
    public string? Education { get; set; }
    public string? Achievements { get; set; }
    public string? Skills { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? InstagramUrl { get; set; }
}

public class UpdateTeacherDTOValidator : AbstractValidator<UpdateTeacherDTO>
{
    public UpdateTeacherDTOValidator()
    {
        RuleFor(x => x.Fullname)
            .NotEmpty()
            .WithMessage("Ad və soyad boş ola bilməz!")
            .MaximumLength(100)
            .WithMessage("Ad və soyad maksimum 100 simvol ola bilər!");

        RuleFor(x => x.Position)
            .NotEmpty()
            .WithMessage("Vəzifə boş ola bilməz!")
            .MaximumLength(100)
            .WithMessage("Vəzifə maksimum 100 simvol ola bilər!");

        RuleFor(x => x.Experience)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Təcrübə düzgün deyil!");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email boş ola bilməz!")
            .EmailAddress()
            .WithMessage("Düzgün email formatı daxil edin!")
            .MaximumLength(256)
            .WithMessage("Email maksimum 256 simvol ola bilər!");

        RuleFor(x => x.Phone)
            .MaximumLength(20)
            .WithMessage("Telefon nömrəsi maksimum 20 simvol ola bilər!");

        RuleFor(x => x.PersonalExperience)
            .MaximumLength(2000)
            .WithMessage("Şəxsi təcrübə maksimum 2000 simvol ola bilər!");

        RuleFor(x => x.Address)
            .MaximumLength(500)
            .WithMessage("Ünvan maksimum 500 simvol ola bilər!");

        RuleFor(x => x.Education)
            .MaximumLength(1000)
            .WithMessage("Təhsil maksimum 1000 simvol ola bilər!");

        RuleFor(x => x.Achievements)
            .MaximumLength(2000)
            .WithMessage("Nailiyyətlər maksimum 2000 simvol ola bilər!");

        RuleFor(x => x.Skills)
            .MaximumLength(1000)
            .WithMessage("Bacarıqlar maksimum 1000 simvol ola bilər!");
        
        RuleFor(x => x.ProfilePhoto)
            .NotEmpty()
            .WithMessage("Şəkil yüklənməlidir!")
            .Must(x => x.ContentType == "image/jpeg" || x.ContentType == "image/png")
            .WithMessage("Şəkil yalnız JPEG və ya PNG formatında olmalıdır!")
            .Must(x => x.Length <= 5 * 1024 * 1024)
            .WithMessage("Şəkil 5MB-dan böyük ola bilməz!");
        
        RuleFor(x => x.CertificatesPhotos)
            .NotEmpty()
            .WithMessage("Şəkil yüklənməlidir!")
            .Must(x => x.ContentType == "image/jpeg" || x.ContentType == "image/png")
            .WithMessage("Şəkil yalnız JPEG və ya PNG formatında olmalıdır!")
            .Must(x => x.Length <= 5 * 1024 * 1024)
            .WithMessage("Şəkil 5MB-dan böyük ola bilməz!");
    }
}