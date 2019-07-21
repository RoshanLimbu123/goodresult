using System.ComponentModel.DataAnnotations;

namespace GoodResult.Models
{
    public class Result
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName Field could not be empty")]
        [Display(Name = "Enter FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "SymbolNumber Field could not be empty")]
        [Display(Name = "Enter SymbolNumber")]
        public string SymbolNumber { get; set; }
        [Required(ErrorMessage = "LastName Field could not be empty")]
        [Display(Name = "Enter LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "English Marks Field could not be empty")]
        [Display(Name = "Enter English Marks")]
        public decimal English { get; set; }
        [Required(ErrorMessage = "Economices Marks Field could not be empty")]
        [Display(Name = "Enter Economices Marks")]
        public decimal Economices { get; set; }
        [Required(ErrorMessage = "Nepalai Marks Field could not be empty")]
        [Display(Name = "Enter Nepali Marks")]
        public decimal Nepali { get; set; }
        [Required(ErrorMessage = "Account Marks Field could not be empty")]
        [Display(Name = "Enter Account Marks")]
        public decimal Account { get; set; }
        [Required(ErrorMessage = "ComputerScience Marks Field could not be empty")]
        [Display(Name = "Enter ComputerScience Marks")]
        public decimal ComputerScience { get; set; }
        public string ImageUrl { get; set; }
    }
}