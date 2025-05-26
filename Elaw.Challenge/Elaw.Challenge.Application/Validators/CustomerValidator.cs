using FluentValidation;
using Elaw.Challenge.Domain;

namespace Elaw.Challenge.Application.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerViewModel>
    {
        private readonly ICustomerService _service;
        public CustomerValidator(ICustomerService service)
        {
            _service = service;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x).Must(NotDuplicateEmail).WithMessage("Email já cadastrado").When(x => !string.IsNullOrWhiteSpace(x.Email));
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório").EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.Phone).Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$").When(x => !string.IsNullOrWhiteSpace(x.Phone)).WithMessage("Telefone inválido");
            RuleFor(x => x.Address.ZipCode).NotEmpty().WithMessage("CEP é obrigatório").When(x => x.Address != null);
            RuleFor(x => x.Address.Street).NotEmpty().WithMessage("Rua é obrigatória")
                .When(x => x.Address != null);
            RuleFor(x => x.Address.Number).NotEmpty().WithMessage("Número é obrigatório")
                .When(x => x.Address != null);
            RuleFor(x => x.Address.City).NotEmpty().WithMessage("Cidade é obrigatória")
                .When(x => x.Address != null);
            RuleFor(x => x.Address.State).NotEmpty().WithMessage("Estado é obrigatório").When(x => x.Address != null);

        }
        private bool NotDuplicateEmail(CustomerViewModel model)
        {
            var existingCustomer = _service.GetByEmail(model.Email);
            return existingCustomer == null || existingCustomer.Id == model.Id;
        }
    }
}