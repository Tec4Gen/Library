using System;
using Epam.Library.BLL.Validations.Extensions;
using Epam.Library.Entities;
using FluentValidation;

namespace Epam.Library.BLL.Validations
{
    public class ValidationNewspaper: AbstractValidator<NewspaperDto>
    {
        public ValidationNewspaper()
        {
            RuleFor(p => p.Title)
                .Cascade(CascadeMode.Stop)
                .CustomEmpty()
                .LengthInclusiveBetween(2,300);
            RuleFor(p => p.PublishingHouse)
                .Cascade(CascadeMode.Stop)
                .CustomEmpty()
                .LengthInclusiveBetween(2, 300);

            When(p => p.Note != null, () =>
            {
                RuleFor(p => p.Note)
                   .Cascade(CascadeMode.Stop)
                   .LengthInclusiveBetween(2, 2000);
            });

            RuleFor(p => p.ReliseDate).DatePublicationValid(1400);
            RuleFor(p => p.NumberOfPages).NumberValid();

            //ListOfEditions -- TODO

            string patternISSN = @"^ISSN[0-9]{4}-[0-9]{4}$";
            string patternCityRuEng = @"^(([А-ЯЁ][а-яё]*([ ][а-яё]*)?(([-][АЁ-Я][а-яё]{1,})|([ ][А-ЯЁ]?[а-яё]{1,}))?)|([A-Z][a-z]*([ ][a-z]*)?(([-][A-Z][a-z]{1,})|([ ][A-Z]?[a-z]{1,}))?))$";

            RuleFor(p => p.City)
                .Cascade(CascadeMode.Stop)
                .CustomEmpty()
                .LengthInclusiveBetween(2,200)
                .Matches(patternCityRuEng).WithMessage("Must start with a capital letter, can contain a space after the space can be both lowercase and uppercase, can contain a hyphen, after the hyphen is written a capital letter");

            When(p=>p.ISSN != null, ()=> 
            {
                RuleFor(p => p.ISSN)
                    .Cascade(CascadeMode.Stop)
                    .LengthEqual(13)
                    .Matches(patternISSN).WithMessage("International standard serial number. It consists of the abbreviation ISSN and the following eight digits. The ISSN consists of two four-digit numeric groups separated by a hyphen.");
            });


        }
    }
}
