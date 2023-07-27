using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Queries.Options.GetAllOptions
{
    public class GetAllOptionsResponse
    {
        public IList<OptionDTO> OptionDTOs { get; set; }
    }
}
