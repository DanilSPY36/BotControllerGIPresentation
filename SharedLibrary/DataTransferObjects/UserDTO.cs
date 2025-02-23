using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DataTransferObjects
{
    public class UserDTO
    {
        public int id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int? HrPositionId { get; set; }
        public int? RoleId { get; set; }

        public virtual HrPosition? HrPosition { get; set; }
        public virtual RolesDim? RolesDim { get; set; }

        public virtual IEnumerable<UsersSpot>? UsersSpots { get; set; }
    }
}
