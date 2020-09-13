using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Email { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        NAO_ATIVO,
        ATIVO,
        EMAIL_EM_CONFIRMACAO
    }
}
