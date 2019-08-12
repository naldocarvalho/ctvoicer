using Domain.Entities;
using FluentValidation;
using System;

namespace Service.Validators
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("O objeto não foi localizado.");
                });

            RuleFor(c => c.Chassis)
                .NotEmpty().WithMessage("O chassi é obrigatório.")
                .NotNull().WithMessage("O chassi é obrigatório.");

            RuleFor(c => c.Color)
                .NotEmpty().WithMessage("A cor é obrigatória.")
                .NotNull().WithMessage("A cor é obrigatória.");

            RuleFor(c => c.Type)
                .NotEmpty().WithMessage("O tipo do veículo é obrigatório.")
                .NotNull().WithMessage("O tipo do veículo é obrigatório.");
        }
    }
}