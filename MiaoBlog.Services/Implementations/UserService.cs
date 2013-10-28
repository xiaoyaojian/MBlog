using MiaoBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiaoBlog.Services.Messaging.UserService;
using MiaoBlog.Model.Users;
using MiaoBlog.Infrastructure.UnitOfWork;
using MiaoBlog.Infrastructure.Domain;
using MiaoBlog.Services.Mapping;

namespace MiaoBlog.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;


        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();
            User user = new User();
            user.IdentityToken = request.UserIdentityToken;
            user.Email = request.Email;
            user.Name = request.Name;
            ThrowExceptionIfUserIsInvalid(user);
            userRepository.Add(user);
            unitOfWork.Commit();
            response.User = user.ConvertToUserView();
            return response;
        }

        private void ThrowExceptionIfUserIsInvalid(User user)
        {
            if (user.GetBrokenRules().Count() > 0)
            {
                StringBuilder brokenRules = new StringBuilder();
                brokenRules.AppendLine("There were problems saving the user:");
                foreach (BusinessRule businessRule in user.GetBrokenRules())
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }
                throw new UserInvalidException(brokenRules.ToString());
            }
        }

        public GetUserResponse GetUser(GetUserRequest request)
        {
            GetUserResponse response = new GetUserResponse();
            User user = userRepository.FindBy(request.UserIdentityToken);
            if (user != null)
            {
                response.UserFound = true;
                response.User = user.ConvertToUserView();
            }
            else
            {
                response.UserFound = false;
            }
            return response;
        }

        public ModifyUserResponse ModifyUser(ModifyUserRequest request)
        {
            ModifyUserResponse response = new ModifyUserResponse();
            User user = userRepository.FindBy(request.UserIndentityToken);
            user.Name = request.Name;
            user.Email = request.Email;
            ThrowExceptionIfUserIsInvalid(user);
            userRepository.Save(user);
            unitOfWork.Commit();
            response.User = user.ConvertToUserView();
            return response;
        }
    }
}
