using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotina.CrossCutting.Mappers;
using Rotina.Domain.Commands;
using Rotina.Domain.Entities;
using Rotina.Domain.ViewModels;
using Rotina.DomainService.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rotina.Web.Controllers
{
    
    public class LoginController : GenericController
    {
        private readonly ILoginService _svcLogin;

        public LoginController(IMessageService svcMessage, ILoginService svcLogin) : base(svcMessage)
        {
            _svcLogin = svcLogin;
        }

        #region Login

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Login([FromBody] LoginCommand body)
        {
            try
            {
                return Success(await _svcLogin.GenerateToken(body));
            }
            catch (Exception ex)
            {
                return await Error(ex);
            }
        }

        #endregion

        #region Get

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonResult> FindAll(decimal idUser)
        {
            try
            {
                List<LoginEntity> login = await _svcLogin.FindAllByUser(idUser);

                return Success(LoginMapper.ParseToViewModel(login));
            }
            catch (Exception ex)
            {
                return await Error(ex);
            }
        }

        #endregion
    }
}
