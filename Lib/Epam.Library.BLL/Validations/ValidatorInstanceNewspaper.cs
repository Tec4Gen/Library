using Epam.Library.BLL.Validations.Extensions;
using Epam.Library.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.BLL.Validations
{
    public class ValidatorInstanceNewspaper: AbstractValidator<InstanceNewspaperDto>
    {
        public ValidatorInstanceNewspaper()
        {
            RuleFor(p => p.Number).NumberValid();

            RuleFor(p => p.NumberOfPages).NumberValid();

            RuleFor(p => p.ReliseDate).DatePublicationValid(1474);
        }
    }
}
