using AutoMapper;
using LabExamBussinessLogicLayer.DTOs;
using LabExamDataAccessLayer;
using LabExamDataAccessLayer.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamBussinessLogicLayer.Services
{
    public class UserServices
    {
        public static List<UserDTO> getALL()
        {
            var data = DataAccessFactory.UserDataAccess().getALL();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var users = mapper.Map<List<UserDTO>>(data);
            return users;
        }

        public static UserDTO get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var user = mapper.Map<UserDTO>(data);
            return user;
        }

        public static bool AddUser(UserDTO user)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var dbuser = mapper.Map<User>(user);

            if (DataAccessFactory.UserDataAccess().Add(dbuser)!=null)
            {
                return true;
            }

            return false;

        }

        public static bool updateUser(UserDTO user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);
            var userItem = mapper.Map<User>(user);

            if (DataAccessFactory.UserDataAccess().Update(userItem))
            {
                return true;
            }

            return false;
        }

        public static bool RemoveUser(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);
            // var product = new ProductModel();
            /* product.Id = id;
             var productItem = mapper.Map<Product>(product);*/
            if (DataAccessFactory.UserDataAccess().Delete(id))
            {
                return true;
            }

            return false;



        }

        //  public static bool 

        public static TokenDTO Authenticate(string uname, string pass)
        {
            var user = DataAccessFactory.LoginDataAccess().Login(uname, pass);
            if (user != null)
            {
                var tk = new Token();
                tk.UserId = user.Id;
                tk.Creation_Time = DateTime.Now;
                tk.Expired_At = null;
                tk.TokenDetails = Guid.NewGuid().ToString();
                var rttk = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
            }

            return null;
        }
        public static TokenDTO IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().get(token);
            if (tk != null && tk.Expired_At == null)
            {
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(cfg);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;


        }
    }
}
