using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndRequest.Category
{
    public class CategoryRequest
    {
        public string name { get; set; }
        public string keyword { get; set; }
    }

    public class CategoryRequestValidation : AbstractValidator<CategoryRequest>
    {
        public CategoryRequestValidation()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Ten danh muc khong duoc de trong");
        }
    }
}
