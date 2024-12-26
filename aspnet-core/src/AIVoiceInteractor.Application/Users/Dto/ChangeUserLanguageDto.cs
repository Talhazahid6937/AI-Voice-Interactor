using System.ComponentModel.DataAnnotations;

namespace AIVoiceInteractor.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}