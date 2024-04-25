#nullable disable
using System.ComponentModel.DataAnnotations;

namespace HicomInterview.Application.DataModels
{
    /// <summary>
    /// OldAddress "Data Model" for use in UI binding or Api etc.
    /// </summary>
    /// <remarks>
    /// If property names match those on the Entity used in Mapster mapping, no further config is required.
    /// </remarks>
    public class AddressDM
    {
        public int AddressId { get; set; }

        public byte[] RowVersion { get; set; }

        [Display(Name = "Address line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; }
    }
}
