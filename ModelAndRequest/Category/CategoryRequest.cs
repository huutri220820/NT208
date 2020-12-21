//Vo Huu Tri - 18521531 UIT
using FluentValidation;

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