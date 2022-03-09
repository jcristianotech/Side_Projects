using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JohnTestWebApp.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; } = -1;
        [Required]
        [DataType(DataType.Text)]
        public TeamConference Conference { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearFounded { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Arena name must be between 5 and 50 characters.")]
        public string Arena { get; set; }

        public int Capacity { get; set; }

        public string City { get; set; }

        public string TeamPictureFileName
        {
            get
            {
                string filename = Name;
                filename = $"{filename}";
                filename += ".jpg";
                return filename;
            }
        }
    }
}