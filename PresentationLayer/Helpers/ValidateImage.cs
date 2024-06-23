using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Helpers
{
    public class ValidateImage : ValidationAttribute
    {
        string[] extensions;
        public ValidateImage(string[] _extensions)
        {
            extensions = _extensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                var file = value as IFormFile;
                var extension = Path.GetExtension(file.FileName);
                if (file != null)
                {
                    if (!extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult("extensions not valied" + (file.FileName));
                    }
                }
                return ValidationResult.Success;
            }
        }

    }
}
