using System.ComponentModel.DataAnnotations;

namespace Company.DomainModels
{
    /// <summary>
    /// Represents a brand with its details.
    /// </summary>

    public class Brand
    {
        /// <summary>
        /// Gets or sets the unique identifier for the brand.
        /// </summary>

        [Key]
        [Display(Name = "Brand")]
        public long BrandID { get; set; }

        /// <summary>
        /// Gets or sets the name of the brand.
        /// </summary>

        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
    }
}
