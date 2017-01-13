using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsanaApp.Models
{
    [Table("dbo.LIST_DEPARTMENTS")]
    public class DepartmentListModels
    {
        [Key]
        public int DEPARTMENT_ID { get; set; }
        public string DEPARTMENT { get; set; }
    }
}