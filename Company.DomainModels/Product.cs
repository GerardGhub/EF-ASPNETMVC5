using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Company.DomainModels.CustomValidations; // Assuming CustomValidations namespace exists

namespace Company.DomainModels
{
    // Represents a product in the database
    [Table("Products", Schema = "dbo")] // Maps this class to the "Products" table in the "dbo" schema
    public class Product
    {
        // Primary key for the Product entity
        [Key]
        [Display(Name = "Product ID")] // Friendly display name for UI
        public long ProductID { get; set; }

        // Name of the product
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name can't be blank")] // Validation: Product Name is required
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Alphabets only")]  // Validation: Allows only alphabets, numbers, and spaces
        [MaxLength(40, ErrorMessage = "Product name can be maximum 40 characters long")] // Validation: Maximum length for Product Name
        [MinLength(2, ErrorMessage = "Product name should contain at least 2 characters")] // Validation: Minimum length for Product Name
        public string ProductName { get; set; }

        // Price of the product
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price can't be blank")] // Validation: Price is required
        [Range(0, 1000000, ErrorMessage = "Price should be in between 0  and 1000000")] // Validation: Valid price range
        [DivisibleBy10(ErrorMessage = "Price should in multiples 10")] // Custom validation: Price should be multiples of 10
        public Nullable<decimal> Price { get; set; }


        // Date of purchase of the product
        [Column("DateOfPurchase", TypeName = "datetime")]  // Maps to "DateOfPurchase" column in SQL with datetime type
        [Display(Name = "Date of Purchase")]
        [DisplayFormat(DataFormatString = "M/d/yyyy", ApplyFormatInEditMode = true)] // Display format for Date of Purchase
        public Nullable<System.DateTime> DOP { get; set; }


        // Availability status of the product
        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Please select availability status")] // Validation: Availability status is required
        public string AvailabilityStatus { get; set; }


        // Foreign key for the Category entity
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category can't be blank")]  // Validation: Category is required
        public long CategoryID { get; set; }

        // Foreign key for the Brand entity
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand can't be blank")] // Validation: Brand is required
        public long BrandID { get; set; }

        // Indicates if the product is active
        [Display(Name = "Active")]
        public bool Active { get; set; }

        // URL or path to the product's photo
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        // Navigation property to the Brand entity
        public virtual Brand Brand { get; set; }
        // Navigation property to the Category entity
        public virtual Category Category { get; set; }
    }
}



