using System.ComponentModel.DataAnnotations;
using System;

namespace Is4RoleDemo.Models
{
    public class QrValidationModel
    {
        public string QR { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class QRCodeModel
    {
        public DateTime Date { get; set; }
        public string QRCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean IsApproved { get; set; }

    }
    public class ProcedureResult
    {
        [Key]

        public string? RESULT { get; set; }
        public string? MESSAGE { get; set; }
    }
    public class AproveResult
    {
        [Key]

        public string? RESULT { get; set; }
        public string? MESSAGE { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class QRCodeResult
    {
        [Key]

        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean IsApproved { get; set; }
    }
}
