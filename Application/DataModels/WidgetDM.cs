#nullable disable
namespace HicomInterview.Application.DataModels
{
    /// <summary>
    /// Widget "Data Model" for use in UI binding or Api etc.
    /// </summary>
    /// <remarks>
    /// If property names match those on the Entity used in Mapster mapping, no further config is required.
    /// </remarks>
    public class WidgetDM
    {
        public int WidgetId { get; set; }

        public byte[] RowVersion { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public AddressDM OldAddress { get; set; }

        public AddressDM NewAddress { get; set; }
    }
}
