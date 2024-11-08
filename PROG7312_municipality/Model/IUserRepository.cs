using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_municipality.Model
{
    internal interface IUserRepository
    {
        //Login Authentication
        bool AuthenticateUser(NetworkCredential credential);

        //Get User Info When Logged In
        UserModel GetByUsername(string username);

     



        //not implemented
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
       
        IEnumerable<UserModel> GetByAll();
        
    }
}
