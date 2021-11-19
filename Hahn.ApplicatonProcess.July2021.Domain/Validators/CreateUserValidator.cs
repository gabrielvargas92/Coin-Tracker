﻿using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Domain.Dto.User;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.Age).GreaterThanOrEqualTo(18)
                .WithMessage($"User.Age must be greater or equal to 18.");

            RuleFor(p => p.FirstName)
                .Must(AValidName)
                .WithMessage($"FirstName must have at least 3 characters.");

            RuleFor(p => p.LastName)
                .Must(AValidName)
                .WithMessage($"LastName must have at least 3 characters.");

            RuleFor(p => p.Address)
                .Must(AValidAddress)
                .WithMessage($"Address should not be null or empty.");

            RuleFor(p => p.Email)
                .NotNull()
                .WithMessage($"Email should be not null.")
                .EmailAddress();
        }

        private bool AValidName(string value)
        {
            return value.Length >= 3 && !string.IsNullOrEmpty(value);
        }

        private bool AValidAddress(AddressCommandRequest address)
        {
            return address != null &&
                    !string.IsNullOrEmpty(address.Number) &&
                    !string.IsNullOrEmpty(address.PostalCode) &&
                    !string.IsNullOrEmpty(address.Street);
        }
    }
}
