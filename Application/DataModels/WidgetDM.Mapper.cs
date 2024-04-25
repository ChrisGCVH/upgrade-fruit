using HicomInterview.Domain.Entities;
using Mapster;
using System.Globalization;

namespace HicomInterview.Application.DataModels
{
    /// <summary>
    /// Example Mapster mapping config. See https://github.com/MapsterMapper/Mapster/wiki
    /// </summary>
    public class WidgetDMMapper : IRegister
	{
		public void Register(TypeAdapterConfig config)
        {
            // Convert FirstName/LastName to TitleCase when mapping from the DM to the Entity:
            config.NewConfig<WidgetDM, Widget>()
                .Map(dest => dest.FirstName, src => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(src.FirstName))
                .Map(dest => dest.LastName, src => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(src.LastName));
        }
    }
}
