using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataStoreApp.DataContracts
{
    public interface IPeopleClient
    {
        [Post("people")]
        Task AddPersonAsync([Body] Person p);
    }
}
