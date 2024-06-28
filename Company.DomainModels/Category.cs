using System.ComponentModel.DataAnnotations;

namespace Company.DomainModels
{
    /// <summary>
    /// Represents a category with its details.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        
        [Key]
        [Display(Name = "Category")]
        public long CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
